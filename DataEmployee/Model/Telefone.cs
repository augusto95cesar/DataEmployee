using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEmployee.Model
{
    class Telefone
    {
        public int Id { get; set; }

        public string NumeroTelefone { get; set; } 

        //Foreign Key
        public int FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionarios { get; set; }
    }
}
