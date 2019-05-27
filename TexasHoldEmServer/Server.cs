using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//clase principal la que maneja los datos Packet de los que de los jugadores
namespace TexasHoldemServer {
    class Server
    {

        static ListaJugadores cj;

        static Socket listenerSocket;
        static List<ClientData> _clients;
        static ListaJugadores listaEspera;



        static int numTurno = 0;
        static String turnoAux = "";
        static bool bloquearJuego = false; //Se pone en false cuando el juego termina

        static private Juego game;

        static void Main(string[] args)
        {

            Console.WriteLine("Starting server on " + Packet.GetIPAddress());//Muestra la direccion en que se va a empezar la conexion
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Crea el nuevo socket que va a estar escuchando los mensajes de los clientes.

            _clients = new List<ClientData>();
            cj = new ListaJugadores(4);//Cargar elementos de la BD
            listaEspera = new ListaJugadores(25);//25 Jugadores en espera
            cj.Add(new Jugador("Majid"));
            //int elementosBD = baseDatos.cantidad();
            //cj = new coleccionJugador(elementosBD);
            game = new Juego(4);


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


        //clientData thread . receives data from each client individually
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

                    //Validar por acá que la casa aún no haya perdido

                    if (readBytes > 0)
                    {
                        Packet packet = new Packet(Buffer);
                        DataManager(packet);


                        if (packet.packetType == Packet.PacketType.Mensaje)
                        {
                            Console.WriteLine(packet.nombre + " " + packet.id + " -> " + packet.apuesta);
                        }
                        else if (packet.packetType == Packet.PacketType.pedirCarta || packet.packetType == Packet.PacketType.darCarta)
                        {
                            Console.WriteLine("Id: " + packet.id + "--> Nombre: " + packet.nombre);
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

        //data manager

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
                    if (cj.Contains(p))//Si existe en el juego
                    {
                        if (game.getJugadores().obtenerCantidad() < 7 && (!bloquearJuego))
                        {

                            game.getJugadores().agregarJugador(new Jugador(p.nombre));
                            p.packetType = Packet.PacketType.darAcceso;
                            p.estado = "Acceso aprobado";
                            Console.WriteLine("Jugadores actuales:");
                            game.getJugadores().imprimirColeccion();
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            listaEspera.Add(new Jugador(p.nombre));
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
                    if (game.getJugadores().obtenerCantidad() < 4 && (!bloquearJuego))
                    {

                        game.getJugadores().agregarJugador(new Jugador(p.nombre));
                        p.packetType = Packet.PacketType.darAcceso;
                        p.estado = "Acceso aprobado";
                        Console.WriteLine("Jugadores actuales:");
                        game.getJugadores().imprimirColeccion();
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        //Se agrega a la lista de espera
                        listaEspera.Add(new Jugador(p.nombre));
                        Console.WriteLine("Jugador en espera: " + p.nombre);
                        p.packetType = Packet.PacketType.enEspera;
                        p.estado = "Ha sido puesta en lista de espera...\nEsperando....";
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
                    p.cartaCasa1 = game.getBaraja().darCarta(game.getCasa().obtenerMano());
                    p.cartaCasa2 = game.getBaraja().darCarta(game.getCasa().obtenerMano());
                    for (int i = 0; i < game.getJugadores().cantidadJugadores(); i++)
                    {
                        p.packetType = Packet.PacketType.primerasCartas;
                        p.carta1 = game.getBaraja().darCarta(game.getJugadores().obtenerJugador(i).obtenerMano());
                        p.carta2 = game.getBaraja().darCarta(game.getJugadores().obtenerJugador(i).obtenerMano());
                        p.nombre = game.getJugadores().obtenerJugador(i).getNombre();//obtiene el nombre del jugador
                        p.packetType = Packet.PacketType.iniciarJuego;
                        Console.WriteLine("Asignar-> Jugador: " + p.nombre + ", C1: " + p.carta1 + ", C2: " + p.carta2);
                        foreach (ClientData c in _clients)
                        {
                            c.clientSocket.Send(p.ToBytes());
                        }
                    }

                    if (numTurno < game.getJugadores().obtenerCantidad())
                    {
                        p.packetType = Packet.PacketType.comunicarTurno;//Comunica el primer turno
                        p.turno = game.getJugadores().obtenerJugador(numTurno).getNombre();
                        Console.WriteLine("Turno de jugador: " + p.turno);
                        numTurno++;//Va al turno del jugador 0

                        foreach (ClientData c in _clients)
                        {
                            c.clientSocket.Send(p.ToBytes());
                        }//Comunica el primer turno
                    }
                    break;//Envia todas las primeras dos cartas a todos los jugadores identificados con el nombre





                case Packet.PacketType.pedirCarta:
                    string idJugador = p.id;
                    int j = game.getJugadores().posJugadorEspecifico(idJugador);//Busca posicion del jugador
                    if (j != -1)
                    {
                        p.numeroCarta = game.getBaraja().cartaAdicional(game.getJugadores().obtenerJugador(j));
                        //Console.WriteLine("Carta pedida: " + p.numeroCarta);//Imprimo la carta pedido
                    }
                    if (p.numeroCarta != -1)
                    {//Si aun no se ha pasado de 21
                        p.packetType = Packet.PacketType.darCarta;//Da la carta al jugador
                        foreach (ClientData c in _clients)
                        {
                            c.clientSocket.Send(p.ToBytes());
                        }
                    }

                    else
                    {//Pasa al jugador siguiente
                        numTurno++;
                        if (numTurno < game.getJugadores().obtenerCantidad())
                        {
                            p.packetType = Packet.PacketType.comunicarTurno;

                            p.turno = game.getJugadores().obtenerJugador(numTurno).getNombre();
                            foreach (ClientData c in _clients)
                            {
                                c.clientSocket.Send(p.ToBytes());
                            }
                        }
                        else
                        {
                            //Turno de jugar la casa y terminar el juego
                            int aux = game.getBaraja().cartaAdicionalCasa(game.getCasa());
                            while (aux != -1)
                            {
                                p.numeroCarta = aux;
                                p.packetType = Packet.PacketType.turnoCasa;//Pasa el numero de carta adicional de la casa a los clientes
                                foreach (ClientData c in _clients)
                                {
                                    c.clientSocket.Send(p.ToBytes());
                                }
                                aux = game.getBaraja().cartaAdicionalCasa(game.getCasa());
                                //Después de enviar todos los valores de la casa, hay que hacer la comparación
                            }
                            p.packetType = Packet.PacketType.casaAcabo;
                            foreach (ClientData c in _clients)
                            {
                                c.clientSocket.Send(p.ToBytes());
                            }
                            //Anuncia los ganadores y las cartas que obtuvo la casa
                            //Actualiza las apuestas
                        }
                    }
                    Console.WriteLine("Turno de jugador: " + p.turno);
                    break;

                case Packet.PacketType.quedarse:
                    //Acá se tacha al jugador como que ya se quedó
                    // ......

                    //Comunica el turno del siguiente jugador
                    if (numTurno < game.getJugadores().obtenerCantidad())
                    {
                        p.packetType = Packet.PacketType.comunicarTurno;//Comunica el primer turno
                        p.turno = game.getJugadores().obtenerJugador(numTurno).getNombre();
                        Console.WriteLine("Turno de jugador: " + p.turno);
                        numTurno++;//Guarda el turno del proximo jugador

                        foreach (ClientData c in _clients)
                        {
                            c.clientSocket.Send(p.ToBytes());
                        }//Comunica el siguiente turno
                        //DataManager(p);//Pasa a comunicarSiguiente turno
                    }
                    else
                    {
                        //Turno de jugar la casa y terminar el juego
                        int aux = game.getBaraja().cartaAdicionalCasa(game.getCasa());
                        while (aux != -1)
                        {
                            p.numeroCarta = aux;
                            p.packetType = Packet.PacketType.turnoCasa;//Pasa el numero de carta adicional de la casa a los clientes
                            foreach (ClientData c in _clients)
                            {
                                c.clientSocket.Send(p.ToBytes());
                            }
                            aux = game.getBaraja().cartaAdicionalCasa(game.getCasa());
                            //Después de enviar todos los valores de la casa, hay que hacer la comparación
                        }

                        p.packetType = Packet.PacketType.casaAcabo;
                        numTurno = 0;

                        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        if (game.getCasa().pasoDe21())
                        {
                            for (int i = 0; i < game.getJugadores().obtenerCantidad(); ++i)
                            {
                                if (!(game.getJugadores().obtenerJugador(i).pasoDe21()))
                                {
                                    game.getJugadores().obtenerJugador(i).gana();
                                    p.estado = "Ganador";
                                }
                                else
                                {//Casa y jugador pasaron de 21
                                    game.getJugadores().obtenerJugador(i).pierde();
                                    p.estado = "Perdedor";
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < game.getJugadores().obtenerCantidad(); ++i)
                            {
                                if (!game.getJugadores().obtenerJugador(i).pasoDe21())
                                {
                                    if (game.getJugadores().obtenerJugador(i).obtenerMano().ObtenerTotal() > game.getCasa().obtenerMano().ObtenerTotal())
                                    {
                                        game.getJugadores().obtenerJugador(i).gana();
                                        p.estado = "Ganador";
                                    }
                                    else if (game.getJugadores().obtenerJugador(i).obtenerMano().ObtenerTotal() < game.getCasa().obtenerMano().ObtenerTotal())
                                    {
                                        // ganador(IdJugador, 1 -> perdió, saldoActualizado);
                                        //Se verifica si el saldo es 0 entonces hay que desconectar el socket de ese jugador
                                        game.getJugadores().obtenerJugador(i).pierde();
                                        p.estado = "Perdedor";
                                    }
                                    else
                                    {
                                        // ganador(IdJugador, 2-> push, saldoActualizado);
                                        //Se verifica también el saldo
                                        game.getJugadores().obtenerJugador(i).push();
                                        p.estado = "Push";
                                    }
                                }
                                p.id = game.getJugadores().obtenerJugador(i).getId();
                                p.nombre = game.getJugadores().obtenerJugador(i).getNombre();

                                foreach (ClientData c in _clients)
                                {
                                    c.clientSocket.Send(p.ToBytes());
                                }
                                //Anuncia los ganadores y las cartas que obtuvo la casa
                                //Actualiza las apuestas
                                //Envia mensaje
                            }
                        }
                        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        //Anuncia los ganadores y las cartas que obtuvo la casa
                        //Actualiza las apuestas
                    }
                    break;

                //Si el tipo es de autentificacion se add a la lista de sockets
                //una vez autentificado y se crea un nuevo jugador asociado a 
                //ese id.

                case Packet.PacketType.salir:
                    Console.WriteLine("**************************************");
                    Console.WriteLine("Id recibido: " + p.id);
                    game.getJugadores().imprimirColeccion();
                    game.getJugadores().eliminarJugador(p.id);
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");
                    game.getJugadores().imprimirColeccion();
                    Console.WriteLine("**************************************");
                    bloquearJuego = false;
                    if (listaEspera.Count > 0)
                    {
                        Jugador jug = listaEspera.GetJugador(0);
                        listaEspera.Remove(jug);//Sale de la lista de espera
                        game.getJugadores().Add(jug);//Entra al juego
                        p.packetType = Packet.PacketType.darAcceso;
                        p.estado = "Acceso aprobado";
                        Console.WriteLine("Jugadores actuales:");
                        game.getJugadores().imprimirColeccion();
                        Console.WriteLine("\n");
                        //Envia el paquete con el acceso
                        foreach (ClientData c in _clients)
                        {
                            c.clientSocket.Send(p.ToBytes());
                        }
                        Console.WriteLine("Estado de acceso de registro: " + p.estado);
                    }

                    break;



                case Packet.PacketType.seguir:
                    Console.WriteLine("Bien! El jugador " + p.nombre + " va a seguir jugando!");
                    p.packetType = Packet.PacketType.darAcceso;
                    p.estado = "Acceso aprobado";
                    Console.WriteLine("Jugadores actuales:");
                    game.getJugadores().imprimirColeccion();
                    Console.WriteLine("\n");
                    foreach (ClientData c in _clients)
                    {
                        c.clientSocket.Send(p.ToBytes());
                    }
                    Console.WriteLine("Estado de acceso de registro: " + p.estado);
                    break;
            }
        }

    }

    class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
        public string id;
        //public jugador jugador;//Acá se va a crear el jugador con la información obtenida

        public ClientData()
        {
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.DATA_IN);
            clientThread.Start(clientSocket);
            SendRegistrationPacket();
        }

        public ClientData(Socket cSocket)
        {
            this.clientSocket = cSocket;
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.DATA_IN);
            clientThread.Start(clientSocket);
            SendRegistrationPacket();
        }

        public void SendRegistrationPacket()
        {
            Packet p = new Packet(Packet.PacketType.Registration, "server");
            p.Gdata.Add(id);
            clientSocket.Send(p.ToBytes());
        }
    }
}

