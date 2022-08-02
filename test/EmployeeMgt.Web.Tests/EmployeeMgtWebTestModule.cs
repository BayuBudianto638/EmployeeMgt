﻿using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeeMgt.EntityFrameworkCore;
using EmployeeMgt.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace EmployeeMgt.Web.Tests
{
    [DependsOn(
        typeof(EmployeeMgtWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class EmployeeMgtWebTestModule : AbpModule
    {
        public EmployeeMgtWebTestModule(EmployeeMgtEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeeMgtWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(EmployeeMgtWebMvcModule).Assembly);
        }
    }
}