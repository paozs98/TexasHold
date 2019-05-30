using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//esta es la clase que se encargar de ver los mov de cada jugador 
namespace TexasHoldemServer {
    class Mesa {

        private Mazo mazoMesa;
        private ColeccionJugador jugadores;
        private ColeccionCartas cartasComunes; // estas son las cartas que muestra cada vez que se cierra una ronda de apuesta 
        // son las 7 cartas comunes de los jugadores
        private Pot pot;

        // metodos
        public Mazo getMazo() {
            return mazoMesa;
        }

        public ColeccionJugador getJugadores() {
            return jugadores;
        }

        public ColeccionCartas getCartascomunes() {
            return cartasComunes;
        }

        public Pot getPot() {
            return pot;
        }

        public void setMazo(Mazo nuevo) {
            this.mazoMesa = nuevo;
        }

        public void setPot(Pot pott) {
            this.pot = pott;
        }

        public void setJugadores(ColeccionJugador j) {
            jugadores = j;
        }

        public void setCartasComunes(ColeccionCartas c) {
            cartasComunes = c;
        }

        public bool IniciarSesion(string id) {
            bool existe = jugadores.VerificarJugador(id);
            return existe;
        }

        public Mesa(int cantJugadores )
        {
            jugadores = new ColeccionJugador(cantJugadores);
           
            //Se crea el mazo 
            this.mazoMesa = new Mazo();
            // se llena el mazo con las cartas 
            this.mazoMesa.llenarMazo();
            // se barajea el mazo 
            this.mazoMesa.barajar();


        }

        public Mesa(ColeccionJugador nombres) {
            jugadores = new ColeccionJugador(nombres.getCantidad());
            for (int i = 0;i < nombres.getCantidad(); i++) {
                Jugador J = nombres.obtenerJugador(i);
               // jugadores.agregarJugador(j);
            }
            //Se crea el mazo 
            this.mazoMesa = new Mazo();
            // se llena el mazo con las cartas 
            this.mazoMesa.llenarMazo();
            // se barajea el mazo 
            this.mazoMesa.barajar();

        }

        public void letsPlay() {

        }
    }
}
