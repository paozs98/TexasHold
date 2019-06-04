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
        int port = 8080;
        string ipaddress = "127.0.0.1";
        Socket ClientSocket;

        public Login()
        {
            InitializeComponent();
            inicializar();
        }

        public void inicializar() { // para conectar
            ClientSocket = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipaddress), port);
            ClientSocket.Connect(ep);
        }


        public void Ingresar_Click(object sender, RoutedEventArgs e) {
            string mensajeUsuario = usuario.Text;
            ClientSocket.Send(System.Text.Encoding.ASCII.GetBytes(mensajeUsuario), 0, mensajeUsuario.Length, SocketFlags.None);

            byte[] MsgFromServer = new byte[1024];
            int size = ClientSocket.Receive(MsgFromServer);





        }




        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
