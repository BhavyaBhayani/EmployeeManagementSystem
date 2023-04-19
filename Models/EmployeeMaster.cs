using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models;

public partial class EmployeeMaster
{
    public int EmployeeId { get; set; }

    [Display(Name = "Employee Name")]
    [Required]
    public string EmployeeName { get; set; } = null!;

    [Display(Name = "Email Id")]
    [EmailAddress]
    [Required]
    public string EmailId { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int DepartmentId { get; set; }

    public bool? IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
