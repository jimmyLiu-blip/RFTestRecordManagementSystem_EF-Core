using DevExpress.XtraEditors;
using RFTestRecordManagementSystem.Repository;
using RFTestRecordManagementSystem.Service;
using RFTestRecordManagementSystem_Service;
using System;
using System.Windows.Forms;

namespace RFTestRecordManagementSystem.WinForms
{
    public partial class AddRecordForm : XtraForm
    {
        private readonly IRFTestRecordService _service;
        public AddRecordForm()
        {
            InitializeComponent();
            _service = new RFTestRecordService(new EfCoreRFTestRecordRepository());
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string regulation = txtRegulation.Text;
                string radioTechnology = txtTechnology.Text;
                string band = txtBand.Text;
                decimal power = spinPower.Value;
                string result = txtResult.Text;
                DateTime testDate = DateTime.Now.Date;

                _service.AddRecord(regulation, radioTechnology, band, power, result, testDate);

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
