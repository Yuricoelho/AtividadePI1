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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
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
            lblCPFdigitos.Visibility = Visibility.Hidden;
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
                string candidatoNacional = arq.recuperaCandidato(codCandidato);
                string candidatoRegional = arq.recuperaCandidato(codCandidatoReg);
                int codPartido = candidatoNacional == string.Empty ? 0 : Convert.ToInt32(candidatoNacional.Split(';')[2]);
                int codPartidoReg = candidatoRegional == string.Empty ? 0 : Convert.ToInt32(candidatoRegional.Split(';')[2]);
                arq.escreveVoto(retornaUF(), CPF,0, codCandidato, codPartido, codCandidatoReg, codPartidoReg);
                Sucesso s = new Sucesso(Estado);
                s.Show();
                this.Close();
            }
        }

        private bool VerificaPreenchido()
        {
            PreparaTela();
            if (string.IsNullOrEmpty(txtCPF.Text) || (string.IsNullOrEmpty(txtVotacao.Text) && !chkBrancoN.IsChecked == true) || (string.IsNullOrEmpty(txtVotacaoRegional.Text) && !chkBrancoR.IsChecked == true))
            {
                if (string.IsNullOrEmpty(txtCPF.Text))
                {
                    lblCPFobrigatorio.Visibility = Visibility.Visible;
                }
                if (string.IsNullOrEmpty(txtVotacao.Text) && !chkBrancoN.IsChecked == true)
                {
                    lblVotoObrigatorio.Visibility = Visibility.Visible;
                }
                if (string.IsNullOrEmpty(txtVotacaoRegional.Text) && !chkBrancoR.IsChecked == true)
                {
                    lblVotoRegObrigatorio.Visibility = Visibility.Visible;
                }
                return false;
            }
            else
            {
                if (!long.TryParse(txtCPF.Text, out cpf))
                {
                    this.lblCPFvalidacao.Visibility = Visibility.Visible;
                    return false;
                }
                else
                {
                    if (txtCPF.Text.Length != 11)
                    {
                        this.lblCPFdigitos.Visibility = Visibility.Visible;
                        return false;
                    }
                    CPF = trataCPF(cpf.ToString());
                }
                if(!int.TryParse(txtVotacao.Text, out codCandidato) && chkBrancoN.IsChecked == false)
                {
                    lblVotoValidacao.Visibility = Visibility.Visible;
                    return false;
                }
                if (!int.TryParse(txtVotacaoRegional.Text, out codCandidatoReg) && chkBrancoR.IsChecked == false)
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
