using Abp.Application.Services;
using EmployeeMgt.MultiTenancy.Dto;

namespace EmployeeMgt.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

