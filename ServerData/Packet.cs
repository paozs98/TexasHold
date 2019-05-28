using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ServerData
{
    [Serializable]
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

        //Atributos de casa
        public int casa;//0->Aun no va turno casa 1->Va casa
        public int cartaCasa1;
        public int cartaCasa2;

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
            this.turno = p.turno;
            this.carta1 = p.carta1;
            this.carta2 = p.carta2;
            this.casa = p.casa;
            this.cartaCasa1 = p.cartaCasa1;
            this.cartaCasa2 = p.cartaCasa2;
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

            turnoCasa,
            primerasCartas,
            comunicarTurno,//Servidor comunica de quien es el turno siguiente
            quedarse,//El jugador se queda
            pedirCarta,//El jugador pide carta (adherir las apuestas)
            darCarta,//El servidor le da la carta al jugador y vuelve a comunicar turno
            casaAcabo,
            seguir,//El jugador quiere seguir en el juego
            actualizarJugador,
            salir
        }
        //pedir carta (hay que integrarle la apuesta),
        //Necesito que antes de pedir carta se le envíe al cliente un paquete con el id del cliente que tiene el turno,
        //este responde si quiere o si no quiere una carta. si quiere debe enviar también el monto de apuesta,
        //sino quiere, se va a poner al cliente en estado quedado (no mas cartas) -> eso debería ir en jugador
        //Hay que enviar las cartas de la casa también

        //Hay que hacer las comunicaciones para indicar si un jugador ganó, perdió o empató y con eso 
        //se le envía el monto de su apuesta actualizada.
    }
}
