using DataEmployee.DataContext;
using DataEmployee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataEmployee.View.Funcionario
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        private List<Telefone> listaTelefone = new List<Telefone>();
        public Cadastro()
        {
            InitializeComponent(); 
        }

        private void AddTelefone(object sender, RoutedEventArgs e)
        {
            var telef = this.TextTelefone.Text;

            var phone = new Telefone
            {
                Id = listaTelefone.Count() + 1,
                NumeroTelefone = telef
            };
           
            this.TelefoneList.ItemsSource = this.listaTelefone;
            this.listaTelefone.Add(phone);
            this.TelefoneList.Items.Refresh();

        }

        private void RemoveTelefone(object sender, RoutedEventArgs e)
        {
            Button result = new Button();
            result = (Button)sender;
            var id = result.DataContext.ToString();

            //this.listaTelefone.RemoveAt(Convert.ToInt32(id) - 1);
            var tel = this.listaTelefone.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();
            this.listaTelefone.Remove(tel);
            this.TelefoneList.ItemsSource = this.listaTelefone;
            this.TelefoneList.Items.Refresh();


        }
        private void Cadastar(object sender, RoutedEventArgs e)
        {
            var _db = new EmployeeContext();
            var func = new DataEmployee.Model.Funcionario { Nome = this.NomeFuncionario.Text, Cpf =  this.cpf.Text };
            _db.Funcionarios.Add(func);
            _db.SaveChanges();
            var idFun = _db.Funcionarios.Max(x => x.Id);

            if(listaTelefone.Count() != 0)
            {
               foreach(var item in listaTelefone)
                {
                    var Tel = new Telefone { NumeroTelefone = item.NumeroTelefone, FuncionarioId = idFun };
                    _db.Telefones.Add(Tel);
                    _db.SaveChanges();
                }                
            }
            var home = new MainWindow();
            home.Show();
            this.Close();
        }
        private void Voltar(object sender, RoutedEventArgs e)
        {
            var home = new MainWindow();
            home.Show();
            this.Close();
        }
    }
}
