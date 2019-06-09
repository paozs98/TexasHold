using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace serverTexas
{
    public static class ConvertidorJson
    {
        //Carta
        public static string convertirCartaAJson(Carta j)
        {
            return JsonConvert.SerializeObject(j);
        }

        public static Carta convertirJSONaCarta(string j)
        {
            Carta cartiux = new Carta();
            cartiux = JsonConvert.DeserializeObject<Carta>(j);
            return cartiux;
        }
        //ColeccionCarta
        public static string convertirColeccionCartaAJson(ColeccionCarta j)
        {
            return JsonConvert.SerializeObject(j);
        }

        public static ColeccionCarta convertirJSONaColeccionCarta(string j)
        {
            ColeccionCarta coleccionux = new ColeccionCarta();
            coleccionux = JsonConvert.DeserializeObject<ColeccionCarta>(j);
            return coleccionux;
        }
        //ColeccionJugador
        public static string convertirColeccionJugadorAJson(ColeccionJugador j)
        {
            return JsonConvert.SerializeObject(j);
        }

        public static ColeccionJugador convertirJSONaColeccionJugador(string j)
        {
            ColeccionJugador colecionux = new ColeccionJugador();
            colecionux = JsonConvert.DeserializeObject<ColeccionJugador>(j);
            return colecionux;
        }
        //Jugador
        public static string convertirJugadorAJson(Jugador j)
        {
            return JsonConvert.SerializeObject(j);
        }

        public static Jugador convertirJSONaJugador(string j)
        {
            Jugador juga = new Jugador();
            juga = JsonConvert.DeserializeObject<Jugador>(j);
            return juga;
        }
        //Mazo
        public static string convertirMazoAJson(Mazo j)
        {
            return JsonConvert.SerializeObject(j);
        }

        public static Mazo convertirJSONaMazo(string j)
        {
            Mazo maziux = new Mazo();
            maziux = JsonConvert.DeserializeObject<Mazo>(j);
            return maziux;
        }
        //Mesa
        public static string convertirMesaAJson(Mesa j)
        {
            return JsonConvert.SerializeObject(j);
        }

        public static Mesa convertirJSONaMesa(string j)
        {
            Mesa mesiux = new Mesa();
            mesiux = JsonConvert.DeserializeObject<Mesa>(j);
            return mesiux;
        }
        //Pot
        public static string convertirPotAJson(Pot j)
        {
            return JsonConvert.SerializeObject(j);
        }

        public static Pot convertirJSONaPot(string j)
        {
            Pot potpot = new Pot();
            potpot = JsonConvert.DeserializeObject<Pot>(j);
            return potpot;
        }
    }//cierre de la clase ConvertidorJson...

}
