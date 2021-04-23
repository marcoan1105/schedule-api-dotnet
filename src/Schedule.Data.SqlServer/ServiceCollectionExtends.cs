using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Data.Context;
using Schedule.Data.SqlServer.Context;

namespace Schedule.Data.SqlServer
{
    public static class ServiceCollectionExtends
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddEfCore();

            services.AddDbContext<ScheduleContext, SqlServerScheduleContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}