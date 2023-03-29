using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Razor_CRUD.Data;
using Razor_CRUD.Model.Domain;
using Razor_CRUD.Model.View;

namespace Razor_CRUD.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly Db db;

        public AddModel(Db db)
        {
            this.db = db;
        }
        [BindProperty]
        public AddEmployee AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            //coverting view to domain
            var employees = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department
            };
            db.Employees.Add(employees);
            db.SaveChanges();
            ViewData["Message"] = "Updated Successfully!";
        }
    }
}
