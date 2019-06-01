using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        
        static Socket listenerSocket;
        static List<ClientData> _clients;
        static ColeccionJugador listaEspera;

        
        static Mesa mesa; //esta es la que tiene las cartas comunes y las apuesta tiene la coleccion de jugadores 

        static bool bloquearJuego = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando el server en: " + Packet.GetIPAddress());//Muestra la direccion en que se va a empezar la conexion

            //Crea el nuevo socket que va a estar escuchando los mensajes de los clientes.
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _clients = new List<ClientData>();
            listaEspera = new ColeccionJugador(4);//4 Jugadores en espera
            
            mesa = new Mesa();// la mesa por defecto se crea para 4 jugadores 
           
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(Packet.GetIPAddress()), 4242);
            listenerSocket.Bind(ip);

            //Crear el thread listener
            Thread listenThread = new Thread(ListenThread);
            listenThread.Start();

        }


        //listener - listener for clients trying to connect
        static void ListenThread()
        {
            for (; ; )
            {
                listenerSocket.Listen(0);
                _clients.Add(new ClientData(listenerSocket.Accept()));
            }
        }

        
        //clientData thread recibe los datos de cada client indivualmente 
        public static void DATA_IN(object cSocket)
        {
            Socket clientSocket = (Socket)cSocket;

            byte[] Buffer;
            int readBytes;
            //Lee información de parte de clientes

            for (; ; )
            {

                try
                {
                    Buffer = new byte[clientSocket.SendBufferSize];
                    readBytes = clientSocket.Receive(Buffer);

                    if (readBytes > 0)
                    {
                        Packet packet = new Packet(Buffer);
                        DataManager(packet);

                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Un cliente se ha desconectado!");
                }
            }
        }

        //DataManager
        static void DataManager(Packet p)
        {
            switch (p.packetType)
            {
                
                case Packet.PacketType.IniciarJuego:
                    //Aca se deberia validar que hay 4 jugadores en la mesa
                    // la mesa llama al metodo repartir las 2 cartas comunes 
                    // cobra el minimo y maximo a los 2 jugaodres 

                    bloquearJuego = true;//No acepta más jugadores en el juego
                    
                    break;

               
            }
        }
    }
}
