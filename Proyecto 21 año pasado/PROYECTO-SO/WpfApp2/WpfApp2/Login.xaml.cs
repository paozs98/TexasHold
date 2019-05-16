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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Login
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public static Socket master;
        public static string name;
        public static string id;
        public static bool autentificar = false;
        public static bool enEspera = false;
        public static string nombreUsuario;
        public static string clave;
        public static bool iniciarJuego = false;//Inicia el juego -- Es un boton
        public static bool abandonarJuego = false;
        public static int carta1;
        public static int carta2;
        public static string seguir;//Pregunta al usuario si quiere seguir jugando 

        //Variables referencia a la Casa
        public static int cartaCasa1;
        public static int cartaCasa2;
        public static int cartaCasa3;
        public static int cartaCasa4;

        public Login()
        {
            InitializeComponent();
        }

        private void autentificarse(object sender, RoutedEventArgs e)
        {
            LoginScreen l = new LoginScreen();
            l.Owner = this;
            l.ShowDialog();
        }
        private void registrarse(object sender, RoutedEventArgs e)
        {
            LoginScreen l = new LoginScreen();
            l.Owner = this;
            l.ShowDialog();
        }
    }
}
