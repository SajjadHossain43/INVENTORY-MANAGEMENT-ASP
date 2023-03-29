using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_CRUD.Data;
using Razor_CRUD.Model.Domain;

namespace Razor_CRUD.Pages.Employees
{
    public class ListModel : PageModel
    {
        private readonly Db db;
        public List<Employee> employees { get; set; }
        public ListModel(Db db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            employees = db.Employees.ToList();
        }
    }
}
