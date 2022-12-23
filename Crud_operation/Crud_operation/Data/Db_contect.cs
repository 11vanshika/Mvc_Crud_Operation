using Crud_operation.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_operation.Data
{
    public class Db_contect :DbContext
    {
        public Db_contect(DbContextOptions<Db_contect> options) : base(options)
        {

        }

        public DbSet<Employee> Employes { get; set; }
    }
}
