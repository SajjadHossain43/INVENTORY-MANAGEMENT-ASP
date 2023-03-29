using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_CRUD.Data;
using Razor_CRUD.Model.Domain;
using Razor_CRUD.Model.View;
using System.Data;

namespace Razor_CRUD.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly Db db;
        [BindProperty]
        public EditEmployee editEmployee { get; set; }
        public EditModel(Db db)
        {
            this.db = db;
        }
        public void OnGet(Guid id)
        {
            var employee = db.Employees.Find(id);
            if (employee != null)
            {
                //convert domain model to view model
                editEmployee = new EditEmployee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department
                };
            }
        }

        public void OnPostUpdate()
        {
            //covert view to domain model
            if(editEmployee != null)
            {
                var update = db.Employees.Find(editEmployee.Id);
                if(update != null)
                {
                    update.Name = editEmployee.Name;
                    update.Salary = editEmployee.Salary;
                    update.Email = editEmployee.Email;
                    update.DateOfBirth = editEmployee.DateOfBirth;
                    update.Department = editEmployee.Department;

                    db.SaveChanges();
                    ViewData["Message"] = "Successful!";
                }
            }
        }

        public IActionResult OnPostDelete()
        {
            var delete = db.Employees.Find(editEmployee.Id);
            if(delete != null)
            {
                db.Employees.Remove(delete);
                db.SaveChanges();
                return RedirectToPage("/Employees/List");
            }
            return Page();
        }
    }
}
