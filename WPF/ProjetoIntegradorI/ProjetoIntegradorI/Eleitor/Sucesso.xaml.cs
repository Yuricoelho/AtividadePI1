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
    /// Lógica interna para Sucesso.xaml
    /// </summary>
    public partial class Sucesso : Window
    {
        public Sucesso()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        public Sucesso(string estado)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.Estado = estado;
        }

        private string Estado;

        private void btnContinuar_Click(object sender, RoutedEventArgs e)
        {
            Eleitor el = new Eleitor(Estado);
            el.Show();
            this.Close();
        }
    }
}
