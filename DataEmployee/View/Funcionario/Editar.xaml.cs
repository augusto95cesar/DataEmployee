using DataEmployee.DataContext;
using DataEmployee.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Lógica interna para Editar.xaml
    /// </summary>
    public partial class Editar : Window
    {
        private List<Telefone> listaTelefone = new List<Telefone>();
        public Editar(int id)
        {
            InitializeComponent();
            var _db = new EmployeeContext();
            this.listaTelefone = _db.Telefones.Where(x => x.FuncionarioId == id).ToList();
            this.TelefoneList.ItemsSource = this.listaTelefone;
            this.TelefoneList.Items.Refresh();

            var fun = _db.Funcionarios.Find(id);

            this.NomeFuncionario.DataContext = id;
            this.NomeFuncionario.Text = fun.Nome;
            this.cpf.Text = fun.Cpf;
        }



        private void AddTelefone(object sender, RoutedEventArgs e)
        {
            var telef = this.TextTelefone.Text;

            if(listaTelefone.Count == 0)
            {
                var phone = new Telefone
                {
                    Id =  1,
                    NumeroTelefone = telef
                };
                this.listaTelefone.Add(phone);
            }
            else
            {
                var phone = new Telefone
                {
                    Id = listaTelefone.Max(x => x.Id) + 1,
                    NumeroTelefone = telef
                };
                this.listaTelefone.Add(phone);
            }

            this.TelefoneList.ItemsSource = this.listaTelefone;            
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
            int id = Convert.ToInt32(this.NomeFuncionario.DataContext.ToString());

            var list = _db.Telefones.Where(x => x.FuncionarioId == id).ToList();
            foreach(var item in list)
            {
                _db.Telefones.Remove(item);
                _db.SaveChanges();
            }


            var fun = _db.Funcionarios.Find(id);

            fun.Nome    = this.NomeFuncionario.Text;
            fun.Cpf = this.cpf.Text;

            _db.Entry(fun).State = EntityState.Modified;
            _db.SaveChanges(); 

            if (listaTelefone.Count() != 0)
            {
                foreach (var item in listaTelefone)
                {
                    var Tel = new Telefone { NumeroTelefone = item.NumeroTelefone, FuncionarioId = id };
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
