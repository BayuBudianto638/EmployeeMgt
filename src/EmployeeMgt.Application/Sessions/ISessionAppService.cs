using System.Threading.Tasks;
using Abp.Application.Services;
using EmployeeMgt.Sessions.Dto;

namespace EmployeeMgt.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
