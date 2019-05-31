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
            barajar();
        }

        public void llenarMazo()
        {
            for (int pal = ((int)Carta.PALO.DIAMANTE); pal <= ((int)Carta.PALO.ESPADA); ++pal)
            {
                for (int c = ((int)Carta.VALOR.AS); c <= ((int)Carta.VALOR.KA); ++c)
                {
                    MAZO.agregarCarta(new Carta(c, pal));
                }
            }
        }

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

        public Carta darUnaCarta()
        {
            if (!MAZO.isVacio())
            {
                Carta cartaADar = MAZO.obtenerCarta(MAZO.getCantidad() - 1);
                MAZO.eliminarUltimo();
                return cartaADar;
            }
            else
            {
                Console.WriteLine("No hay cartas en el Mazo");
                return null;
            }

        }

    } // Cierre de la clase Mazo 
}
