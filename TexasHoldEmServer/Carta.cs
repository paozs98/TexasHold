using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEmServer
{
    public enum RANGO
    {
        DOS = 2,
        TRES,
        CUATRO,
        CINCO,
        SEIS,
        SIETE,
        OCHO,
        NUEVE,
        DIEZ,
        JOTA,
        QUEEN,
        KA,
        AS
    }
    public enum FAMILIA
    {
        DIAMANTE = 1,
        TREBOL,
        CORAZON,
        ESPADA
    }
    class Carta
    {
        private int valor;
        private int familia;

        //constructor por defecto inicia con una carta 2 de diamantes 
        public Carta()
        {
            valor = (int)RANGO.DOS;
            familia = (int)FAMILIA.DIAMANTE;
        }

        public Carta(RANGO rank, FAMILIA nai)
        {
            this.valor = (int)rank;
            this.familia = (int)nai;
        }

        public Carta(int rango, int naipe)
        {
            if (rango < 1 || rango > 14 || naipe < 1 || naipe > 4)
                throw new ArgumentOutOfRangeException();
            this.familia = naipe;
            this.valor = rango;
        }

        public Carta(Carta c)
        {
            this.valor = c.valor;
            this.familia = c.familia;
        }

        public static string ValorToString(int valor)
        {
            switch (valor)
            {
                case 11:
                    return "Jota";
                case 12:
                    return "Quina";
                case 13:
                    return "Ka";
                case 14:
                    return "AS";
                default:
                    return valor.ToString();
            }

        }

        public static string FamiliaToString(int naipe)
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

        public int GetValor()
        {
            return this.valor;
        }

        public int GetFamilia()
        {
            return this.familia;
        }

        public void SetValor(RANGO rango)
        {
            this.valor = (int)rango;
        }

        public void SetFamilia(FAMILIA fam)
        {
            this.familia = (int)fam;
        }

        public void SetCarta(RANGO rango, FAMILIA palo)
        {
            this.valor = (int)rango;
            this.familia = (int)palo;
        }

        public void SetCarta(int rango, int palo)
        {
            if (rango < 1 || rango > 14 || palo < 1 || palo > 4)
                throw new ArgumentOutOfRangeException();
            this.valor = rango;
            this.familia = palo;
        }

        public override string ToString()
        {
            return ValorToString(valor) + "\tde\t" + FamiliaToString(familia);
        }

        public static bool operator ==(Carta a, Carta b)
        {
            return (a.valor == b.valor) ? true : false;
        }

        public static bool operator !=(Carta a, Carta b)
        {
            return (a.valor != b.valor) ? true : false;
        }

        public static bool operator <(Carta a, Carta b)
        {
            return (a.valor < b.valor) ? true : false;
        }
        public static bool operator >(Carta a, Carta b)
        {
            return (a.valor > b.valor) ? true : false;
        }
        public static bool operator <=(Carta a, Carta b)
        {
            return (a.valor <= b.valor) ? true : false;
        }
        public static bool operator >=(Carta a, Carta b)
        {
            return (a.valor >= b.valor) ? true : false;
        }
    }//cierre de la clase carta 
}//cierre del namespace
