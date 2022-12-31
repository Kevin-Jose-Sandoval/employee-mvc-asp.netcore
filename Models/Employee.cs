using System;
using System.Collections.Generic;

namespace EmployeeApp.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? PositionId { get; set; }

        public virtual Position? PositionObject { get; set; }
    }
}
