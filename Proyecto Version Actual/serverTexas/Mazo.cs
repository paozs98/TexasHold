using Newtonsoft.Json;
using System;

namespace serverTexas
{
    //Esta clase tiene un coleccion de 52 cartas para el juego que son las que se van a repartir 
    public class Mazo {
        //Atributos 
        public ColeccionCarta MAZO { get; set; }


        //Metodos
        public Mazo() {
            MAZO = new ColeccionCarta(52);
            llenarMazo();
        //    barajar();
        }

        //public void llenarMazo() {
        //    for (int pal = ((int)Carta.PALO.DIAMANTE); pal <= ((int)Carta.PALO.ESPADA); ++pal) {
        //        for (int c = ((int)Carta.VALOR.AS); c <= ((int)Carta.VALOR.KA); ++c) {
        //            MAZO.agregarCarta(new Carta(c, pal));
        //            Console.WriteLine("carta " + c +"palo "+pal);
        //        }
        //    }
        //}

        public void llenarMazo() {
            for (int p = 1; p <= 4; p++) {
                for (int v = 2; v <= 14; v++) {
                    MAZO.agregarCarta(new Carta(v, p));
                }
            }

        }


        public void barajar() {
            Random rnd = new Random();
            Carta temp;
            int num;

            for (int i = 0; i < MAZO.cantidad; ++i) {
                num = rnd.Next(0, MAZO.cantidad);
                temp = MAZO.obtenerCarta(i);
                MAZO.reemplazarCarta(i, MAZO.obtenerCarta(num));
                MAZO.reemplazarCarta(num, temp);
            }

        }

        public void mostrarMazo() {
            MAZO.ImprimeColeccion();
        }

        public Carta darUnaCarta() {
            if (!MAZO.isVacio()) {
                Carta cartaADar = MAZO.obtenerCarta(MAZO.cantidad - 1);
                MAZO.eliminarUltimo();
                return cartaADar;
            } else {
                Console.WriteLine("No hay cartas en el Mazo");
                return null;
            }

        }

        /*public static string convertirMazoAJson(Mazo j) {
            return JsonConvert.SerializeObject(j);
        }

        public static Mazo convertirJSONaMazo(string j) {
            Mazo maziux = new Mazo();
            maziux = JsonConvert.DeserializeObject<Mazo>(j);
            return maziux;
        }*/


    } // Cierre de la clase Mazo 

}
