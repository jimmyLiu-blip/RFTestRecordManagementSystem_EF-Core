using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFTestRecordManagementSystem.Repository;
using RFTestRecordManagementSystem_Service;
using RFTestRecordManagementSystem.Service;
using RFTestRecordManagementSystem.Domain;
using RFTestRecordManagementSystem.Infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;
using RFTestRecordManagementSystem.WinForms.button;

namespace RFTestRecordManagementSystem.WinForms
{
    public partial class Form1 : XtraForm
    {
        // gridControl：整張表格(ex：電視機)
        // gridView：表格的主畫面邏輯層(ex：電視機螢幕上的顯示設定)
        private readonly IRFTestRecordService _service;
        private readonly GridView _gridView;

        public Form1()
        {
            InitializeComponent();

            _service = new RFTestRecordService(new EfCoreRFTestRecordRepository());

            _gridView = gridControl1.MainView as GridView;

            this.Load += Form1_Load; // 「註冊事件處理器」

            // Form1 建構子 → 建立物件階段（畫面還沒出現）
            // Form1_Load → 螢幕顯示前的初始化階段（可以載入資料、設定表格）
            // 在開啟 UI 界面前，他會先 Form1_Load --> LoadRecords --> 
            // this.Load += Form1_Load; 手動創立事件
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                var records = _service.GetAllRecords();
                gridControl1.DataSource = records; // 把 records 放進 gridControl1.DataSource，「DataSource」的意思就是「資料來源」。

                _gridView.PopulateColumns();       // 會根據 DataSource 的屬性自動產生欄位，例如 RecordId, Regulation, Band, Result, TestDate → 都會自動變成表格欄位。
                _gridView.OptionsBehavior.Editable = false;     // 讓表格變成「唯讀模式」，不能直接在 Grid 上修改資料。
                _gridView.OptionsView.ShowAutoFilterRow = true;  // ✅ 開啟篩選列
                _gridView.OptionsView.ShowGroupPanel = false;   // 關掉最上面那個「Drag a column header here to group by that column」區塊，預設 DevExpress Grid 會顯示「群組提示列」，這行可以把它隱藏起來。

                XtraMessageBox.Show($"成功載入 {records.Count} 筆測試紀錄。", "資料載入成功");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"資料載入失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddRecordForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRecords();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // _gridView.GetFocusedRow()：可以直接取得使用者目前選取的那一筆物件
            // selectedRecord.RecordId：就是資料庫裡的那筆唯一編號，系統可以藉這個 ID 找到資料並更新。
            if (_gridView.GetFocusedRow() is RFTestRecord selectedRecord)
            {
                using (var editForm = new EditRecord(selectedRecord.RecordId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadRecords();
                    }
                }
            }
            else
            { 
                XtraMessageBox.Show("請先選擇要修改的紀錄。");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("刪除功能尚未實作");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
