﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemServer {
    class Jugador {

        protected ColeccionCartas myHand = new ColeccionCartas();
        protected string nombre;
        protected int dineroInicial;
        protected int apuesta;
        protected int dineroActual;
        protected bool mostrarCartas;


        public void SetNombre(string n) {
            nombre = n;
        }
        public void SetMostrarCartas(bool mo) {
            mostrarCartas = mo;
        }
        public void SetDineroActual(int actual) {
            dineroActual = actual;
        }

        public void SetApuesta(int ap) {
            apuesta = ap;
        }

        public void SetDineroInicial(int i) {
            dineroInicial = i;
        }

        public void SetMano(ColeccionCartas nue) {
            myHand = nue;
        }
        public int GetDineroInicial() {
            return dineroInicial;
        }
        public bool IsMostrarCartas() {
            return mostrarCartas;
        }
        public int GetDineroActual() {
            return dineroActual;
        }
        public int getApuesta() {
            return apuesta;
        }
        public string GetNombre() {
            return nombre;
        }
        public ColeccionCartas GetMano() {
            return myHand;
        }
        public void AgregarMano(ColeccionCartas mano) {
            myHand += mano;
        }

        public void AgregarMano(Carta carta) {
            myHand.Agregar_Carta(carta);
        }

        public void MostrarCartas() {
            mostrarCartas = true;
        }

        public Jugador() {
            try {
                string ip = "192.168.12.12"; //Direccion ip del server

                IPAddress ipAd = IPAddress.Parse(ip);

                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting...");

                tcpclnt.Connect(ip, 8010);

                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");

                String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting...");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                Console.Read();
                tcpclnt.Close();
            } catch (Exception e) {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.Read();
            }
        }

    }
}
