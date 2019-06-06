using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFpruebaCliente {
    public class Mesa {

        public Mazo mazoMesa { get; set; }
        public ColeccionJugador jugadores { get; set; }
        public ColeccionCarta cartasComunes { get; set; }
        // estas son las cartas que muestra cada vez que se cierra una ronda de apuesta 
        // son las 5 cartas comunes de los jugadores
        public Pot pot { get; set; }
        // el que va a mostrar y tener las reglas de las apuestas


        // metodos
        public Mesa() {
            this.cartasComunes = new ColeccionCarta(5);
            this.mazoMesa = new Mazo();
            this.jugadores = new ColeccionJugador(4);

        }
        public void repartirCartasIniciales() {

            for (int i = 0; i < jugadores.cantidad; i++) {
                jugadores.GetJugadorEnLaPos(i).mano.agregarCarta(mazoMesa.darUnaCarta());
                jugadores.GetJugadorEnLaPos(i).mano.agregarCarta(mazoMesa.darUnaCarta());
            }
        }

        public static string convertirMesaAJson(Mesa j) {
            return JsonConvert.SerializeObject(j);
        }

        public static Mesa convertirJSONaMesa(string j) {
            Mesa juga = new Mesa();
            juga = JsonConvert.DeserializeObject<Mesa>(j);
            return juga;
        }

    }
}
