using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFTestRecordManagementSystem.Domain;
using RFTestRecordManagementSystem.Infrastructure;

namespace RFTestRecordManagementSystem.Repository
{
    public class EfCoreRFTestRecordRepository:IRFTestRecordRepository
    {
        private readonly RFTestDbContext _context;

        public EfCoreRFTestRecordRepository()
        { 
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true)
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

        }
    }
}
