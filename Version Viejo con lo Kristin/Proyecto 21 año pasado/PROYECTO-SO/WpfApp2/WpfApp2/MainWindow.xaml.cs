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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Hola Mundo");
            iniciarTablero();
        }

        private String pasarNumero() {
            return "";
        }

        private void iniciarTablero() {
            j1c1T.Text = pasarNumero();
            j1c2T.Text = pasarNumero();
            j1c3T.Text = pasarNumero();
            j1c4T.Text = pasarNumero();
            j2c1T.Text = pasarNumero();
            j2c2T.Text = pasarNumero();
            j2c3T.Text = pasarNumero();
            j2c4T.Text = pasarNumero();
            j3c1T.Text = pasarNumero();
            j3c2T.Text = pasarNumero();
            j3c3T.Text = pasarNumero();
            j3c4T.Text = pasarNumero();
            j4c1T.Text = pasarNumero();
            j4c2T.Text = pasarNumero();
            j4c3T.Text = pasarNumero();
            j4c4T.Text = pasarNumero();
            j5c1T.Text = pasarNumero();
            j5c2T.Text = pasarNumero();
            j5c3T.Text = pasarNumero();
            j5c4T.Text = pasarNumero();
            j6c1T.Text = pasarNumero();
            j6c2T.Text = pasarNumero();
            j6c3T.Text = pasarNumero();
            j6c4T.Text = pasarNumero();
            j7c1T.Text = pasarNumero();
            j7c2T.Text = pasarNumero();
            j7c3T.Text = pasarNumero();
            j7c4T.Text = pasarNumero();
            casac1T.Text = pasarNumero();
            casac2T.Text = pasarNumero();
            casac3T.Text = pasarNumero();
            casac4T.Text = pasarNumero();
        }
    }
}
