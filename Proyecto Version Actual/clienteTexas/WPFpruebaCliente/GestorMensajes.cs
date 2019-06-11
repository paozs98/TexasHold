using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WPFpruebaCliente
{
    public static class GestorMensajes
    {
        //para leer los mensajes del server
        public static string readData(TcpClient clientSocket)
        {
            byte[] receivedBuffer = new byte[4096];// info de lo que envia el cliente pero en byte 
            NetworkStream stream = clientSocket.GetStream();
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

        //para enviar mensajes al server 
        public static void sendData(String mensaje,TcpClient clientSocket)
        {
            byte[] flujoBytes = Encoding.Default.GetBytes(mensaje);

            NetworkStream stream = clientSocket.GetStream();

            stream.Write(flujoBytes, 0, flujoBytes.Length);

        }
    }
}
