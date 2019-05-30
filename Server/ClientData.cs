using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
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
