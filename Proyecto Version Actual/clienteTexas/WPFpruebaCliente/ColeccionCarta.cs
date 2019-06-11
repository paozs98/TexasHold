using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFpruebaCliente {
    //Clase que se encarga de tener las cartas de lo jugadores 
    // o de la mesa en si ya que la mesa tiene que tener una coleccion de  52 cartas
    public class ColeccionCarta {

        //Atributos
        public Carta[] VEC { get; set; }
        public int tamano { get; set; }
        public int cantidad { get; set; }

        //Metodos 
        public ColeccionCarta(int n) {
            tamano = n;
            VEC = new Carta[tamano];
            cantidad = 0;
        }
        public ColeccionCarta() {
            tamano = 10;
            VEC = new Carta[tamano];
            cantidad = 0;
        }
        public bool isVacio() {
            return (cantidad == 0);
        }
        public Carta obtenerCarta(int pos) {
            if (pos < cantidad) {
                return VEC[pos];
            } else { return null; }
        }
        public void reemplazarCarta(int pos, Carta c) {
            if (pos < cantidad) {
                VEC[pos] = c;
            }
        }
        public bool agregarCarta(Carta car) {
            if (cantidad < tamano) {
                VEC[cantidad++] = car;
                return true;
            } else { return false; }
        }
        public void limpiar() {
            for (int i = 0; i < tamano; i++) {
                VEC[i] = null;
            }
        }
        public void ImprimeColeccion() {
            for (int i = 0; i < cantidad; i++) {
                VEC[i].imprimir();
            }
        }
        public void eliminarUltimo() {
            cantidad--;
        }

        /*public static string convertirColeccionCartaAJson(ColeccionCarta j) {
            return JsonConvert.SerializeObject(j);
        }

        public static ColeccionCarta convertirJSONaColeccionCarta(string j) {
            ColeccionCarta juga = new ColeccionCarta();
            juga = JsonConvert.DeserializeObject<ColeccionCarta>(j);
            return juga;
        }*/


    }//cierre de la clase

}
