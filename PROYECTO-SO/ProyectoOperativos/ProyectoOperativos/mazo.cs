using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class Mazo
    {

        //Atributo
        private coleccion mano;


        //Metodos
        public Mazo()
        {
            mano = new coleccion(52);
            llenarMazo();
        }

        public void llenarMazo()
        {
            //mano.limpiar();//Podria dar error aca OjO

            for (int pal = ((int)Carta.Palo.TREBOL); pal <= ((int)Carta.Palo.ESPADAS); ++pal)
            {
                for (int c = ((int)Carta.Rango.AS); c <= ((int)Carta.Rango.REY); ++c)
                {
                    mano.agregarCarta(new Carta(c, pal, true));
                }
            }
        }

        public void barajar()
        {
            Random rnd = new Random();
            Carta temp;
            int num;

            for (int i = 0; i < mano.obtenerCantidad(); ++i)
            {
                num = rnd.Next(0, mano.obtenerCantidad());
                temp = mano.obtenerCarta(i);
                mano.reemplazarCarta(i, mano.obtenerCarta(num));
                mano.reemplazarCarta(num, temp);
            }
        }//Tal vez funcione

        public void mostrarMano()
        {
            mano.imprimirColeccion();
        }

        public int darCarta(coleccion colJugador)
        {
            int cartaDada = 0;
            if (!mano.empty())
            {
                Carta c = mano.obtenerCarta(mano.obtenerCantidad() - 1);
                cartaDada = c.ObtenerValor();
                colJugador.agregarCarta(c);
                mano.eliminarUltimo();
            }
            else
            {
                Console.WriteLine("Ya no hay cartas en el mazo..");
            }
            //Ver que se inicilizen los arrays
            return cartaDada;
        }


        public int cartaAdicional(jugador jugador)
        {
            int cartaE = -1;
            //Inicializar en algun momento los contenedores de los jugadores
            if (!(jugador.pasoDe21()))
            {
                cartaE = darCarta(jugador.obtenerMano());
                jugador.toString();
                if (jugador.pasoDe21())
                {
                    jugador.perdio();
                }
            }
            return cartaE;
        }

        public int cartaAdicionalCasa(Casa c)
        {
            int cartaE = -1;
            if (c.pedirCarta())//Mientras mazo < 16
            {
                cartaE = darCarta(c.obtenerMano());
                c.toString();
            }
            return cartaE;
        }
    }
}
