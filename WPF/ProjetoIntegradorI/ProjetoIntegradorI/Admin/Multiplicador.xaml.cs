using Auxiliar;
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
    /// Lógica interna para Multiplicador.xaml
    /// </summary>
    public partial class Multiplicador : Window
    {
        public Multiplicador()
        {
            InitializeComponent();
            preparaTela();
        }

        private int number;

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            preparaTela();
            if (!int.TryParse(txtNumero.Text, out number))
            {
                lblInvalido.Visibility = Visibility.Visible;
            }
            else
            {
                Arquivo arq = new Arquivo();
                try
                {
                    arq.multiplicaVotos(number);
                }
                catch(Exception ex)
                {
                    lblErro.Visibility = Visibility.Visible;
                }
                Sucesso s = new Sucesso();
                s.Show();
                this.Hide();
            }
        }

        private void preparaTela()
        {
            this.lblInvalido.Visibility = Visibility.Hidden;
            lblErro.Visibility = Visibility.Hidden;
        }
    }
}
