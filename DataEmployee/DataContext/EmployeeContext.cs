using DataEmployee.Model; 
using System.Data.Entity; 

namespace DataEmployee.DataContext
{
    class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=DataEmployeeContext")
        {
        }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
