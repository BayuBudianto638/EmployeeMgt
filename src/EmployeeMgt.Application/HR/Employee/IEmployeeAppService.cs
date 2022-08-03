using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EmployeeMgt.HR.Employee.Dto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.HR.Employee
{
    public interface IEmployeeAppService: IAsyncCrudAppService<EmployeeDto>
    {
        void CreateMsEmployee(EmployeeDto input);
        JObject UpdateMsEmployee(EmployeeDto input);
        PagedResultDto<EmployeeDto> GetByUserName(PagedResultRequestDto data, string userName);
        PagedResultDto<EmployeeDto> GetByGroup(PagedResultRequestDto data, string group);
    }
}
