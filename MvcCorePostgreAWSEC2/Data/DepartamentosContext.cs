using Microsoft.EntityFrameworkCore;
using MvcCorePostgreAWSEC2.Models;

namespace MvcCorePostgreAWSEC2.Data
{
    public class DepartamentosContext: DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : 
            base(options) { }

        public DbSet<Departamento> Departamentos { get; set;}

    }
}
