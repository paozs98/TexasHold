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

namespace texasHoldWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Texas Hold";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {

            //En esta parte se debe imbocar la parte de Login
            MessageBox.Show("Ingresando a la sala ");
            this.Close();
        }
    }
}
