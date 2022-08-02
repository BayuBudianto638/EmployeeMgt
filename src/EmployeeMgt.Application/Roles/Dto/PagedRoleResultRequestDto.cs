using Abp.Application.Services.Dto;

namespace EmployeeMgt.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

