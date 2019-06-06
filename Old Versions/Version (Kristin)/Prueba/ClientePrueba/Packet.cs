using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClientePrueba
{
    public class Packet
    {

        public List<string> Gdata;
        public int packetInt;
        public bool packetBool;
        public string senderID;
        public PacketType packetType;
        public string id; // de la clase no borrar 

        public string turno;

        public int carta1J;//cartas de cada jugador
        public int carta2J;//cartas de cada jugador
        public string nombre;// nombre del jugador 
        public string clave;// clave del jugador 
        public int apuesta;// la apuesta que manda el jugador  

        //Atributos de la mesa 
        public int cartaM1;
        public int cartaM2;
        public int cartaM3;
        public int cartaM4;
        public int cartaM5;


        public Packet(PacketType type, string senderID)
        {
            Gdata = new List<string>();
            this.senderID = senderID;
            this.packetType = type;
        }


        public Packet(byte[] packetBytes)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(packetBytes);

            Packet p = (Packet)bf.Deserialize(ms);
            ms.Close();
            this.Gdata = p.Gdata;
            this.packetInt = p.packetInt;
            this.packetBool = p.packetBool;
            this.senderID = p.senderID;
            this.packetType = p.packetType;

            id = p.id;

            turno = p.turno;

            carta1J = p.carta1J;
            carta2J = p.carta2J;
            nombre = p.nombre;
            clave = p.clave;
            apuesta = p.apuesta;


            cartaM1 = p.cartaM1;
            cartaM2 = p.cartaM2;
            cartaM3 = p.cartaM3;
            cartaM4 = p.cartaM4;
            cartaM5 = p.cartaM5;
        }


        public byte[] ToBytes()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, this);
            byte[] bytes = ms.ToArray();
            ms.Close();
            return bytes;
        }


        public static string GetIPAddress()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress i in ips)
            {
                if (i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return i.ToString();
            }
            return "127.0.0.1";
        }

        public enum PacketType
        {
            Registration,

            Registrarse,
            Auntentificar,
            IniciarJuego,
            EntrarALaMesa,
            SalirDelJuego,
            Apostar
        }

    }
}
