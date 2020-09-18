using DataEmployee.DataContext;
using DataEmployee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEmployee.Service
{
    public static class FuncionarioService
    {

        public static object obterListaFuncionario()
        {
            var _db = new EmployeeContext();
            return _db.Funcionarios.ToList();
        }
    }
}