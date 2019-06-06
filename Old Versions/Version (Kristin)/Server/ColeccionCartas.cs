using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    //Clase que se encarga de tener las cartas de lo jugadores 
    // o de la mesa en si ya que la mesa tiene que tener una coleccion de  52 cartas
    public class ColeccionCartas
    {
        //Atributos
        private Carta[] VEC;
        private int cant;
        private int tam;

        //Metodos 
        public ColeccionCartas(int n)
        {
            tam = n;
            VEC = new Carta[tam];
            cant = 0;
        }

        public bool isVacio()
        {
            return (cant == 0);
        }

        public int getCantidad()
        {
            return cant;
        }

        public int getTamano()
        {
            return tam;
        }

        public Carta obtenerCarta(int pos)
        {
            if (pos < cant)
            {
                return VEC[pos];
            }
            else { return null; }
        }
        public void reemplazarCarta(int pos, Carta c)
        {
            if (pos < cant)
            {
                VEC[pos] = c;
            }
        }
        public bool agregarCarta(Carta car)
        {
            if (cant < tam)
            {
                VEC[cant++] = car;
                return true;
            }
            else { return false; }
        }
        public void limpiar()
        {
            for (int i = 0; i < tam; i++)
            {
                VEC[i] = null;
            }
        }

        public void ImprimeColeccion()
        {
            for (int i = 0; i < cant; i++)
            {
                VEC[i].ToString();
            }
        }

        public void eliminarUltimo()
        {
            cant--;
        }


    }//cierre de la clase
}
