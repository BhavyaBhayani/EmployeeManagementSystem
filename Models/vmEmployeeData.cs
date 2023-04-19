using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class vmEmployeeData
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; } = null!;

        [Display(Name = "Email Id")]
        [EmailAddress]
        public string EmailId { get; set; } = null!;

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
