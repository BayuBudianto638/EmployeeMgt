using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using EmployeeMgt.HR.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.HR.Employee
{
    public class EmployeeAppService: AsyncCrudAppService<MstEmployee, EmployeeDto>, IEmployeeAppService
    {
        public EmployeeAppService(IRepository<MstEmployee> repository)
        : base(repository)
        {

        }
    }
}
