using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    public class jugador
    {
        private String Nombre;
        private String Id;
        private coleccion mano;


        public jugador(String nom, String id)
        {
            Nombre = nom;
            Id = id;
            mano = new coleccion(7);
        }
        public void setNombre(String nombre)
        {
            Nombre = nombre;
        }
        public String getNombre()
        {
            return Nombre;
        }
        public void setId(String id)
        {
            Id = id;
        }
        public String getId()
        {
            return Id;
        }


        public bool pedirCarta()
        {
            String r = "";
            Console.WriteLine("Desea tomar Carta? [S/N] Jugador: {0}", Nombre);
            r = Console.ReadLine().ToUpper();
            return (r == "S");
        }//Ya no 


        // ***************************
        public bool pasoDe21()
        {
            return (mano.ObtenerTotal() > 21);
        }

        public void perdio()
        {
            Console.WriteLine("El jugador {0} se paso de 21...", Nombre);
        }
        // ****************************

        public void gana()
        {
            Console.WriteLine("{0} es el ganador---", Nombre);
        }

        public void pierde()
        {
            Console.WriteLine("{0} pierde...", Nombre);
        }

        public void push()
        {
            Console.WriteLine("{0} push....", Nombre);
        }

        public coleccion obtenerMano()
        {
            return mano;
        }

        public void toString()
        {
            Console.WriteLine("Nombre del jugador: {0}", Nombre);
            Console.WriteLine("Id del jugador: {0}", Id);

            if (!obtenerMano().empty())
            {
                obtenerMano().imprimirColeccion();
                if (obtenerMano().ObtenerTotal() != 0)
                {
                    Console.WriteLine("({0})", obtenerMano().ObtenerTotal());
                }
            }
            else
            {
                Console.WriteLine("Vacio");
            }
        }

    }
}
