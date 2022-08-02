using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.HR.Employee
{
    [Table("MstEmployee")]
    public class MstEmployee : FullAuditedEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public float BasicSalary { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public DateTime Description { get; set; }
    }
}
