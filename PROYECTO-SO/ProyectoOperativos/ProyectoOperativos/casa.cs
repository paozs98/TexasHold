using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class Casa
    {

        //Metodos
        public Casa(string nombre)
        {
            Nombre = nombre;
            mano = new coleccion(7);
        }

        public bool pedirCarta()
        {
            return (mano.ObtenerTotal() <= 16);
        }

        public void voltearPrimero()
        {
            if (!mano.empty())
            {
                mano.voltearPrimerCarta();
            }
            else
            {
                Console.WriteLine("No hay cartas para voltear....");
            }
        }

        public coleccion obtenerMano()
        {
            return mano;
        }

        public void toString()
        {
            Console.WriteLine("Nombre del jugador: {0}", Nombre);

            if (!obtenerMano().empty())
            {
                obtenerMano().imprimirColeccion();
                if (obtenerMano().ObtenerTotal() != 0)
                {
                    Console.WriteLine("(Total de pts: {0})", obtenerMano().ObtenerTotal());
                }
            }
            else
            {
                Console.WriteLine("Vacio");
            }
        }

        // ********************
        public bool pasoDe21()
        {
            return (mano.ObtenerTotal() > 21);
        }

        public void perdio()
        {
            Console.WriteLine("La casa se paso de 21...", Nombre);
        }
        // ********************

        //Atributos
        private String Nombre;
        private coleccion mano;
    }
}
