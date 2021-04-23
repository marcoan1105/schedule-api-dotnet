using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Schedule.Data.Context;

namespace Schedule.Data.SqlServer.Context
{
    public class SqlServerScheduleContext : ScheduleContext
    {
        public SqlServerScheduleContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}