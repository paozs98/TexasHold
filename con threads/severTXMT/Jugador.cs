using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace severTXMT {
    public class Jugador {
        public ColeccionCarta mano { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }
        public int dineroInicial { get; set; }
        public int apuesta { get; set; }


        public Jugador() {
            mano = new ColeccionCarta(2);
            id = "";
            nombre = "";
            contrasena = "";
            dineroInicial = 1000;
            apuesta = 0;

        }

        public Jugador(string nom) {
            mano = new ColeccionCarta(2);
            id = "";
            nombre = nom;
            contrasena = "";
            dineroInicial = 1000;
            apuesta = 0;
        }
        public Jugador(string nom, string ids) {
            mano = new ColeccionCarta(2);
            id = ids;
            nombre = nom;
            contrasena = "";
            dineroInicial = 1000;
            apuesta = 0;
        }

        public Jugador(string nom, string ids, string contra) {
            mano = new ColeccionCarta(2);
            id = ids;
            nombre = nombre;
            contrasena = contra;
            dineroInicial = 1000;
            apuesta = 0;
        }

        public static string convertirJugadorAJson(Jugador j) {
            return JsonConvert.SerializeObject(j);
        }

        public static Jugador convertirJSONaJugador(string j) {
            Jugador juga = new Jugador();
            juga = JsonConvert.DeserializeObject<Jugador>(j);
            return juga;
        }


    }// cierre de la clase Jugador 

}
