using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    public class Carta
    {
        public enum Rango { AS = 1, DOS, TRES, CUATRO, CINCO, SEIS, SIETE, OCHO, NUEVE, DIEZ, JOTA, REINA, REY };
        public enum Palo { TREBOL, DIAMANTES, CORAZONES, ESPADAS };

        public Carta(int r, int p, bool est)
        {
            c_rango = ConvertirRango(r);
            c_palo = ConvertirP(p);
            c_CartaArriba = est;
        }

        public Rango ConvertirRango(int n)
        {
            Rango r = Rango.AS;
            switch (n)
            {
                case 1: { r = Rango.AS; break; }
                case 2: { r = Rango.DOS; break; }
                case 3: { r = Rango.TRES; break; }
                case 4: { r = Rango.CUATRO; break; }
                case 5: { r = Rango.CINCO; break; }
                case 6: { r = Rango.SEIS; break; }
                case 7: { r = Rango.SIETE; break; }
                case 8: { r = Rango.OCHO; break; }
                case 9: { r = Rango.NUEVE; break; }
                case 10: { r = Rango.DIEZ; break; }
                case 11: { r = Rango.JOTA; break; }
                case 12: { r = Rango.REINA; break; }
                case 13: { r = Rango.REY; break; }
                default: { r = Rango.AS; break; }
            }
            return r;
        }

        public Palo ConvertirP(int n)
        {
            Palo r = Palo.DIAMANTES;
            switch (n)
            {
                case 0: { r = Palo.TREBOL; break; }
                case 1: { r = Palo.DIAMANTES; break; }
                case 2: { r = Palo.CORAZONES; break; }
                case 3: { r = Palo.ESPADAS; break; }
                default: { r = Palo.TREBOL; break; }
            }
            return r;
        }


        public int ObtenerValor()
        {
            int valorCarta = 0;

            if (c_CartaArriba)
            {
                valorCarta = (int)c_rango;
                if (valorCarta > 10)
                {
                    valorCarta = 10;
                }
            }

            return valorCarta;
        }

        public int mostrarP()
        {
            return ((int)c_palo);
        }

        public void Voltear()
        {
            c_CartaArriba = !(c_CartaArriba);
        }

        public void toString()
        {
            string[] cartas = { "0", "A", "2","3","4","5",
                "6","7","8","9","10","J","Q","K" };

            string[] palos = { "T", "D", "C", "E" };


            if (c_CartaArriba)
            {
                Console.WriteLine("{0}-{1}", cartas[((int)c_rango)], palos[((int)c_palo)]);
            }
            else
            {
                Console.WriteLine("Vacio");
            }
        }

        // Atributos
        private Rango c_rango;
        private Palo c_palo;
        bool c_CartaArriba;
    }
}
