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
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            PreparaTela();
            Arquivo arq = new Arquivo();
            if (arq.adminCadastrado())
            {
                this.isCadastro = false;
                PreparaLogin();
            }
            else
            {
                this.isCadastro = true;
                PreparaRegistro();
            }
        }

        private bool isCadastro;
        private string senha;
        private string novaSenha;

        private void PreparaTela()
        {
            this.txtPassword.Visibility = Visibility.Hidden;
            this.txtNovaSenha.Visibility = Visibility.Hidden;
            this.txtConfirmaNovaSenha.Visibility = Visibility.Hidden;
            this.lblSenha.Visibility = Visibility.Hidden;
            this.lblNovaSenha.Visibility = Visibility.Hidden;
            this.lblConfirmaNovaSenha.Visibility = Visibility.Hidden;
            this.lblSenhaInvalida.Visibility = Visibility.Hidden;
            this.lblConfirmaErro.Visibility = Visibility.Hidden;
        }

        private void PreparaRegistro()
        {
            this.lblNovaSenha.Visibility = Visibility.Visible;
            this.txtNovaSenha.Visibility = Visibility.Visible;
            this.lblConfirmaNovaSenha.Visibility = Visibility.Visible;
            this.txtConfirmaNovaSenha.Visibility = Visibility.Visible;
        }

        private void PreparaLogin()
        {
            this.lblSenha.Visibility = Visibility.Visible;
            this.txtPassword.Visibility = Visibility.Visible;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (isCadastro)
            {
                if (txtNovaSenha.Password == txtConfirmaNovaSenha.Password)
                {
                    Arquivo arq = new Arquivo();
                    arq.gravaSenha(txtNovaSenha.Password);
                    Admin ad = new Admin();
                    ad.Show();
                    this.Close();
                }
                else
                {
                    lblConfirmaErro.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Arquivo arq = new Arquivo();
                if (arq.verificaSenha(txtPassword.Password))
                {
                    Admin ad = new Admin();
                    ad.Show();
                    this.Close();
                }
                else
                {
                    lblSenhaInvalida.Visibility = Visibility.Visible;
                }
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            senha = txtPassword.Password;
        }

        private void txtNovaSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            senha = txtNovaSenha.Password;
        }

        private void txtConfirmaNovaSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            novaSenha = txtConfirmaNovaSenha.Password;
        }
    }
}
