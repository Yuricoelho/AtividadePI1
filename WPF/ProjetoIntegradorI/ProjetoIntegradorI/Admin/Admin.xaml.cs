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

namespace ProjetoIntegradorI.Admin
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Close();
        }

        private void cadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCandidato cd = new CadastrarCandidato();
            cd.Show();
            this.Hide();
        }

        private void exportar_Click(object sender, RoutedEventArgs e)
        {
            Sucesso s = new Sucesso();
            s.Show();
            this.Hide();
        }
    }
}
