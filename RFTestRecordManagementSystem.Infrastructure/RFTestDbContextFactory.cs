using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RFTestRecordManagementSystem.Infrastructure
{
    public class RFTestDbContextFactory : IDesignTimeDbContextFactory<RFTestDbContext>
    {
        public RFTestDbContext CreateDbContext(string[] args)
        {
            // 找到 appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // 讀取連線字串
            var connectionString = config.GetConnectionString("RFTestRecordManagementSystemDB");

            var optionsBuilder = new DbContextOptionsBuilder<RFTestDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new RFTestDbContext(optionsBuilder.Options);
        }
    }
}
