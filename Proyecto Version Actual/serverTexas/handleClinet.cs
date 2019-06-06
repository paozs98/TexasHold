using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace serverTexas {
    public class handleClinet {

        TcpClient clientSocket;
        string clNo;
        Thread clienteHilo;

        public handleClinet() {
           
        }

        public void iniciarHandleClient(TcpClient inClientSocket, string clineNo) {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clienteHilo = new Thread(letsPlay);
            clienteHilo.Start();
        }

        public void letsPlay() {
            
            
            while(true) {

            }

        }

        //leyendo lo que envia el cliente 
        public string leyendoDatosDelCliente() {

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


        }

        public void mandarDatosAlCliente(object mensaje) {

            string jugadorJSON = JsonConvert.SerializeObject(mensaje);

            byte[] flujoBytes = Encoding.Default.GetBytes(jugadorJSON);

            NetworkStream stream = clientSocket.GetStream();

            stream.Write(flujoBytes, 0, flujoBytes.Length);

        }



    }
}
