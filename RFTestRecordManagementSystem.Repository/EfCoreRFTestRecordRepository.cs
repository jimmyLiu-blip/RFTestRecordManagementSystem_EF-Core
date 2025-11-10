using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFTestRecordManagementSystem.Domain;
using RFTestRecordManagementSystem.Infrastructure;

namespace RFTestRecordManagementSystem.Repository
{
    public class EfCoreRFTestRecordRepository : IRFTestRecordRepository
    {
        private readonly RFTestDbContext _context;

        public EfCoreRFTestRecordRepository()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var options = new DbContextOptionsBuilder<RFTestDbContext>()
                .UseSqlServer(config.GetConnectionString("RFTestRecordManagementSystemDB"))
                .Options;

            _context = new RFTestDbContext(options);
        }

        public void InsertRecord(RFTestRecord record)
        {
            _context.RFTestRecords.Add(record);
            _context.SaveChanges();
        }

        public void UpdateRecord(RFTestRecord record)
        {
            var existing = _context.RFTestRecords.FirstOrDefault(r => r.RecordId == record.RecordId);
            if (existing == null)
            {
                throw new InvalidOperationException($"更新失敗，找不到 RecordId = {record.RecordId}");
            }

            existing.Regulation = record.Regulation;
            existing.RadioTechnology = record.RadioTechnology;
            existing.Band = record.Band;
            existing.PowerDbm = record.PowerDbm;
            existing.Result = record.Result;
            existing.TestDate = record.TestDate;

            _context.SaveChanges();
        }

        public void DeleteRecord(int recordId)
        {
            var record = _context.RFTestRecords.Find(recordId);
            if ( record == null)
            {
                throw new InvalidOperationException("刪除失敗，找不到 RecordId = {recordId}");
            }

            _context.RFTestRecords.Remove(record);
            _context.SaveChanges();
        }

        public RFTestRecord? GetRecordById(int recordId)
        {
            return _context.RFTestRecords.FirstOrDefault(r => r.RecordId == recordId);
        }

        public List<RFTestRecord> GetAllRecords()
        { 
            return _context.RFTestRecords.ToList();
        }

        public List<RFTestRecord> SearchRecords(string regulation, string radioTechnology)
        {
            // 這行的意思是：「我要先建立一個查詢的起點」，但是不馬上查資料庫。
            // .AsQueryable() 讓查詢可以一條一條地累加，最後才.ToList() 執行 SQL。
            var query = _context.RFTestRecords.AsQueryable();

            if (!string.IsNullOrWhiteSpace(regulation))
            {
                string pattern = $"%{regulation}%";
                query = query.Where(r => EF.Functions.Like((r.Regulation ?? "").ToLower(), pattern.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(radioTechnology))
            {
                string pattern = $"%{radioTechnology}%";
                query = query.Where(r => EF.Functions.Like((r.RadioTechnology ?? "").ToLower(), pattern.ToLower()));
            }

            var records = query.ToList();

            if (!records.Any())
            {
                throw new InvalidOperationException("查詢失敗，目前沒有任何紀錄");
            }

            return records;
        }
    }
}
