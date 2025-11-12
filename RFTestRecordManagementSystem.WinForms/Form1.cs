using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using RFTestRecordManagementSystem.Domain;
using System;
using System.Windows.Forms;
using RFTestRecordManagementSystem.WinForms.button;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RFTestRecordManagementSystem.WinForms
{
    public partial class Form1 : XtraForm
    {
        // gridControl：整張表格(ex：電視機)
        // gridView：表格的主畫面邏輯層(ex：電視機螢幕上的顯示設定)
        private readonly HttpClient _httpClient;
        private readonly GridView _gridView;

        public Form1()
        {
            InitializeComponent();

            // 將認證憑證關閉
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            // 初始化 HttpClient，設定 API 伺服器位置
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:5180/") // ⚠️改成你 Swagger 顯示的 URL
            };

            _gridView = gridControl1.MainView as GridView;

            this.Load += Form1_Load; // 「註冊事件處理器」

            // Form1 建構子 → 建立物件階段（畫面還沒出現）
            // Form1_Load → 螢幕顯示前的初始化階段（可以載入資料、設定表格）
            // 在開啟 UI 界面前，他會先 Form1_Load --> LoadRecords --> 
            // this.Load += Form1_Load; 手動創立事件
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadRecords();

            // 樣式 (封存變灰)
            _gridView.RowStyle += (s, e) =>
            {
                var view = s as GridView;
                var record = view.GetRow(e.RowHandle) as RFTestRecord;
                if (record == null) return;

                if (record.IsArchived)
                {
                    e.Appearance.BackColor = System.Drawing.Color.LightGray;
                    e.Appearance.ForeColor = System.Drawing.Color.DarkGray;
                }
            };
        }

        private async Task LoadRecords()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/RFTestRecords");
                response.EnsureSuccessStatusCode(); // 如果不是 200 會丟例外

                var records = await response.Content.ReadFromJsonAsync<List<RFTestRecord>>();
                gridControl1.DataSource = records; // 把 records 放進 gridControl1.DataSource，「DataSource」的意思就是「資料來源」。

                _gridView.PopulateColumns();       // 會根據 DataSource 的屬性自動產生欄位，例如 RecordId, Regulation, Band, Result, TestDate → 都會自動變成表格欄位。
                _gridView.OptionsBehavior.Editable = false;     // 讓表格變成「唯讀模式」，不能直接在 Grid 上修改資料。
                _gridView.OptionsView.ShowAutoFilterRow = true;  // ✅ 開啟篩選列
                _gridView.OptionsView.ShowGroupPanel = false;   // 關掉最上面那個「Drag a column header here to group by that column」區塊，預設 DevExpress Grid 會顯示「群組提示列」，這行可以把它隱藏起來。

                XtraMessageBox.Show($"成功載入 {records.Count} 筆測試紀錄。", "資料載入成功");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"讀取 API 資料失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddRecordForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadRecords();
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            // _gridView.GetFocusedRow()：可以直接取得使用者目前選取的那一筆物件
            // selectedRecord.RecordId：就是資料庫裡的那筆唯一編號，系統可以藉這個 ID 找到資料並更新。
            if (_gridView.GetFocusedRow() is RFTestRecord selectedRecord)
            {
                using (var editForm = new EditRecord(selectedRecord.RecordId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadRecords();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("請先選擇要修改的紀錄。");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = _gridView.GetFocusedRow();
            if (selectedRow == null)
            {
                XtraMessageBox.Show("請先選取要刪除的紀錄!");
                return;
            }

            var record = (RFTestRecord)selectedRow;

            var confirm = XtraMessageBox.Show(
                $"確認要刪除測試紀錄：{record.RecordId} (法規：{record.Regulation}，頻段：{record.Band}）嗎?", "確認刪除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, $"api/RFTestRecords/softdelete/{record.RecordId}")
                {
                    Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json")
                };

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                
                await LoadRecords();
                XtraMessageBox.Show("刪除成功!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"刪除失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadRecords();
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private async void btnArchive_Click(object sender, EventArgs e)
        {
            var selectRow = _gridView.GetFocusedRow() as RFTestRecord;
            if (selectRow == null)
            {
                XtraMessageBox.Show("請先選擇要封存的紀錄");
                return;
            }

            var confirm = XtraMessageBox.Show(
                $"確認要封存紀錄:{selectRow.RecordId}(法規：{selectRow.Regulation}，頻段：{selectRow.Band}嗎?)",
                "確認封存",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var response = await _httpClient.PutAsync($"api/RFTestRecords/archive/{selectRow.RecordId}", null);
                response.EnsureSuccessStatusCode();

                await LoadRecords();
                XtraMessageBox.Show("紀錄已封存!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"封存失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
