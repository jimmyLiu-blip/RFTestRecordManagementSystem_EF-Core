using Microsoft.Data.SqlClient;            // ✅ 改用 Microsoft.Data.SqlClient
using Microsoft.Extensions.Configuration;  // ✅ 用來讀取 appsettings.json
using RFTestRecordManagementSystem.Utilities;
using System.Data;

namespace RFTestRecordManagementSystem.Infrastructure
{
    public static class DatabaseConfigurement
    {
        private static readonly string _connectionString;

        // ✅ 靜態建構子：不需要你呼叫、第一次使用這個類別時自動執行一次、只會執行一次
        static DatabaseConfigurement()
        {
            try
            {
                // 建立設定讀取器
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())  // 專案執行時所在的根目錄
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                _connectionString = config.GetConnectionString("RFTestRecordManagementSystemDB")
                    ?? throw new InvalidOperationException("找不到 'RFTestRecordManagementSystemDB' 的連線字串設定");
            }
            catch (Exception ex)
            {
                var logDirection = LogsHelper.EnsureLogDirectory();
                File.AppendAllText(
                    Path.Combine(logDirection, "Infra_DB_error_log.txt"),
                    $"[{DateTime.Now}] 讀取 appsettings.json 失敗：{ex.Message}{Environment.NewLine}"
                );
                throw;
            }
        }

        // ✅ 提供外部取得 SqlConnection 的方法
        public static SqlConnection GetConnection()
        {
            try
            {
                // 不使用 using，讓外部負責關閉
                return new SqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                var logDirection = LogsHelper.EnsureLogDirectory();
                File.AppendAllText(
                    Path.Combine(logDirection, "Infra_DB_error_log.txt"),
                    $"[{DateTime.Now}] 建立資料庫連線失敗：{ex.Message}{Environment.NewLine}"
                );
                throw new InvalidOperationException("建立資料庫連線時發生錯誤，請確認 appsettings.json 是否正確", ex);
            }
        }

        // ✅ 測試連線方法
        public static bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                var logDirection = LogsHelper.EnsureLogDirectory();
                File.AppendAllText(
                    Path.Combine(logDirection, "Infra_DB_error_log.txt"),
                    $"[{DateTime.Now}] 資料庫連線失敗：{ex.Message}{Environment.NewLine}"
                );
                throw new InvalidOperationException($"資料庫連線失敗：{ex.Message}", ex);
            }
        }
    }
}
