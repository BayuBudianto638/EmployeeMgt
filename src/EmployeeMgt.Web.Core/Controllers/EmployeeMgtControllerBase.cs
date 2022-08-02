using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EmployeeMgt.Controllers
{
    public abstract class EmployeeMgtControllerBase: AbpController
    {
        protected EmployeeMgtControllerBase()
        {
            LocalizationSourceName = EmployeeMgtConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
