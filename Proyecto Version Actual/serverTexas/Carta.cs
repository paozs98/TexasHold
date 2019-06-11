using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace serverTexas {
    
    public class Carta {

        public enum VALOR { DOS = 2, TRES, CUATRO, CINCO, SEIS, SIETE, OCHO, NUEVE, DIEZ, JOTA, QUINA, KA, AS };
        public enum PALO { DIAMANTE = 1, TREBOL, CORAZON, ESPADA };

        public int valor { get; set; }
        public int palo { get; set; }

        public Carta() {
            valor = -1;
            palo = -1;
        }

        public Carta(int valor, int palo) {
            this.valor = valor;
            this.palo = palo;
        }

        public static string ValorToString(int valor) {
            switch (valor) {
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

        public static string PaloToString(int naipe) {
            switch (naipe) {
                case 1:
                    return "CORAZONES";
                case 2:
                    return "DIAMANTE";
                case 3:
                    return "TREBOL";
                default:
                    return "ESPADAS";
            }
        }

        public string imprimir() {

            return ValorToString(valor) + " de " + PaloToString(palo);
        }
        
        public string getCodigo()
        {
            int p = palo - 1;
            int v;
            if (valor == 14)
                v = valor;
            else { v = valor + 2; }
            return (string)"" + p + v;
        }
        
    }
}
