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

namespace WPFpruebaCliente
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {

        string ipServer;
        int port;
        public Registro(string ip, int p)
        {
            this.ipServer = ip;
            this.port = p;
            InitializeComponent();
        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {




        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login(ipServer);
            l.Show();
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
