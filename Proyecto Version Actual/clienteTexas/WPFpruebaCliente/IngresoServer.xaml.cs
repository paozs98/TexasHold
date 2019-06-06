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
    
    public partial class IngresoServer : Window
    {
        public IngresoServer()
        {
            InitializeComponent();
        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login(IpAddress.Text);
            l.Show();
            Close();
        }
    }
}
