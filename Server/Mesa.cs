using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Mesa
    {

        private Mazo mazoMesa;
        private ColeccionJugador jugadores;
        private ColeccionCartas cartasComunes; // estas son las cartas que muestra cada vez que se cierra una ronda de apuesta 
        // son las 5 cartas comunes de los jugadores
        private Pot pot; // el que va a mostrar y tener las reglas de las apuestas

        // metodos
        public Mazo getMazo()
        {
            return mazoMesa;
        }

        public ColeccionJugador getJugadores()
        {
            return jugadores;
        }

        public ColeccionCartas getCartascomunes()
        {
            return cartasComunes;
        }

        public Pot getPot()
        {
            return pot;
        }

        public void setMazo(Mazo nuevo)
        {
            this.mazoMesa = nuevo;
        }

        public void setPot(Pot pott)
        {
            this.pot = pott;
        }

        public void setJugadores(ColeccionJugador j)
        {
            jugadores = j;
        }

        public void setCartasComunes(ColeccionCartas c)
        {
            cartasComunes = c;
        }

        //este metodo debe esta ligado al AD sino esta verificado entoces se tendra que crear un nuevo jugador
        public bool IniciarSesion(string id)
        {
            bool existe = jugadores.VerificarJugador(id);
            return existe;
        }

        public Mesa()
        {
            this.cartasComunes = new ColeccionCartas(5);
            this.mazoMesa = new Mazo();
            this.jugadores = new ColeccionJugador(4);

        }
        public void repartirCartasIniciales()
        {

        }
    }
}
