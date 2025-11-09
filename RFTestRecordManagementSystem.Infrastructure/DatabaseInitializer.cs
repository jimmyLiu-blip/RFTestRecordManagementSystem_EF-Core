using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFTestRecordManagementSystem.Domain;

namespace RFTestRecordManagementSystem.Infrastructure
{
    public static class DatabaseInitializer
    {
        public static void TestEFCoreConnection()
        {
            Console.WriteLine(" === 測試 Entity Framework Core 資料庫連線 ===");

            try
            {
                // 最核心的初始化設定之一，負責把 appsettings 載入成一個可供程式使用的設定物件
                // 在告訴程式去哪裡找設定資料、怎麼讀、讀完要存成什麼格式
                // 最後的 Build 會生成一個可以查詢設定的物件 (通常型別是 IConfigurationRoot)
                // optional: false：這個檔案一定要存在，不然就丟錯誤 <=> optional: true：找不到檔案也不會報錯，只是跳過。
                // reloadOnChange: true： 如果這個設定檔在執行時被修改，要不要自動重新載入
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // 直接幫你從 appsettings.json 裡的 "ConnectionStrings" 區段讀出特定名稱的字串。
                string connectionString = config.GetConnectionString("RFTestRecordManagementSystemDB")
                    ?? throw new InvalidOperationException("找不到連線字串設定!");

                // 幫我建立一份設定檔，告訴EF Core我要連接的資料庫是 SQL Sever，連線字串是 connectionString
                // DbContext：是 EF Core 提供的基底類別，資料庫操作的主體，你繼承它來建立自己的 RFTestDbContext
                // DbContextOptions<TContext>：EF Core 設定用的類別：告訴 DbContext 怎麼連線、用什麼 Provider，像是「操作手冊」
                // DbContextOptionsBuilder<TContext>：幫你建立 options 的工具類，專門用來設定連線方式，像是「手冊編輯器」
                // new DbContextOptionsBuilder<RFTestDbContext>()：建立一個專門給 RFTestDbContext 用的設定建構器
                // 泛型 <RFTestDbContext>：告訴 EF Core：「我這份設定是給哪一個資料庫 Context 用的」。
                // .UseSqlServer(connectionString)：「指定使用 SQL Server 當作資料庫，並套用剛剛的連線字串。」
                // .Options：「把剛剛設定好的 builder 轉成真正可用的設定物件。」
                // 它是一個「已設定好的設定包」，可以直接交給 DbContext 使用。
                var options = new DbContextOptionsBuilder<RFTestDbContext>()
                    .UseSqlServer(connectionString)
                    .Options;

                using var context = new RFTestDbContext(options);
                context.Database.EnsureCreated(); // 沒有資料表就自動建立

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" EF Core 資料庫連線成功 ! ");
                Console.ResetColor();

                var count = context.RFTestRecords.Count();
                Console.WriteLine($"目前資料表共有 {count} 筆資料。");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"測試失敗：{ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
