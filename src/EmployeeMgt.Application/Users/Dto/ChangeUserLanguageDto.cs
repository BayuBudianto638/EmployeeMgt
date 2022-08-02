using System.ComponentModel.DataAnnotations;

namespace EmployeeMgt.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}