using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Packet
    {

        public List<string> Gdata;
        public int packetInt;
        public bool packetBool;
        public string senderID;
        public PacketType packetType;


        //Atributos de mensaje
        public int carta1;
        public int carta2;
        public string nombre;
        public string clave;
        public string id;
        public int apuesta;
        public int numeroCarta;
        public string estado; //Acceso aprobado o desaprobado
        public string turno; //id de jugador de va

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
            this.nombre = p.nombre;
            this.id = p.id;
            this.apuesta = p.apuesta;
            this.numeroCarta = p.numeroCarta;
            this.clave = p.clave;
            this.estado = p.estado;
            this.idJugador = p.idJugador;
            this.carta1 = p.carta1;
            this.carta2 = p.carta2;

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
            Chat,
            Mensaje,

            iniciarJuego,//Al presionar botón iniciar juego se envía este paquete

            //Estos son del juego
            nuevoCliente,
            autentificar,//Los clientes mandan el usuario y la contraseña
            registrar,
            denegarAcceso,//El cliente sí está registrado
            darAcceso,//El cliente no está registrado
            enEspera,
            turnoMesa,//Cuando ya casi cierra la ronda y pone una carta Comun
            primerasCartas,
            turno,
            comunicarTurno,//Servidor comunica de quien es el idJugador siguiente
            quedarse,//El jugador se queda
            mesaTermino,//La mesa termino de poner la carta 
            seguir,//El jugador quiere seguir en el juego
            actualizarJugador,
            salir
        }

    }
}
