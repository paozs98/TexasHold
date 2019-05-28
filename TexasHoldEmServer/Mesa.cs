using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemServer {
    class Mesa {


        private ListaJugadores jugadores = new ListaJugadores();
        private Baraja baraja;
        private ColeccionCartas manoDeLaMesa = new ColeccionCartas();
        private int contadorDeRound;
        private Pot potPrincipal;
        private Random rand;
        private int contadorTurnos;
        private int dealerPosition;
        private int posActual;

        public Mesa(ListaJugadores jugadores, Baraja baraja, ColeccionCartas manoDeLaMesa, int contadorDeRound, Pot potPrincipal, int contadorTurnos, int dealerPosition, int posActual) {
            this.jugadores = jugadores;
            this.baraja = baraja;
            this.manoDeLaMesa = manoDeLaMesa;
            this.contadorDeRound = contadorDeRound;
            this.potPrincipal = potPrincipal;
            this.contadorTurnos = contadorTurnos;
            this.dealerPosition = dealerPosition;
            this.posActual = posActual;
        }

        public void SetDealerPosition(int po) {
            dealerPosition = po;
        }

        public void SetPosActual(int p) {
            posActual = p;
        }

        public int GetPosActual() {
            return posActual;
        }

        public int GetDealerPosition() {
            return dealerPosition;
        }

        public void SetContadorTurnos(int c) {
            contadorTurnos = c;
        }

        public void SetPotPrincipal(Pot po) {
            potPrincipal = po;
        }

        public void SetContadorDeRound(int co) {
            contadorDeRound = co;
        }

        public void SetManoDeLaMesa(ColeccionCartas ma) {
            manoDeLaMesa = ma;
        }

        public void SetBaraja(Baraja ba) {
            baraja = ba;
        }

        public void SetJugadores(ListaJugadores ju) {
            jugadores = ju;
        }

        public int GetContadorTuenos() {
            return contadorTurnos;
        }

        public Pot GetPotPrincipal() {
            return potPrincipal;
        }

        public int GetContadorRound() {
            return contadorDeRound;
        }

        public ColeccionCartas GetMano() {
            return manoDeLaMesa;
        }

        public Baraja GetBaraja() {
            return baraja;
        }

        public ListaJugadores GetJugadores() {
            return jugadores;
        }


    }
}
