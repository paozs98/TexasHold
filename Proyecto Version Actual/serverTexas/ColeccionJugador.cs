using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverTexas {
    public class ColeccionJugador {
        
        //Atributos 
        public Jugador[] VEC { get; set; }
        public int tamano { get; set; }
        public int cantidad { get; set; }
        //metodos

        public ColeccionJugador(int n) {
            tamano = n;
            VEC = new Jugador[tamano];
            cantidad = 0;
        }
        public ColeccionJugador() {
            tamano = 10;
            VEC = new Jugador[tamano];
            cantidad = 0;
        }


        public bool isVacio() {
            return (cantidad == 0);
        }

        public void reemplazarJugador(int pos, Jugador c) {
            if (pos < cantidad) { VEC[cantidad++] = c; }
        }

        public bool agregarJugador(Jugador jug) {
            if (cantidad < tamano) {
                VEC[cantidad++] = jug;
                return true;
            }
            return false;
        }

        public void limpiar() {
            for (int i = 0; i <= tamano; i++) {
                VEC[i] = null;
            }
        }

        public void imprimirColeccion() {
            for (int i = 0; i < cantidad; i++) {
                VEC[i].ToString();
            }
        }

        public void eliminarUltimo() {
            cantidad--;
        }

        public Jugador GetJugadorEnLaPos(int pos) {

            if (pos > cantidad || pos < 0) {
                return null;
            } else {
                return VEC[pos];

            }
        }


        /*public static string convertirColeccionJugadorAJson(ColeccionJugador j) {
            return JsonConvert.SerializeObject(j);
        }

        public static ColeccionJugador convertirJSONaColeccionJugador(string j) {
            ColeccionJugador colecionux = new ColeccionJugador();
            colecionux = JsonConvert.DeserializeObject<ColeccionJugador>(j);
            return colecionux;
        }*/


        public int GetPosJugador(Jugador j)
        {
            for (int i = 1; i <= cantidad; i++)
            {
                if (VEC[i].nombre == j.nombre)
                {
                    return i;

                }


            }
            return 0;

        }



    }//cierre de la clase

}
