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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;

namespace WPFpruebaCliente
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        string serverIp = "localhost";
        int port = 8080;

        public Login()
        {
            InitializeComponent();

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            TcpClient client = new TcpClient(serverIp, port);

            int byteCount =Encoding.ASCII.GetByteCount(usuario.Text + 1);

            Byte[] sendData = new byte[byteCount];

            sendData = Encoding.ASCII.GetBytes(usuario.Text + ";");

            NetworkStream stream = client.GetStream();

            stream.Write(sendData, 0, sendData.Length);

            stream.Close();
            client.Close();

        }
    }
}
