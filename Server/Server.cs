using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        static ColeccionJugador cj;//Aca tiene que entrar todos los jugadores de la bd 

        static Socket listenerSocket;
        static List<ClientData> _clients;
        static ColeccionJugador listaEspera;

        static int numTurno = 0;
        static string turnoAux = "";
        static bool bloquearJuego = false;
        static private Mesa mesa; //esta es la que tiene las cartas comunes y las apuesta 


        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando el server en: " + Packet.GetIPAddress());//Muestra la direccion en que se va a empezar la conexion

            //Crea el nuevo socket que va a estar escuchando los mensajes de los clientes.
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Crea la lista de clientes, en este caso llegaría hasta 4, las demás conexiones van a la lista de espera.
            _clients = new List<ClientData>();
            cj = new ColeccionJugador(4);//Cargar elementos de la BD

            listaEspera = new ColeccionJugador(4);//4 Jugadores en espera
            cj.agregarJugador(new Jugador("usuario1", "usuario1"));
            
            mesa = new Mesa();// la mesa por defecto se crea para 4 jugadores 

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

        //clientData thread . receives data from each clien individually
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


                        if (packet.packetType == Packet.PacketType.Mensaje)
                        {
                            Console.WriteLine(packet.nombre + " " + packet.id + " -> " + packet.apuesta);
                        }

                        else if (packet.packetType == Packet.PacketType.darAcceso || packet.packetType == Packet.PacketType.denegarAcceso)
                        {
                            //DataManager(packet);//En caso de dar acceso se comienza a dar los turnos de juego
                        }
                        else if (packet.packetType == Packet.PacketType.comunicarTurno)
                        {
                            Console.WriteLine("Turno de jugador: " + packet.turno);
                        }

                    }
                }
                catch (SocketException ex)
                {
                    //Console.WriteLine("A client disconnected!");
                }
            }
        }

        //DataManager
        static void DataManager(Packet p)
        {
            switch (p.packetType)
            {
                case Packet.PacketType.Chat:
                    foreach (ClientData c in _clients)
                    {
                        c.clientSocket.Send(p.ToBytes());
                    }
                    break;

                case Packet.PacketType.Mensaje:
                    foreach (ClientData c in _clients)
                    {
                        c.clientSocket.Send(p.ToBytes());
                    }
                    break;

                case Packet.PacketType.autentificar:
                    if (cj.VerificarJugador(p.clave))//Si existe en el juego
                    {
                        if (mesa.getJugadores().getCantidad() < 4 && (!bloquearJuego))
                        {

                            mesa.getJugadores().agregarJugador(new Jugador(p.nombre, p.clave));
                            p.packetType = Packet.PacketType.darAcceso;
                            p.estado = "Acceso aprobado";
                            Console.WriteLine("Jugadores actuales:");
                            mesa.getJugadores().imprimirColeccion();
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            listaEspera.agregarJugador(new Jugador(p.nombre, p.clave));
                            Console.WriteLine("Jugador en espera: " + p.nombre);
                            p.packetType = Packet.PacketType.enEspera;
                            p.estado = "Ha sido puesta en lista de espera...\nEsperando....";
                        }

                    }
                    else
                    {
                        p.packetType = Packet.PacketType.denegarAcceso;
                        p.estado = "Acceso denegado";
                    }
                    foreach (ClientData c in _clients)
                    {
                        c.clientSocket.Send(p.ToBytes());
                    }
                    Console.WriteLine("Estado de acceso del jugador recien agregado: " + p.estado);
                    break;



                case Packet.PacketType.registrar:
                    if (mesa.getJugadores().getCantidad() < 4 && (!bloquearJuego))
                    {

                        //mesa.getJugadores().agregarJugador(new Jugador(p.nombre, p.clave));
                        //p.packetType = Packet.PacketType.darAcceso;
                        //p.estado = "Acceso aprobado";
                        //Console.WriteLine("Jugadores actuales:");
                        //mesa.getJugadores().imprimirColeccion();
                        //Console.WriteLine("\n");
                    }
                    else
                    {
                        ////Se agrega a la lista de espera
                        //listaEspera.agregarJugador(new Jugador(p.nombre, p.clave));
                        //Console.WriteLine("Jugador en espera: " + p.nombre);
                        //p.packetType = Packet.PacketType.enEspera;
                        //p.estado = "Ha sido puesta en lista de espera...\nEsperando....";
                    }
                    foreach (ClientData c in _clients)
                    {
                        c.clientSocket.Send(p.ToBytes());
                    }
                    Console.WriteLine("Estado de acceso de registro: " + p.estado);
                    break;


                case Packet.PacketType.iniciarJuego://Se recibe la señal de iniciar juego del jugador
                    bloquearJuego = true;//No acepta más jugadores en el juego


                    //repartir primeras 2 cartas a todos los jugadores
                    for (int i = 0; i < mesa.getJugadores().getCantidad(); i++)
                    {
                        //p.packetType = Packet.PacketType.primerasCartas;
                        //p.carta1 = mesa.getMazo().darCarta(mesa.getJugadores().obtenerJugador(i).GetMano());
                        //p.carta2 = mesa.getMazo().darCarta(mesa.getJugadores().obtenerJugador(i).GetMano());

                        //p.nombre = mesa.getJugadores().obtenerJugador(i).getNombre();//obtiene el nombre del jugador
                        //p.packetType = Packet.PacketType.iniciarJuego;
                        //Console.WriteLine("Asignar-> Jugador: " + p.nombre + ", C1: " + p.carta1 + ", C2: " + p.carta2);
                        //foreach (ClientData c in _clients)
                        //{
                        //    c.clientSocket.Send(p.ToBytes());
                        //}
                    }

                    if (numTurno < mesa.getJugadores().getCantidad())
                    {
                        //p.packetType = Packet.PacketType.comunicarTurno;//Comunica el primer turno
                        //p.turno = mesa.getJugadores().obtenerJugador(numTurno).getNombre();
                        //Console.WriteLine("Turno de jugador: " + p.turno);
                        //numTurno++;//Va al turno del jugador 0

                        //foreach (ClientData c in _clients)
                        //{
                        //    c.clientSocket.Send(p.ToBytes());
                        //}//Comunica el primer turno
                    }
                    break;//Envia todas las primeras dos cartas a todos los jugadores identificados con el nombre



                

                //Si el tipo es de autentificacion se add a la lista de sockets
                //una vez autentificado y se crea un nuevo jugador asociado a 
                //ese id.

                case Packet.PacketType.salir:
                    //Console.WriteLine("**************************************");
                    //Console.WriteLine("Id recibido: " + p.id);
                    //mesa.getJugadores().imprimirColeccion();
                    //mesa.getJugadores().eliminarJugador(p.id);
                    //Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");
                    //mesa.getJugadores().imprimirColeccion();
                    //Console.WriteLine("**************************************");
                    //bloquearJuego = false;
                    //if (listaEspera.obtenerCantidad() > 0)
                    //{
                    //    jugador jug = listaEspera.obtenerJugador(0);
                    //    listaEspera.eliminarJugador(jug.getId());//Sale de la lista de espera
                    //    mesa.getJugadores().agregarJugador(jug);//Entra al juego
                    //    p.packetType = Packet.PacketType.darAcceso;
                    //    p.estado = "Acceso aprobado";
                    //    Console.WriteLine("Jugadores actuales:");
                    //    mesa.getJugadores().imprimirColeccion();
                    //    Console.WriteLine("\n");
                    //    //Envia el paquete con el acceso
                    //    foreach (ClientData c in _clients)
                    //    {
                    //        c.clientSocket.Send(p.ToBytes());
                    //    }
                    //    Console.WriteLine("Estado de acceso de registro: " + p.estado);
                    //}

                    break;



                case Packet.PacketType.seguir:
                    //Console.WriteLine("Bien! El jugador " + p.nombre + " va a seguir jugando!");
                    //p.packetType = Packet.PacketType.darAcceso;
                    //p.estado = "Acceso aprobado";
                    //Console.WriteLine("Jugadores actuales:");
                    //mesa.getJugadores().imprimirColeccion();
                    //Console.WriteLine("\n");
                    //foreach (ClientData c in _clients)
                    //{
                    //    c.clientSocket.Send(p.ToBytes());
                    //}
                    //Console.WriteLine("Estado de acceso de registro: " + p.estado);
                    break;
            }
        }
    }
}
