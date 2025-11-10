using DevExpress.Utils.DirectXPaint;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Import.Html;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFTestRecordManagementSystem.Domain;
using RFTestRecordManagementSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RFTestRecordManagementSystem.WinForms
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly RFTestDbContext _context;

        private readonly GridView _gridView;

        public Form1()
        {
            InitializeComponent();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connStr = config.GetConnectionString("RFTestRecordManagementSystemDB");

            var options = new DbContextOptionsBuilder<RFTestDbContext>()
                .UseSqlServer(connStr)
                .Options;

            _context = new RFTestDbContext(options);

            _gridView = gridControl1.MainView as GridView;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _context.Database.EnsureCreated(); // ← 自動建立不存在的資料庫

                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"資料載入失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            var records = _context.RFTestRecords.ToList();
            gridControl1.DataSource = records;

            _gridView.PopulateColumns();
            _gridView.OptionsBehavior.Editable = false;
            _gridView.OptionsView.ShowGroupPanel = false;

            XtraMessageBox.Show($"成功載入 {records.Count} 筆測試紀錄。", "資料載入成功");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                var newRecord = new RFTestRecord
                {
                    Regulation = "FCC Part 27",
                    RadioTechnology = "NR (5G)",
                    Band = "n77",
                    PowerDbm = 25.5m,
                    Result = "PASS",
                    TestDate = DateTime.Now
                };

                _context.RFTestRecords.Add(newRecord);
                _context.SaveChanges();

                LoadData();
                XtraMessageBox.Show("已成功新增一筆測試紀錄！", "新增成功");
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"新增失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
