using DataEmployee.DataContext;
using DataEmployee.Model;
using DataEmployee.Service;
using DataEmployee.View.Funcionario;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataEmployee
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListarFuncionarios();
        }

        private void DeletarFuncionario(object sender, RoutedEventArgs e)
        {
            try
            {
                var _db = new EmployeeContext();

                Button result = new Button();
                result = (Button)sender;
                int id = Convert.ToInt32(result.DataContext.ToString());

                var listTel = _db.Telefones.Where(x => x.FuncionarioId == id).ToList();
                foreach (var item in listTel)
                {
                    _db.Telefones.Remove(item);
                    _db.SaveChanges();
                }
                var func = _db.Funcionarios.Where(x => x.Id == id).FirstOrDefault();
                _db.Funcionarios.Remove(func);
                _db.SaveChanges();
                ListarFuncionarios();
            }
            catch(Exception ex)
            {

            }
        }
        private void EditarFuncionario(object sender, RoutedEventArgs e)
        {
            Button result = new Button();
            result = (Button)sender;
            int id = Convert.ToInt32(result.DataContext.ToString());
            var cadastro = new Editar(id);
            cadastro.Show();
            this.Close();
        }

        private void NovoFuncionario(object sender, RoutedEventArgs e)
        {
            var cadastro = new Cadastro();
            cadastro.Show();
            this.Close();
        }

        public void ListarFuncionarios()
        {
            var db = new EmployeeContext();
            this.Funcionarios.ItemsSource = db.Funcionarios.ToList();
            this.Funcionarios.Items.Refresh();
        }
    }
}
