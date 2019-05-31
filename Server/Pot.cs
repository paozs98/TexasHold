using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Pot
    {
        private int apuestaMinima;
        private int apuestaMaxima;
        private int sumatoriaDeApuesta;

        public Pot()
        {
            sumatoriaDeApuesta = 0;
            apuestaMinima = 50;
            apuestaMaxima = 100;
        }
        public void setApuestaMinima(int min) { apuestaMinima = min; }
        public void setApuestaMaxima(int min) { apuestaMaxima = min; }
        public void setSumatoriaDeApuesta(int min) { sumatoriaDeApuesta = min; }
        public int getApuestaMinima() { return apuestaMinima; }
        public int getApuestaMaxima() { return apuestaMaxima; }
        public int getSumatoriaDeApuesta() { return sumatoriaDeApuesta; }

    }
}
