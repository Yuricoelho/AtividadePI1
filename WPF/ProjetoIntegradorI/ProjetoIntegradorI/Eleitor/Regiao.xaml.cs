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

namespace ProjetoIntegradorI.Eleitor
{
    /// <summary>
    /// Interaction logic for Regiao.xaml
    /// </summary>
    public partial class Regiao : Window
    {
        public Regiao()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            lblerro.Visibility = Visibility.Hidden;
        }

        private void voltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Close();
        }

        private void confirmar_Click_1(object sender, RoutedEventArgs e)
        {
            if (validaRadio() == 0)
            {
                lblerro.Visibility = Visibility.Visible;
            }
            else
            {
                Eleitor el = new Eleitor(validaRadio() == 1 ? rdPR.Content.ToString() : (validaRadio() == 2 ? rdSC.Content.ToString() : rdRS.Content.ToString()));
                el.Show();
                this.Close();
            }
        }

        private int validaRadio()
        {
            if (rdPR.IsChecked == true)
                return 1;
            if (rdSC.IsChecked == true)
                return 2;
            if (rdRS.IsChecked == true)
                return 3;

            return 0;       
        }
    }
}
