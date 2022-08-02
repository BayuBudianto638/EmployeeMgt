using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EmployeeMgt.Authorization.Roles;
using EmployeeMgt.Authorization.Users;
using EmployeeMgt.MultiTenancy;
using EmployeeMgt.HR.Employee;

namespace EmployeeMgt.EntityFrameworkCore
{
    public class EmployeeMgtDbContext : AbpZeroDbContext<Tenant, Role, User, EmployeeMgtDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<MstEmployee> MstEmployee { get; set; }

        public EmployeeMgtDbContext(DbContextOptions<EmployeeMgtDbContext> options)
            : base(options)
        {
        }
    }
}
