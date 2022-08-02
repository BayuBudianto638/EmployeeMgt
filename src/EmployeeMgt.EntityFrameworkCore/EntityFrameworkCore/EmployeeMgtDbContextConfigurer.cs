using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgt.EntityFrameworkCore
{
    public static class EmployeeMgtDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EmployeeMgtDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EmployeeMgtDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
