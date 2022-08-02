using System.Threading.Tasks;
using EmployeeMgt.Configuration.Dto;

namespace EmployeeMgt.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
