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
using System.Text.RegularExpressions;
using System.Data;

namespace texasHoldWPF
{
    /// <summary>
    /// Lógica de interacción para Loing.xaml
    /// </summary>
    public partial class Loing : Window
    {


        public static string user="No indicado";
        public static string clave = "No indicado";
        public Loing()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            if (usuario.Text.Length!= 0) {
                if (password.Text.Length != 0)
                {
                    user = usuario.Text;
                    clave = password.Text;

                    Mesa m = new Mesa();
                    m.Show();
                    Close();
                }
                else {



                }
            }
            else{
            }
        }
    }
}
