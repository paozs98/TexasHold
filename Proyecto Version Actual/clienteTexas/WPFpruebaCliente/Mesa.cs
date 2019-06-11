using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFpruebaCliente {
    public class Mesa {
        public int desicion { get; set; }

        public Mazo mazoMesa { get; set; }
        public ColeccionJugador jugadores { get; set; }
      //  public ColeccionJugador jugadoresActivos { get; set; }
        public ColeccionCarta cartasComunes { get; set; }
        // estas son las cartas que muestra cada vez que se cierra una ronda de apuesta 
        // son las 5 cartas comunes de los jugadores
        public Pot pot { get; set; }
        // el que va a mostrar y tener las reglas de las apuestas

        public int turno { get; }


        // metodos
        public Mesa()
        {
            this.cartasComunes = new ColeccionCarta(5);
            this.mazoMesa = new Mazo();
            this.jugadores = new ColeccionJugador(4);
            this.turno = 0;
            this.desicion = -1;

        }
        public void repartirCartasIniciales()
        {

            for (int i = 0; i < jugadores.cantidad; i++)
            {
                jugadores.GetJugadorEnLaPos(i).mano.agregarCarta(mazoMesa.darUnaCarta());
                jugadores.GetJugadorEnLaPos(i).mano.agregarCarta(mazoMesa.darUnaCarta());
            }
        }



        /*public static string convertirMesaAJson(Mesa j) {
            return JsonConvert.SerializeObject(j);
        }

        public static Mesa convertirJSONaMesa(string j) {
            Mesa mesiux = new Mesa();
            mesiux = JsonConvert.DeserializeObject<Mesa>(j);
            return mesiux;
        }*/



        public void verificarDecision()
        {
            switch (this.desicion)
            {
                case 0:
                    this.call();
                    break;
                case 1:
                    this.fold();
                    break;
                case 2:
                    this.raise();
                    break;
                case 3:
                    this.check();
                    break;
            }

        }

        public bool call()
        {
            if (jugadores.GetJugadorEnLaPos(turno).dineroInicial < jugadores.GetJugadorEnLaPos(turno).apuesta) ;
            return false;
           // return true;
        }
        public void fold() { }
        public void raise() { }
        public void check() { }

    }
}
