using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WPFpruebaCliente {
    //Clase para darle el formato a las 52 cartas que tiene que esta en el juego
    public class Carta {
        public enum VALOR { DOS = 2, TRES, CUATRO, CINCO, SEIS, SIETE, OCHO, NUEVE, DIEZ, JOTA, QUINA, KA, AS };
        public enum PALO { DIAMANTE = 1, TREBOL, CORAZON, ESPADA };


        //Atributos de las cartas 
        public int valor { get; set; }
        public int palo { get; set; }

        public Carta()
        {
            valor = -1;
            palo = -1;
        }

        public Carta(int valor, int palo)
        {
            this.valor = valor;
            this.palo = palo;
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
                    return "CORAZONES";
                case 2:
                    return "DIAMANTE";
                case 3:
                    return "TREBOL";
                default:
                    return "ESPADAS";
            }
        }

        public string imprimir()
        {

            return ValorToString(valor) + "\tde\t" + PaloToString(palo);
        }

        public string getCodigo() {
            return (string)""+palo +valor;
        }
        /*public static string convertirCartaAJson(Carta j) {
            return JsonConvert.SerializeObject(j);
        }

        public static Carta convertirJSONaCarta(string j) {
            Carta cartiux = new Carta();
            cartiux = JsonConvert.DeserializeObject<Carta>(j);
            return cartiux;
        }*/

    }
}
