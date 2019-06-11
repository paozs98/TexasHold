using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace serverTexas
{
    class TcpServer
    {

        IPAddress localAddr = IPAddress.Parse("10.251.35.119");// para que se conecte en cualquir dir
        int puerto = 8090;//cambiar si da problemas con Oracle

        TcpListener ServerSocket;
        TcpClient clientSocket;
        int contadorUsuarios = 0;
     
        static List<Thread> _hilosClientes;
        Mazo mazoGlobal = new Mazo();
        Mutex _mutex = new Mutex();
        
        Jugador jugador = null;// para obtener los datos de los jugadores 
        Mesa mesa = null;
        bool begin = false;

        int turnoGlobal = 0;
        bool usuarioPermitido;


        public TcpServer()
        {
            ServerSocket = new TcpListener(localAddr, puerto);
            clientSocket = default(TcpClient);
            _hilosClientes = new List<Thread>(); ///iniciando la lista de los clientes            
            this.mesa = new Mesa();             
        }

        public void IniciarServer()
        {
            try
            {
                ServerSocket.Start();
                Console.WriteLine("Iniciando el server en la direccion {0}", Convert.ToString(localAddr));
                Console.WriteLine("En el puerto {0}", Convert.ToString(puerto));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

            Console.WriteLine("Cartas que deben aparecer a todos los jugadores");

            for (int w = 0; w < 5; w++)
            {
                // for para obtener las 5 cartas comunes del juego 
                //se muestra solo una por cada ronda 
                Carta carta = mazoGlobal.darUnaCarta();
                mesa.cartasComunes.agregarCarta(carta);

                Console.WriteLine("carta: " + carta.imprimir());
            }


            for (int i = 0; i < 4; ++i)
            {
                clientSocket = ServerSocket.AcceptTcpClient();
                jugador = ConvertidorJson.convertirJSONaJugador(this.readData(clientSocket));

                Console.WriteLine("Ha entrado un usuario al server! " + jugador.nombre
                    + "\nJugador numero #   " +
                    Convert.ToString(contadorUsuarios));

                this.mesa.jugadores.agregarJugador(new Jugador(jugador.nombre,
                    Convert.ToString(contadorUsuarios), jugador.contrasena));

                contadorUsuarios += 1;

                this.manejadorCliente(clientSocket, Convert.ToString(contadorUsuarios));
            }

            //if (mesa.jugadores.cantidad == 4)
            //{
            //    this.manejadorCliente(clientSocket, Convert.ToString(contadorUsuarios));
            //}

            // con la parte de Rob
            //for (int i = 0; i < 4; i++){


            //clientSocket = ServerSocket.AcceptTcpClient();
            //jugador = ConvertidorJson.convertirJSONaJugador(this.readData(clientSocket));
            //usuarioPermitido = TexasHoldemDLL.Autenticación.autentificar(jugador.nombre, jugador.contrasena);
            //if (usuarioPermitido)
            //{
            //    Console.WriteLine("Ha entrado un usuario al server! " + jugador.nombre
            //                        + "\nJugador numero #   " +
            //                        Convert.ToString(contadorUsuarios));

            //    this.mesa.jugadores.agregarJugador(new Jugador(jugador.nombre,
            //        Convert.ToString(contadorUsuarios), jugador.contrasena));

            //    contadorUsuarios += 1;

            //    this.manejadorCliente(clientSocket, Convert.ToString(contadorUsuarios));

            //}
            //else {
            //            Console.WriteLine("Usuario no registrado");
            //            this.sendData("Por favor registrese!");
            //jugador = ConvertidorJson.convertirJSONaJugador(this.readData(clientSocket));
            //TexasHoldemDLL.Autenticación.crearUsuario(jugador.nombre,jugador.contrasena);
            //}
            //}


        }

        public void letsPlayTexas(Object socket)
        {
            while (mesa.jugadores.cantidad != 4) ;
            while (true)
            {
                ///implementacion del mutex
                _mutex.WaitOne();
                if (begin == false)
                {
                    
                    this.mesa.repartirCartasIniciales(mazoGlobal);
                    this.mesa.pot.apuestaMinima = 50;
                    this.mesa.pot.apuestaMaxima = 100;
                    this.mesa.jugadores.GetJugadorEnLaPos(0).dineroInicial -= 100;
                    this.mesa.jugadores.GetJugadorEnLaPos(1).dineroInicial -= 50;
                    
                    begin = true;
                }
                _mutex.ReleaseMutex();

                // sale el primer jugador  que entro (hilo) solo este realiza las cosas

                while (begin == false) ;

                //Mandamos la mesa con todas las cosas a todos los jugadores 
                String mesaJSON = ConvertidorJson.convertirMesaAJson(this.mesa);
                this.sendData(mesaJSON,(TcpClient) socket);

                //Primera jugada 
                //primeraJugada();


            }
        }
        //recibiendo datos como string tiene que ir serliazados 
        public void sendData(String mensaje, TcpClient socket)
        {
            // para mansajes al cliente
            byte[] flujoBytes = Encoding.Default.GetBytes(mensaje);
            NetworkStream stream = socket.GetStream();
            stream.Write(flujoBytes, 0, flujoBytes.Length);
        }
        //enviandoDatos como string se tiene que serializar antes 
        public string readData(TcpClient socket)
        {
            byte[] receivedBuffer = new byte[4096];// info de lo que envia el cliente pero en byte 
            NetworkStream stream = socket.GetStream();
            stream.Read(receivedBuffer, 0, receivedBuffer.Length);
            StringBuilder msg = new StringBuilder();

            try
            {
                foreach (byte b in receivedBuffer)
                {
                    if (b.Equals(00))
                    {
                        break;
                    }
                    else
                    {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>" + ex.ToString());
            }
            return msg.ToString();
        }//cierre del metodo

        public void manejadorCliente(TcpClient inClient, string clientNO)
        {
            //TcpClient clienSocket;
            string CLNO;
            Thread clienteHilo;

            //clienSocket = inClient;
            CLNO = clientNO;
            clienteHilo = new Thread(new ParameterizedThreadStart(letsPlayTexas));
            clienteHilo.Name = clientNO; //identificador para cada hilo
            _hilosClientes.Add(clienteHilo);
            clienteHilo.Start(inClient);
        }

        //public void primeraJugada() {
        //    for (int i = 0; i < 4; i++) {
        //        mesa.pot + = mesa.jugadores.GetJugadorEnLaPos(i).apuesta;
        //    }
        //    this.sendData(ConvertidorJson.convertirPotAJson(mesa.pot),clientSocket);
        //    //Aqui despues de que todos apostaron se debe mostrar las primera 3 cartas 
        //}


        //public void registrarUsuario()
        //{
        //    clientSocket = ServerSocket.AcceptTcpClient();

        //    jugador = ConvertidorJson.convertirJSONaJugador(this.readData());

        //    if(usuarioPermitido = TexasHoldemDLL.Autenticación.crearUsuario(jugador.nombre, jugador.contrasena))
        //    {
        //        Console.WriteLine("Usuario nuevo registrado");
        //        this.sendData("Se ha regitrado correctamente");

        //    }
        //    else
        //    {
        //        Console.WriteLine("No se ha podido regitrar el usuario");
        //        this.sendData("Por favor pruebe otros datos");
        //    }
        //}
    }//ciere de la clase 
}
