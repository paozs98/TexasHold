using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFpruebaCliente {
    public class Pot {

        public int apuestaMinima { get; set; }
        public int apuestaMaxima { get; set; }
        public int sumatoriaDeApuesta { get; set; }

        public Pot() {
            sumatoriaDeApuesta = 0;
            apuestaMinima = 50;
            apuestaMaxima = 100;
        }

        /*public static string convertirPotAJson(Pot j) {
            return JsonConvert.SerializeObject(j);
        }

        public static Pot convertirJSONaPot(string j) {
            Pot juga = new Pot();
            juga = JsonConvert.DeserializeObject<Pot>(j);
            return juga;
        }*/

    }
}
