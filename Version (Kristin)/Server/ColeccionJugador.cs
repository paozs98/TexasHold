using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
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
            VEC = new Jugador[tam];
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

        public bool agregarJugador(Jugador jug)
        {
            if (cant < tam)
            {
                VEC[cant++] = jug;
                return true;
            }
            return false;
        }

        public void limpiar()
        {
            for (int i = 0; i <= tam; i++)
            {
                VEC[i] = null;
            }
        }

        public Jugador getJugadorEspecifico(string idJugador)
        {
            Jugador j = null;
            if (VerificarJugador(idJugador))
            {

                for (int i = 0; i < cant; i++)
                {

                    if (VEC[i].getId() == idJugador)
                    {

                        j = VEC[i];
                    }

                }

            }
            return j;
        }

        public int getPosJugadorEspecifico(string idJugador)
        {
            int x = -1;
            if (VerificarJugador(idJugador))
            {
                for (int i = 0; i < cant; i++)
                {

                    if (VEC[i].getId() == idJugador)
                    {
                        x = i;
                    }
                }

            }
            return x;
        }

        public bool VerificarJugador(string dJugador)
        {
            bool existe = false;
            for (int i = 0; i < cant; i++)
            {
                if (VEC[i].getId() == dJugador)
                {
                    existe = true;
                }
            }
            return existe;
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

        public void eliminarJugador(string idJugador)
        {
            bool existe = false;
            if (cant == 1 && VEC[0].getId().Equals(idJugador))
            {
                VEC[0] = null;
                existe = true;
            }
            else
            {
                for (int i = 0; i < cant - 1; i++)
                {
                    if (VEC[i].getId().Equals(idJugador))
                    {
                        existe = true;
                    }
                    if (existe)
                    {
                        VEC[i] = VEC[i + 1];
                    }
                }
            }
            if (existe) { cant = cant - 1; }
        }

        public Jugador GetJugadorEnLaPos(int pos) {

            if (pos > cant || pos<0)
            {
                return null;
            }
            else
            {
                return VEC[pos];

            }
        }


    }//cierre de la clase
}
