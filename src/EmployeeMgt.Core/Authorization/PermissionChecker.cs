using Abp.Authorization;
using EmployeeMgt.Authorization.Roles;
using EmployeeMgt.Authorization.Users;

namespace EmployeeMgt.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
