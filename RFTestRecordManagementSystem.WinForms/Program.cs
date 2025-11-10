using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RFTestRecordManagementSystem.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connStr = config.GetConnectionString("RFTestRecordManagementSystemDB");
            MessageBox.Show($"成功讀取連線字串：{connStr}");

            // 設定全域主題樣式（建議）
            BonusSkins.Register(); // 註冊額外的主題
            SkinManager.EnableFormSkins(); // 啟用 Skin 支援
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
            // 可選其他主題："Visual Studio 2013 Blue", "The Bezier", "DevExpress Style"

            // 2. 啟動 WinForm 主畫面
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
