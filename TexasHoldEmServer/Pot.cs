using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEmServer
{ /// <summary>
/// clase que se encarga de llevar un registro de la apuestas del juego
/// ejemplo la ciegaPequena para entrar 
/// ciegaGrande
/// el total que se lleva el ganador 
/// </summary>
    class Pot
    {
        private ListaJugadores jugadoresEnApuesta = new ListaJugadores();
        private int sumaEnElPot;
        private int apuestaMin;
        private int apuestaMax;
        private int ciegaPequena;
        private int ciegaGrande;

        public Pot() {
            this.sumaEnElPot = 0;
            this.apuestaMin = 0;
            this.apuestaMax = 0;
        }
        public Pot(int apuestaTotal, ListaJugadores lista) {
            this.sumaEnElPot = apuestaTotal;
            this.jugadoresEnApuesta = lista;
            this.sumaEnElPot = 0;
            this.apuestaMin = 0;
            this.apuestaMax = 0;
        }

        public void agregarApuesta(int dineros) {
            this.sumaEnElPot += dineros;
        }

        public void agregarJugardor(Jugador ju) {
            if (!jugadoresEnApuesta.Contains(ju))
                jugadoresEnApuesta.Add(ju);
        }

        public void SetCiefaGrande(int c) {
            this.ciegaGrande = c;
        }

        public void SetCiegaPequena(int c) {
            this.ciegaPequena = c;
        }

        public void SetApuestaMax(int ap) {
            this.apuestaMax = ap;
        }

        public void SetAPuestaMin(int ap) {
            this.apuestaMin = ap;
        }

        public void SetSumaEnElPot(int suma) {
            this.sumaEnElPot = suma;
        }

        public void SetJugadoresEnApuesta(ListaJugadores jugadores) {
            this.jugadoresEnApuesta = jugadores;
        }

        public int GetCiegaGrande() {
            return ciegaGrande;
        }

        public int GetCiegaPequena() {
            return ciegaPequena; ;
        }

        public int GetApuestaMax() {
            return apuestaMax;
        }

        public int GetApuestaMin() {
            return apuestaMin;
        }

        public int GetSumaEnElPot() {
            return sumaEnElPot;
        }

        public ListaJugadores GetJugadoreEnApuesta() {
            return jugadoresEnApuesta;
        }

    }//cierre de la clase Pot
}//cierre del namespace 
