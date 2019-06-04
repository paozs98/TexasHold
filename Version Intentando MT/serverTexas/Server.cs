using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace serverTexas {
    class Server {
        static void Main(string[] args) {

            TcpServer Server = new TcpServer();
            Server.IniciarServer();

        }
    }
}
