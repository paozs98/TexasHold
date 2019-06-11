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
        int numRonda;


        public MainWindow(Jugador j, TcpClient c, Mesa m)
        {
            this.jugador = j;
            this.clientSocket = c;
            this.mesa = m;
            this.numRonda = 0;
            InitializeComponent();
           
        }


        public MainWindow()
        {
            InitializeComponent();
        }


        private void primeraRonda() {
            if (!mesa.cartasComunes.isVacio()) {
                setImagenCm1(mesa.cartasComunes.obtenerCarta(0).getCodigo());
                setImagenCm2(mesa.cartasComunes.obtenerCarta(0).getCodigo());
                setImagenCm3(mesa.cartasComunes.obtenerCarta(0).getCodigo());
                
            }
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(0).mano.obtenerCarta(0).getCodigo());
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(0).mano.obtenerCarta(1).getCodigo());
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(1).mano.obtenerCarta(0).getCodigo());
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(1).mano.obtenerCarta(1).getCodigo());
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(2).mano.obtenerCarta(0).getCodigo());
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(2).mano.obtenerCarta(1).getCodigo());
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(3).mano.obtenerCarta(0).getCodigo());
            //setImagenJ1c1(mesa.jugadores.GetJugadorEnLaPos(3).mano.obtenerCarta(1).getCodigo());


        }

        //private string recibirDatos() {
        //    byte[] inStream = new byte[4099];
        //    int bytesRead = stream.Read(inStream, 0, inStream.Length);
        //    return Encoding.ASCII.GetString(inStream, 0, bytesRead);


        //}

        //private void cargarRonda() {
        //    switch (numRonda) {
        //        case 1: {
        //                cargarCartasRonda1();
        //                break;
        //            }
        //        case 2: {
        //                cargarCartasRonda2();
        //                break;
        //            }
        //        case 3: {
        //                cargarCartasRonda3();
        //                break;
        //            }
        //        default: break;
        //    }

        //}

        //private void cargarCartasRonda1()
        //{

        //    setImagenCm1(mesa.cartasComunes.obtenerCarta(1).getCodigo());
        //    setImagenCm2(mesa.cartasComunes.obtenerCarta(2).getCodigo());
        //    setImagenCm3(mesa.cartasComunes.obtenerCarta(3).getCodigo());

        //}

        //private void cargarCartasRonda2() {
        //    setImagenCm4(mesa.cartasComunes.obtenerCarta(4).getCodigo());


        //}

        //private void cargarCartasRonda3() {
        //    setImagenCm5(mesa.cartasComunes.obtenerCarta(5).getCodigo());


        //}
        //corregir
        //para prueba
        private void setImagenCm1(string carta) { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource= new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\"+carta+".png", UriKind.Relative));
            cm1.Fill = img;
        }
        private void setImagenCm2(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            cm2.Fill = img;
        }
        private void setImagenCm3(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            cm3.Fill = img;
        }
        private void setImagenCm4(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            cm4.Fill = img;
        }
        private void setImagenCm5(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            cm1.Fill = img;
        }
        private void setImagenJ1c1(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            j1c1.Fill = img;
        }
        private void setImagenJ1c2(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            j1c2.Fill = img;
        }
        private void setImagenJ2c1(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            j2c2.Fill = img;
        }
        private void setImagenJ3c1(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            j3c1.Fill = img;
        }
        private void setImagenJ3c2(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            j3c2.Fill = img;
        }
        private void setImagenJ4c1(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            j4c1.Fill = img;
        }
        private void setImagenJ4c2(string carta)
        { //el nombre es la posición de la imagen,
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\cartas\\" + carta + ".png", UriKind.Relative));
            j4c2.Fill = img;
        }


        private void setTextBlock( TextBlock block, string mensaje)
        {
            block.Text = mensaje;
        }

        private void Ronda_Click(object sender, RoutedEventArgs e)
        {
            numRonda++;
            primeraRonda();
        }


        //private void mensajeServer(String mensaje)
        //{
        //    respuesta.Text = respuesta.Text + Environment.NewLine + ">>" + mensaje;

        //}




    }
}
