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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;



namespace WPFpruebaCliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Mesa mesa;
        Jugador jugador;
        TcpClient clientSocket;
        NetworkStream stream;


        public MainWindow(Jugador j, NetworkStream s)
        {
            this.jugador = j;
            this.stream = s;
            InitializeComponent();
            cargarCartasRonda1();
        }


        private void sendData() {
                        
            string jugadorJSON = JsonConvert.SerializeObject(jugador);

            //metodito papu 
            byte[] flujoBytes = Encoding.Default.GetBytes(jugadorJSON);

            NetworkStream stream = clientSocket.GetStream();

            stream.Write(flujoBytes, 0, flujoBytes.Length);


        }


        private string recibirDatos() {
            byte[] inStream = new byte[4099];
            int bytesRead = stream.Read(inStream, 0, inStream.Length);
            return Encoding.ASCII.GetString(inStream, 0, bytesRead);
   

        }

        private void cargarCartasRonda1() {
            //recuperar las cartas del jugador 


             // recuperar las cartas de la primera ronda
            

        }

        private void cargarCartasRonda2() {


        }

        private void cargarCartasRonda3() {


        }
        //corregir
        private void setImagen(System.Windows.Rect nombre, string carta, int i) { //el nombre es la posición de la imagen,
            //la carta es para cargar el con la dirección de la carta 
            ImageBrush img = new ImageBrush();
//            string im = mesa.cartasComunes.VEC[i].palo + mesa.cartasComunes.VEC[i].valor;
  //          img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\imagenes\\"++".png",UriKind.Relative))
    //            nombre.Fill = img;

        }

        

        private void mensajeServer(String mensaje)
        {
            respuesta.Text = respuesta.Text + Environment.NewLine + ">>" + mensaje;

        }




    }
}
