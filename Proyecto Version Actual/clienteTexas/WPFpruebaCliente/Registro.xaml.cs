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

using System.Net.Sockets;
using Newtonsoft.Json;

namespace WPFpruebaCliente
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {

        string ipServer;
        int port;
        TcpClient clientSocket;

        public Registro(string ip, int p)
        {
            this.ipServer = ip;
            this.port = p;
            InitializeComponent();
        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {


            clientSocket = new TcpClient(ipServer, port); // hace la conexion de una vez 
            //esto se manda al Accept del server;

            Jugador j = new Jugador() { nombre = usuario.Text, contrasena = password.Text }; // agarrando los datos de form

            string jugadorJSON = JsonConvert.SerializeObject(j);

            //metodito papu 
            byte[] flujoBytes = Encoding.Default.GetBytes(jugadorJSON);

            NetworkStream stream = clientSocket.GetStream();

            stream.Write(flujoBytes, 0, flujoBytes.Length);

            //cierre de metodo papu como en una clase 


            //stream.Close();

            //respuesta.Text = // aquí pasar el texto de aceptación del servidor


            byte[] inStream = new byte[4099];
            int bytesRead = stream.Read(inStream, 0, inStream.Length);
            string returndata = Encoding.ASCII.GetString(inStream, 0, bytesRead);
            mensajeServer(returndata);


        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login(ipServer);
            l.Show();
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void mensajeServer(String mensaje)
        {
            respuesta.Text = respuesta.Text + Environment.NewLine + ">>" + mensaje;

        }








    }
}
