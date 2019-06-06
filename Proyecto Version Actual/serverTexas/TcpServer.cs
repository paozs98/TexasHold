using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace serverTexas {
    class TcpServer {
        
        //IPAddress ip = Dns.GetHostEntry(IPAddress.Any).AddressList[0]; // para que se conecte en cualquir dir
        int puerto = 8080;//cambiar si da problemas con Oracle

        TcpListener ServerSocket;
        TcpClient clientSocket;
        
        int contadorUsuarios=0;

        static List<handleClinet> _clients;
        bool usuarioPermitido;


        public TcpServer() {

             ServerSocket = new TcpListener(IPAddress.Any, puerto);
             clientSocket = default(TcpClient);
            _clients = new List<handleClinet>(); //inicializando la lista :p
            this.IniciarServer();

        }
        
        public void IniciarServer() {

            try {

                ServerSocket.Start();
                Console.WriteLine("Iniciando el server en la direccion {0}", IPAddress.Any);
                Console.WriteLine("En el puerto {0}", Convert.ToString(puerto));

            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
            Jugador jugador = null;

            for(int i = 0; i < 4; i++) {

                
                clientSocket = ServerSocket.AcceptTcpClient();

                jugador=this.convertirJSONaJugador(this.readDelHandle());// esta retornador el jugador
                
                //auntenficacion DLL 
                //ir la valacion la jugador que acaba de entrar a la sala de juego 
                
                //---

                //Leer los datos del login UserName y Pass de los Jugadores (Clientes)
                contadorUsuarios += 1;

                //Aqui se debe crear al handler del cliente 
                handleClinet client = new handleClinet();
                client.iniciarHandleClient(clientSocket,Convert.ToString(contadorUsuarios));
                _clients.Add(client);

                client.iniciarHandleClient(clientSocket, Convert.ToString(contadorUsuarios));
               
            }

            //clientSocket.Close();
            //ServerSocket.Stop();
            //Console.WriteLine(">>" + "exit");
            //Console.ReadLine();

        }

        public  Jugador convertirJSONaJugador(string j) {

            Jugador juga = new Jugador();
            juga = JsonConvert.DeserializeObject<Jugador>(j);
            return juga;
            
        }

        public void sendAlHandle(String mensaje) {// para mansajes al cliente al jugador que no esta en el dll

            string jugadorJSON = JsonConvert.SerializeObject(mensaje);

            byte[] flujoBytes = Encoding.Default.GetBytes(jugadorJSON);

            NetworkStream stream = clientSocket.GetStream();

            stream.Write(flujoBytes, 0, flujoBytes.Length);

        }

        public string readDelHandle() {

            byte[] receivedBuffer = new byte[4096];// info de lo que envia el cliente pero en byte 
            NetworkStream stream = clientSocket.GetStream();
            stream.Read(receivedBuffer, 0, receivedBuffer.Length);

            StringBuilder msg = new StringBuilder();

            try {

                foreach(byte b in receivedBuffer) {
                    if(b.Equals(00)) {
                        break;
                    } else {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }

            } catch(Exception ex) {
                Console.WriteLine(">>" + ex.ToString());
            }
            return msg.ToString();
        }//cierre del metodo
        

    }
}
