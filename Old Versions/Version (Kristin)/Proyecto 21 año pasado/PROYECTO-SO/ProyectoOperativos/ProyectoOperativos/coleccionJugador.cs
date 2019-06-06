using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class coleccionJugador
    {
        //Atributos
        private jugador[] Vec;
        private int Cant;
        private int Tam;

        //Métodos
        public coleccionJugador(int n)
        {
            Tam = n;
            Vec = new jugador[Tam];
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

        public jugador obtenerJugador(int pos)
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

        public void reemplazarJugador(int pos, jugador c)
        {
            if (pos < Cant)
            {
                Vec[pos] = c;
            }
        }

        public bool agregarJugador(jugador jug)
        {
            if (Cant < Tam)
            {
                Vec[Cant++] = jug;
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


        public jugador jugadorEspecifico(string idJugador)
        {
            jugador j = null;
            if (VerificarJugador(idJugador))
            {
                for (int i = 0; i < Cant; i++)
                {
                    if (Vec[i].getId() == idJugador)
                    {
                        j = Vec[i];
                    }
                }
            }
            return j;
        }

        public int posJugadorEspecifico(string idJugador)
        {
            int j = -1;
            if (VerificarJugador(idJugador))
            {
                for (int i = 0; i < Cant; i++)
                {
                    if (Vec[i].getId() == idJugador)
                    {
                        j = i;
                    }
                }
            }
            return j;
        }

        //Método nuevo
        public bool VerificarJugador(string idJugador)
        {
            bool existe = false;
            for (int i = 0; i < Cant; i++)
            {
                if (Vec[i].getId() == idJugador)
                {
                    existe = true;
                }
            }
            return existe;
        }

        public int cantidadJugadores()
        {
            return Cant;
        }

        public void eliminarJugador(string idJugador)
        {
            bool existe = false;
            if (Cant == 1 && Vec[0].getId().Equals(idJugador))
            {
                Vec[0] = null;
                existe = true;
            }
            else
            {
                for (int i = 0; i < Cant - 1; i++)
                {
                    if (Vec[i].getId().Equals(idJugador))
                    {
                        existe = true;
                    }
                    if (existe)
                    {
                        Vec[i] = Vec[i + 1];
                    }
                }
            }
            if (existe) { Cant = Cant - 1; }
        }


    }
}
