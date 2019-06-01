
using ClientePrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Cliente
{
    public class Cliente
    {

        public static Socket master;
        public static string id; // de la clase no borrar
        public static string name;

        public static bool autentificar = false;
        public static string nombreUsuario;
        public static string clave;

        public static bool iniciarJuego = false;//Inicia el juego -- Es un boton
        public static bool abandonarJuego = false;

        public static int carta1;
        public static int carta2;

        public static string seguir;
        public static bool enEspera = false;

        public static int cartaM1;
        public static int cartaM2;
        public static int cartaM3;
        public static int cartaM4;
        public static int cartaM5;

        static void DATA_IN()
        {
            byte[] Buffer;
            int readBytes;

            for (; ; )
            {

                try
                {
                    Buffer = new byte[master.SendBufferSize];
                    readBytes = master.Receive(Buffer);

                    if (readBytes > 0)
                    {
                        DataManager(new Packet(Buffer));
                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("El servidor se ha desconectado!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }

        static void Main(string[] args)
        {
            
        A: Console.Clear();
            Console.WriteLine("Dijite el numero de IP:\n");
            string ip = Console.ReadLine();

            Console.Write("Introduzca su nombre:\n");
            name = Console.ReadLine();

            master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ips = new IPEndPoint(IPAddress.Parse(ip), 4242);

            try
            {
                master.Connect(ips);
            }
            catch
            {
                Console.WriteLine("No se pudo conectar al servidor!");
                Thread.Sleep(1000);
                goto A;
            }

            Thread t = new Thread(DATA_IN);
            t.Start();

            for (; ; )
            {

            
                

            }
        }


        

        static void DataManager(Packet p)
        {

            switch (p.packetType)
            {


                case Packet.PacketType.Registration:
                    id = p.Gdata[0];
                    break;


            }
        }
    }
}
