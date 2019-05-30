using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    //Esta clase tiene un coleccion de 52 cartas para el juego que son las que se van a repartir 
    class Mazo
    {
        //Atributos 
        private ColeccionCartas MAZO;

        //Metodos
        public Mazo()
        {
            MAZO = new ColeccionCartas(52);
            llenarMazo();
        }

        public void llenarMazo()
        {
            for (int pal = ((int)Carta.PALO.DIAMANTE); pal <= ((int)Carta.PALO.ESPADA); ++pal)
            {
                for (int c = ((int)Carta.VALOR.AS); c <= ((int)Carta.VALOR.KA); ++c)
                {
                    MAZO.agregarCarta(new Carta(c, pal, true));
                }
            }
        }

        //Probarlo si funciona
        public void barajar()
        {
            Random rnd = new Random();
            Carta temp;
            int num;

            for (int i = 0; i < MAZO.getCantidad(); ++i)
            {
                num = rnd.Next(0, MAZO.getCantidad());
                temp = MAZO.obtenerCarta(i);
                MAZO.reemplazarCarta(i, MAZO.obtenerCarta(num));
                MAZO.reemplazarCarta(num, temp);
            }

        }

        public void mostrarMazo()
        {
            MAZO.ImprimeColeccion();
        }

        //Hacer un metodo que de a la coleccion de los jugadores las 2 cartas Iniciales 
        // a cada uno de los jugadores que estan en el array 
        public void darCartaInicial(ColeccionJugador colJugador)
        {
            Carta c;

            for (int i = 0; i < colJugador.getCantidad(); i++)
            {
                c = MAZO.obtenerCarta(MAZO.getCantidad() - 1);
                // colJugador.getPosJugadorEspecifico(i);
            }

        }

    } // Cierre de la clase Mazo 
}
