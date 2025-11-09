using Microsoft.EntityFrameworkCore;
using RFTestRecordManagementSystem.Domain;

namespace RFTestRecordManagementSystem.Infrastructure
{
    // 此 DbContext 負責連接 LocalDB 並管理 RFTestRecords 資料表。
    // 使用 appsettings.json 中的 ConnectionStrings → RFTestRecordManagementSystemDB。
    public class RFTestDbContext : DbContext
    {
        // 宣告 DbSet<T>（對應資料表）
        // 這個資料表在程式裡叫 RFTestRecords，在資料庫裡對應到 RFTestRecords 表格
        // DbSet<T> 就是「資料表的程式化代表」，是 EF Core 提供的一種泛型集合類別，它代表「某個 Entity（實體類）對應的整張資料表
        // DbSet 是「表格」，T 是「每一列的資料格式」。
        // RFTestRecord：表示每一筆「RF 測試紀錄」的結構（也就是資料表的每一行）
        // DbSet<RFTestRecord> 表示整張「RFTestRecords」資料表
        // RFTestRecords：表示在程式中這張表的名字，你可以用 db.RFTestRecords 來操作這張表
        public DbSet<RFTestRecord> RFTestRecords { get; set; }

        // 建構子注入設定，用來「建立 RFTestDbContext 物件時會自動執行的程式」
        // (DbContextOptions<RFTestDbContext> options)；傳入的參數
        // base(options)：呼叫父類別（DbContext）的建構子
        // options 是一個「設定物件」，裡面包含
        // 1. 你要連線的資料庫種類（SQL Server、SQLite...）
        // 2. 連線字串
        // 3. 是否啟用 Lazy Loading、追蹤變更等設定
        // RFTestDbContext 是你自己定義的類別，但它是繼承自 DbContext（EF Core 提供的類別）
        public RFTestDbContext(DbContextOptions<RFTestDbContext> options): base(options) 
        {
        }

        // 「覆寫（改寫）」父類別中本來就存在的方法：protected virtual void OnModelCreating(ModelBuilder modelBuilder)
        // 為什麼只有設定 string 欄位，因為：int、decimal、DateTime 這些 EF Core 會自動對應。
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<RFTestRecord>(entity =>
            {
                entity.ToTable("RFTestRecords", schema: "dbo");

                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.RecordId)
                       .ValueGeneratedOnAdd();

                entity.Property(e => e.Regulation)
                       .HasMaxLength(50)
                       .IsRequired();

                entity.Property(e => e.RadioTechnology)
                        .HasMaxLength(50)
                        .IsRequired();

                entity.Property(e => e.Band)
                        .HasMaxLength(50)
                        .IsRequired();

                entity.Property(e => e.Result)
                        .HasMaxLength(10)
                        .IsRequired();

                entity.Property(e => e.PowerDbm)
                        .HasColumnType("decimal(6,3)")
                        .IsRequired();

                entity.Property(e => e.TestDate)
                        .HasColumnType("datetime")
                        .IsRequired();

            }
            );
        }
    }
}
