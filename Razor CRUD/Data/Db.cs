using Microsoft.EntityFrameworkCore;
using Razor_CRUD.Model.Domain;

namespace Razor_CRUD.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
