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

        protected ColeccionCartas mano;
        protected string nombre;
        protected string id;
        protected int dineroInicial;
        protected int apuesta;
        protected int dineroActual;
        protected bool mostrarCartas;

        public Jugador(string nom) {
            nombre = nom;
            mano = new ColeccionCartas(2);
            dineroInicial = 1000;
        }

        public Jugador(string nom,string id )
        {
            nombre = nom;
           this.id = id;
            mano = new ColeccionCartas( 2 );
            dineroInicial = 1000; // todos los jugadores inician con 1000 dolares en la partida
        }
        public void setId(string nuevo) {
            this.id = nuevo;
        }
        public string getID() {
            return id;
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
public void MostrarCartas() {
            mostrarCartas = true;
        }
        public void SetMano(ColeccionCartas nue) {
            mano = nue;
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
        public ColeccionCartas GetMano() {
            return mano;
        }
     
        

    }// cierre de la clase Jugador 
}
