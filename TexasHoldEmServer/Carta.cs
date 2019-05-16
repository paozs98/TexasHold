using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemServer {
    public enum VALOR {
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
    public enum PALO {
        DIAMANTE = 1,
        TREBOL,
        CORAZON,
        ESPADA
    }

    internal class Carta {
        private int valor;
        private int palo;

        //constructor por defecto inicia con una carta 2 de diamantes 
        public Carta() {
            valor = (int)VALOR.DOS;
            palo = (int)PALO.DIAMANTE;
        }

        public Carta(VALOR rank, PALO nai) {
            this.valor = (int)rank;
            this.palo = (int)nai;
        }

        public Carta(int rango, int naipe) {
            if (rango < 1 || rango > 14 || naipe < 1 || naipe > 4)
                throw new ArgumentOutOfRangeException();
            this.palo = naipe;
            this.valor = rango;
        }

        public Carta(Carta c) {
            this.valor = c.valor;
            this.palo = c.palo;
        }

        public static string ValorToString(int valor) {
            switch (valor) {
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

        public static string PaloToString(int naipe) {
            switch (naipe) {
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

        public int GetValor() {
            return this.valor;
        }

        public int GetPalo() {
            return this.palo;
        }

        public void SetValor(VALOR rango) {
            this.valor = (int)rango;
        }

        public void SetPalo(PALO fam) {
            this.palo = (int)fam;
        }

        public void SetCarta(VALOR rango, PALO palo) {
            this.valor = (int)rango;
            this.palo = (int)palo;
        }

        public void SetCarta(int rango, int palo) {
            if (rango < 1 || rango > 14 || palo < 1 || palo > 4)
                throw new ArgumentOutOfRangeException();
            this.valor = rango;
            this.palo = palo;
        }

        public override string ToString() {
            return ValorToString(valor) + "\tde\t" + PaloToString(palo);
        }

        public static bool operator ==(Carta a, Carta b) {
            return (a.valor == b.valor) ? true : false;
        }

        public static bool operator !=(Carta a, Carta b) {
            return (a.valor != b.valor) ? true : false;
        }

        public static bool operator <(Carta a, Carta b) {
            return (a.valor < b.valor) ? true : false;
        }
        public static bool operator >(Carta a, Carta b) {
            return (a.valor > b.valor) ? true : false;
        }
        public static bool operator <=(Carta a, Carta b) {
            return (a.valor <= b.valor) ? true : false;
        }
        public static bool operator >=(Carta a, Carta b) {
            return (a.valor >= b.valor) ? true : false;
        }


    }
}
