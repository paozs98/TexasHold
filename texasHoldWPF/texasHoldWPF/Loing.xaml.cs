﻿using System;
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

namespace texasHoldWPF
{
    /// <summary>
    /// Lógica de interacción para Loing.xaml
    /// </summary>
    public partial class Loing : Window
    {
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
            Mesa m = new Mesa();
            m.Show();
            Close();
        }
    }
}
