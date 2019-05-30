using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    //Clase para darle el formato a las 52 cartas que tiene que esta en el juego
    public class Carta
    {
        public enum VALOR { DOS = 2, TRES, CUATRO, CINCO, SEIS, SIETE, OCHO, NUEVE, DIEZ, JOTA, QUINA, KA, AS };
        public enum PALO { DIAMANTE = 1, TREBOL, CORAZON, ESPADA };
        //Atributos de las cartas 
        private int valor;
        private int palo;
        bool c_CartaArriba;

        public Carta(int valor, int palo, bool estado)
        {
            this.valor = valor;
            this.palo = palo;
            this.c_CartaArriba = estado;
        }

        public static string ValorToString(int valor)
        {
            switch (valor)
            {
                case 11:
                    return "JOTA";
                case 12:
                    return "QUINA";
                case 13:
                    return "KA";
                case 14:
                    return "AS";
                default:
                    return valor.ToString();
            }

        }

        public static string PaloToString(int naipe)
        {
            switch (naipe)
            {
                case 1:
                    return "DIAMANTES";
                case 2:
                    return "TREBOL";
                case 3:
                    return "CORAZONES";
                default:
                    return "ESPADAS";
            }
        }

        public void Voltear()
        {
            this.c_CartaArriba = !(c_CartaArriba);
        }

        public int GetValor()
        {
            return this.valor;
        }

        public int GetPalo()
        {
            return this.palo;
        }

        public void SetValor(VALOR rango)
        {
            this.valor = (int)rango;
        }

        public void SetPalo(PALO fam)
        {
            this.palo = (int)fam;
        }

        public override string ToString()
        {
            return ValorToString(valor) + "\tde\t" + PaloToString(palo);
        }

    }
}
