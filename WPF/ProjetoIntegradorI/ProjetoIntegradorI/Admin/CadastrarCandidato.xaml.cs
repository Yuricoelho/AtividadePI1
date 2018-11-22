using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Auxiliar;
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
    /// Interaction logic for CadastrarCandidato.xaml
    /// </summary>
    public partial class CadastrarCandidato : Window
    {
        public CadastrarCandidato()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            preparaTela();
        }

        private int codigoCandidato;
        private int codigoPartdo;

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Close();
        }

        private void preparaTela()
        {
            this.lblNomeErro.Visibility = Visibility.Hidden;
            this.lblCodigoErro.Visibility = Visibility.Hidden;
            this.lblCodigoInvalido.Visibility = Visibility.Hidden;
            this.lblCodigoPartidoErro.Visibility = Visibility.Hidden;
            this.lblCodigoPartidoInvalido.Visibility = Visibility.Hidden;
            this.lblCandidatoCadastrado.Visibility = Visibility.Hidden;
        }

        private bool verificaCampos()
        {
            preparaTela();
            if (txtNome.Text.Length <= 1)
            {
                lblNomeErro.Visibility = Visibility.Visible;
                return false;
            }
            if (txtCodigo.Text.Length < 1)
            {
                lblCodigoErro.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                if (!int.TryParse(txtCodigo.Text, out codigoCandidato))
                {
                    lblCodigoInvalido.Visibility = Visibility.Visible;
                    return false;
                } 
            }
            if (txtCodigoPartido.Text.Length < 1)
            {
                lblCodigoPartidoErro.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                if (!int.TryParse(txtCodigoPartido.Text, out codigoPartdo))
                {
                    lblCodigoInvalido.Visibility = Visibility.Visible;
                    return false;
                }
            }
            return true;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (verificaCampos())
            {
                Arquivo arq = new Arquivo();
                if (arq.existeCandidato(codigoCandidato))
                {
                    lblCandidatoCadastrado.Visibility = Visibility.Visible;
                }
                else
                {
                    arq.escreveCandidato(codigoCandidato, txtNome.Text.ToString(), codigoPartdo);
                    Sucesso sucess = new Sucesso();
                    sucess.Show();
                    this.Close();
                }
            }
        }
    }
}
