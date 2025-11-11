using DevExpress.XtraEditors;
using RFTestRecordManagementSystem.Repository;
using RFTestRecordManagementSystem.Service;
using RFTestRecordManagementSystem_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFTestRecordManagementSystem.WinForms.button
{
    public partial class EditRecord : XtraForm
    {
        private readonly IRFTestRecordService _service;
        private readonly int _recordId;  // 用來記錄這筆資料的主鍵
        public EditRecord(int recordId)
        {
            InitializeComponent();
            _service = new RFTestRecordService(new EfCoreRFTestRecordRepository());
            _recordId = recordId;
            this.Load += EditRecord_Load; // 確保 Load 時會執行載入事件
        }

        private void EditRecord_Load(object sender, EventArgs e)
        { 
            // 用傳進來的 ID 取得資料庫的資料
           var record = _service.GetRecordById(_recordId);
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                _service.UpdateRecord(
                    _recordId,
                    txtRegulation.Text,
                    txtTechnology.Text,
                    txtBand.Text,
                    spinPower.Value,
                    txtResult.Text,
                    DateTime.Now.Date);

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

    }
}
