using System.Threading.Tasks;
using Abp.Application.Services;
using EmployeeMgt.Authorization.Accounts.Dto;

namespace EmployeeMgt.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
