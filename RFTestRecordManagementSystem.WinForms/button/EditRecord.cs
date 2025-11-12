using DevExpress.XtraEditors;
using RFTestRecordManagementSystem.Domain;
using RFTestRecordManagementSystem.Repository;
using RFTestRecordManagementSystem.Service;
using RFTestRecordManagementSystem_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFTestRecordManagementSystem.WinForms.button
{
    public partial class EditRecord : XtraForm
    {
        private readonly HttpClient _httpClient;
        private readonly int _recordId;  // 用來記錄這筆資料的主鍵
        public EditRecord(int recordId)
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5180/") };
            _recordId = recordId;
            this.Load += EditRecord_Load; // 確保 Load 時會執行載入事件
        }

        private async void EditRecord_Load(object sender, EventArgs e)
        {
            try
            {
                // 用傳進來的 ID 取得資料庫的資料
                var record = await _httpClient.GetFromJsonAsync<RFTestRecord>($"api/RFTestRecords/{_recordId}");
                if (record == null)
                {
                    XtraMessageBox.Show("找不到該筆紀錄");
                    Close();
                    return;
                }

                txtRegulation.Text = record.Regulation;
                txtTechnology.Text = record.RadioTechnology;
                txtBand.Text = record.Band;
                spinPower.Value = record.PowerDbm;
                txtResult.Text = record.Result;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"載入紀錄失敗：{ex.Message}");
            }

        }

        private void lblRegulation_Click(object sender, EventArgs e)
        {

        }

        private void txtRegulation_Click(object sender, EventArgs e)
        {

        }

        private void txtTechnology_Click(object sender, EventArgs e)
        {

        }

        private void txtBand_Click(object sender, EventArgs e)
        {

        }

        private void spinPower_Click(object sender, EventArgs e)
        {

        }

        private void txtResult_Click(object sender, EventArgs e)
        {

        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var updateRecord = new RFTestRecord
                {
                    RecordId = _recordId,
                    Regulation = txtRegulation.Text.Trim(),
                    RadioTechnology = txtTechnology.Text.Trim(),
                    Band = txtBand.Text.Trim(),
                    PowerDbm = spinPower.Value,
                    Result = txtResult.Text.Trim()
                };

                var response = await _httpClient.PutAsJsonAsync($"api/RFTestRecords/{_recordId}", updateRecord);
                response.EnsureSuccessStatusCode();

                XtraMessageBox.Show("修改成功！");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"修改失敗：{ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtResult_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
