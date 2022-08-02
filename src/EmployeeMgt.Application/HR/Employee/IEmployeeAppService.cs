using Abp.Application.Services;
using EmployeeMgt.HR.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.HR.Employee
{
    public interface IEmployeeAppService: IAsyncCrudAppService<EmployeeDto>
    {
    }
}
