using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Schedule.Data.Context;
using Schedule.Data.SqlServer.Context;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Schedule.Data.SqlServer.Factory
{
    public class SqlServerScheduleContextFactory : IDesignTimeDbContextFactory<SqlServerScheduleContext>
    {
        public SqlServerScheduleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ScheduleContext>();

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);

                return new SqlServerScheduleContext(builder.Options);
        }
    }
}