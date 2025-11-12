using DevExpress.XtraEditors;
using RFTestRecordManagementSystem.Repository;
using RFTestRecordManagementSystem.Service;
using RFTestRecordManagementSystem_Service;
using RFTestRecordManagementSystem.Domain;
using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Net.Http.Json;

namespace RFTestRecordManagementSystem.WinForms
{
    public partial class AddRecordForm : XtraForm
    {
        private readonly HttpClient _httpClient;
        public AddRecordForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5180/") };
        }

        private void AddRecordForm_Load(object sender, EventArgs e)
        {

        }

        private void lblRegulation_Click(object sender, EventArgs e)
        {

        }

        private void lblTechnology_Click(object sender, EventArgs e)
        {

        }

        private void lblBand_Click(object sender, EventArgs e)
        {

        }

        private void lblPower_Click(object sender, EventArgs e)
        {

        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void spinPower_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var newRecord = new RFTestRecord
                {
                    Regulation = txtRegulation.Text.Trim(),
                    RadioTechnology = txtTechnology.Text.Trim(),
                    Band = txtBand.Text.Trim(),
                    PowerDbm = spinPower.Value,
                    Result = txtResult.Text.Trim(),
                    TestDate = DateTime.Now.Date
                };

                var response = await _httpClient.PostAsJsonAsync("api/RFTestRecords", newRecord);
                response.EnsureSuccessStatusCode();

                XtraMessageBox.Show("新增成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"新增失敗：{ex.Message}");
            }
        }

        private void txtRegulation_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
