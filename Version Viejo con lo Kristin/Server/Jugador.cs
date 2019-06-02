using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Jugador
    {

        protected ColeccionCartas mano;
        protected string id;
        protected string nombre;
        protected int dineroInicial;
        protected int apuesta;


        public Jugador(string nom)
        {
            id = "";
            nombre = nom;
            mano = new ColeccionCartas(2);
            dineroInicial = 1000;
            apuesta = 0;
        }
        public Jugador(string nom, string id)
        {
            this.id = id;
            nombre = nom;
            mano = new ColeccionCartas(2);
            dineroInicial = 1000;
            apuesta = 0;
        }

        public ColeccionCartas getMano()
        {
            return mano;
        }
        public void setMano(ColeccionCartas nue)
        {
            mano = nue;
        }

        public void setId(string nuevo)
        {
            this.id = nuevo;
        }
        public string getId()
        {
            return id;
        }

        public string getNombre()
        {
            return nombre;
        }
        public void SetNombre(string n)
        {
            nombre = n;
        }

        public void setDineroIncial(int dir) { dineroInicial = dir; }
        public int getDineroIncial() { return dineroInicial; }

        public int getApuesta()
        {
            return apuesta;
        }
        public void setApuesta(int apu)
        {
            apuesta = apu;
        }

    }// cierre de la clase Jugador 
}
