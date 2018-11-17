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

namespace ProjetoIntegradorI.Eleitor
{
    /// <summary>
    /// Interaction logic for Eleitor.xaml
    /// </summary>
    public partial class Eleitor : Window
    {
        public Eleitor()
        {
            InitializeComponent();
        }
        public Eleitor(string estado) : this()
        {
            this.Estado = estado;
            lblEstado.Content += estado;
            this.PreparaTela();
        }

        private string Estado;
        private string UF;
        private long cpf;
        private string CPF;
        private int codCandidato;
        private int codCandidatoReg;
        private int codPartidoFederal;
        private int codPartidoregional;
        private int codMunicipio = 0;

        private void PreparaTela()
        {
            lblCPFobrigatorio.Visibility = Visibility.Hidden;
            lblVotoObrigatorio.Visibility = Visibility.Hidden;
            lblVotoRegObrigatorio.Visibility = Visibility.Hidden;
            lblCPFvalidacao.Visibility = Visibility.Hidden;
            lblVotoValidacao.Visibility = Visibility.Hidden;
            lblVotoRegValidacao.Visibility = Visibility.Hidden;
        }

        private void chkBrancoN_Checked(object sender, RoutedEventArgs e)
        {
            txtVotacao.IsEnabled = !txtVotacao.IsEnabled;
        }

        private void chkBrancoR_Checked(object sender, RoutedEventArgs e)
        {
            txtVotacaoRegional.IsEnabled = !txtVotacaoRegional.IsEnabled;
        }

        private void voltar_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Close();
        }

        private void confirma_Click(object sender, RoutedEventArgs e)
        {
            if (VerificaPreenchido())
            {
                Arquivo arq = new Arquivo();
                arq.escreveVoto(retornaUF(), CPF, 0, codCandidato, 0, codCandidatoReg, 0);
                Sucesso s = new Sucesso(Estado);
                s.Show();
                this.Close();
            }
        }

        private bool VerificaPreenchido()
        {
            PreparaTela();
            if (string.IsNullOrEmpty(txtCPF.Text) || string.IsNullOrEmpty(txtVotacao.Text) || string.IsNullOrEmpty(txtVotacaoRegional.Text))
            {
                if (string.IsNullOrEmpty(txtCPF.Text))
                {
                    lblCPFobrigatorio.Visibility = Visibility.Visible;
                }
                if (string.IsNullOrEmpty(txtVotacao.Text))
                {
                    lblVotoObrigatorio.Visibility = Visibility.Visible;
                }
                if (string.IsNullOrEmpty(txtVotacaoRegional.Text))
                {
                    lblVotoRegObrigatorio.Visibility = Visibility.Visible;
                }
                return false;
            }
            else
            {
                if (!long.TryParse(txtCPF.Text, out cpf))
                {
                    lblCPFvalidacao.Visibility = Visibility.Visible;
                    return false;
                }
                else
                {
                    CPF = trataCPF(cpf.ToString());
                }
                if(!int.TryParse(txtVotacao.Text, out codCandidato) && chkBrancoN.IsChecked == false)
                {
                    lblVotoValidacao.Visibility = Visibility.Visible;
                    return false;
                }
                if (!int.TryParse(txtVotacaoRegional.Text, out codCandidatoReg))
                {
                    lblVotoRegValidacao.Visibility = Visibility.Visible;
                    return false;
                }
            }
            return true;
        }
        static private string trataCPF(string CPF)
        {
            if (CPF.Length < 11)
            {
                int n = Math.Abs(11 - CPF.Length);
                for (int i = 0; i < n; i++)
                {
                    CPF = "0" + CPF;
                }
            }
            string cpfsub1 = CPF.Substring(0, 3);
            string cpfsub2 = CPF.Substring(3, 3);
            string cpfsub3 = CPF.Substring(6, 3);
            string digito = CPF.Substring(9, 2);
            CPF = cpfsub1 + "." + cpfsub2 + "." + cpfsub3 + "-" + digito;
            return CPF;
        }

        private string retornaUF()
        {
            if (Estado.Contains("Paraná"))
                return "PR";
            if (Estado.Contains("Santa Catarina"))
                return "SC";
            if (Estado.Contains("Rio Grande do Sul"))
                return "RS";

            return string.Empty;
        }

    }
}
