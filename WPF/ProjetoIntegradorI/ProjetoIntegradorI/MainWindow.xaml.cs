using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjetoIntegradorI.Admin;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoIntegradorI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            Admin.Login ad = new Admin.Login();
            ad.Show();
            this.Hide();
        }

        private void eleitor_Click(object sender, RoutedEventArgs e)
        {
           Eleitor.Regiao  reg = new Eleitor.Regiao();
           reg.Show();
           this.Hide();
        }
    }
}
