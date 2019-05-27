using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemServer {
    class Jugador {

        protected Mano myHand = new Mano();
        protected string nombre;
        protected int dineroInicial;
        protected int apuesta;
        protected int dineroActual;
        protected bool mostrarCartas;

        public Jugador(string n){
            nombre = n;
        }
        public void SetNombre(string n) {
            nombre = n;
        }
        public void SetMostrarCartas(bool mo) {
            mostrarCartas = mo;
        }
        public void SetDineroActual(int actual) {
            dineroActual = actual;
        }

        public void SetApuesta(int ap) {
            apuesta = ap;
        }

        public void SetDineroInicial(int i) {
            dineroInicial = i;
        }

        public void SetMano(Mano nue) {
            myHand = nue;
        }
        public int GetDineroInicial() {
            return dineroInicial;
        }
        public bool IsMostrarCartas() {
            return mostrarCartas;
        }
        public int GetDineroActual() {
            return dineroActual;
        }
        public int getApuesta() {
            return apuesta;
        }
        public string GetNombre() {
            return nombre;
        }
        public Mano GetMano() {
            return myHand;
        }
        public void AgregarMano(Mano mano) {
            myHand += mano;
        }

        public void AgregarMano(Carta carta) {
            myHand.Agregar_Carta(carta);
        }

        public void MostrarCartas() {
            mostrarCartas = true;
        }

    }
}
