using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    public class coleccion
    {

        //Atributos
        private Carta[] Vec;
        private int Cant;
        private int Tam;

        //Métodos
        public coleccion(int n)
        {
            Tam = n;
            Vec = new Carta[Tam];
            Cant = 0;
        }

        public bool empty()
        {
            return (Cant == 0);
        }

        public int obtenerCantidad()
        {
            return Cant;
        }

        public Carta obtenerCarta(int pos)
        {
            if (pos < Cant)
            {
                return Vec[pos];
            }
            else
            {
                return null;
            }
        }

        public void reemplazarCarta(int pos, Carta c)
        {
            if (pos < Cant)
            {
                Vec[pos] = c;
            }
        }

        public bool agregarCarta(Carta car)
        {
            if (Cant < Tam)
            {
                Vec[Cant++] = car;
                return true;
            }
            return false;
        }

        public void limpiar()
        {
            for (int i = 0; i <= Tam; i++)
            {
                Vec[i] = null;
            }
        }

        public int ObtenerTotal()
        {
            int total = 0;
            bool tieneAS = false;

            if (Cant == 0)
            {
                total = 0;
            }
            if (Vec[0].ObtenerValor() == 0)//Primera carta boca abajo
                return 0;

            for (int i = 0; i < Cant; i++)
            {
                total += Vec[i].ObtenerValor();
            }

            for (int i = 0; i < Cant; i++)
            {
                if (Vec[i].ObtenerValor() == ((int)Carta.Rango.AS))
                    tieneAS = true;
            }

            if (tieneAS && total <= 11)
            {
                total += 10; //10 o 9?
            }


            return total;
        }

        public void imprimirColeccion()
        {
            for (int i = 0; i < Cant; i++)
            {
                Vec[i].toString();
            }
        }


        public void eliminarUltimo()
        {
            Cant--;
        }

        public void voltearPrimerCarta()
        {
            if (!empty())
            {
                Vec[0].Voltear();
            }
        }

    }
}
