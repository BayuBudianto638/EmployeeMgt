using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeeMgt.Configuration;

namespace EmployeeMgt.Web.Host.Startup
{
    [DependsOn(
       typeof(EmployeeMgtWebCoreModule))]
    public class EmployeeMgtWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EmployeeMgtWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeeMgtWebHostModule).GetAssembly());
        }
    }
}
