using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemServer
{
    class ColeccionJugador
    {
        //Atributos 
        private Jugador[] VEC;
        private int cant;
        private int tam;

        //metodos

        public ColeccionJugador(int n)
        {
            tam = n;
            VEC = new Jugador[n];
            cant = 0;
        }

        public bool isVacio()
        {
            return (cant == 0);
        }

        public int getTamano()
        {
            return tam;
        }

        public int getCantidad()
        {
            return cant;
        }

        public Jugador obtenerJugador(int pos)
        {
            if (pos < cant) { return VEC[pos]; }
            else { return null; }
        }

        public void reemplazarJugador(int pos, Jugador c)
        {
            if (pos < cant) { VEC[cant++] = c; }
        }

        public void limpiar()
        {
            for (int i = 0; i < tam; i++)
            {
                VEC[i] = null;
            }
        }

        public void imprimirColeccion()
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

        //Método nuevo
        public bool VerificarJugador(string nombre)
        {
            bool existe = false;
            for (int i = 0; i < cant; i++)
            {
                if (VEC[i].GetNombre() == nombre)
                {
                    existe = true;
                }
            }
            return existe;
        }

        public bool agregarJugador(Jugador jug)
        {
            if (cant < tam)
            {
                VEC[cant++] = jug;
                return true;
            }
            return false;
        }

        public Jugador getJugadorEspecifico(string nombreJugador)
        {
            Jugador j = null;
            if (VerificarJugador(nombreJugador))
            {
                for (int i = 0; i < cant; i++)
                {
                    if (VEC[i].GetNombre() == nombreJugador)
                    {
                        j = VEC[i];
                    }
                }
            }
            return j;
        }

        public int getPosJugadorEspecifico(string nombre)
        {
            int j = -1;
            if (VerificarJugador(nombre))
            {
                for (int i = 0; i < cant; i++)
                {
                    if (VEC[i].GetNombre() == nombre)
                    {
                        j = i;
                    }
                }
            }
            return j;
        }

        public int getCantidadJugadores()
        {
            return cant;
        }

        public void eliminaJugador(string nombre)
        {
            bool existe = false;
            if (cant == 1 && VEC[0].GetNombre().Equals(nombre))
            {
                VEC[0] = null;
                existe = true;
            }
            else
            {
                for (int i = 0; i < cant - 1; i++)
                {
                    if (VEC[i].GetNombre().Equals(nombre)) {
                        existe = true;
                    }
                    if (existe) {
                        VEC[i] = VEC[i + 1];
                    }
                }
            }
            if (existe) { cant = cant - 1; }
        }


    }//cierre de la clase
}
