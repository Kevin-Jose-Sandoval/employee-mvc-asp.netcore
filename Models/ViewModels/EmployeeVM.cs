using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeApp.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee EmployeeObject { get; set; }
        public List<SelectListItem> PositionListObject { get; set; }
    }
}
