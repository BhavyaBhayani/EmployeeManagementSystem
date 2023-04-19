using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Models;

public partial class DepartmentMaster
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedDate { get; set; }
}
