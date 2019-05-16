using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// clase para tomar la informacion del cliente y esta misma pasarla un jugador
/// </summary>
namespace TexasHoldemServer {
    class Cliente {
        public Socket clientSocket;
        public Thread clientThread;
        public string id;



    }
}
