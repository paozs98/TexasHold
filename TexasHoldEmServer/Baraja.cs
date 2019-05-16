using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemServer {
    class Baraja {
        private List<Carta> deck = new List<Carta>();

        public Baraja() {
            for (int i = 2; i <= 14; i++) {
                for (int j = 1; j <= 4; j++) {
                    deck.Add(new Carta(i, j));
                }
            }
        }

        public Baraja(Baraja laOtra) {
            foreach (Carta carta in laOtra.deck) {
                this.deck.Add(new Carta(carta));
            }
        }

        public void AgregarA_LaBaraja(Carta carta) {
            deck.Add(carta);
        }

        public int Cartar_sobrantes() {
            return deck.Count;
        }

        public void Barajar() {
            var rand = new Random();
            for (int i = Cartar_sobrantes() - 1; i > 0; i--) {
                int n = rand.Next(i + 1);
                Carta temporal = deck[i];
                deck[i] = deck[n];
                deck[n] = temporal;
            }
        }

        public string ToSring() {
            string salida = "";
            foreach (Carta carta in deck) {
                salida += carta.ToString() + " ";
            }
            return salida;
        }

        public void Quitar(int index) {
            if (index < 0 || index >= deck.Count)
                throw new ArgumentOutOfRangeException();
            deck.RemoveAt(index);
        }

        public void Quitar(Carta carta) {
            for (int i = 0; i < deck.Count; i++) {
                if (deck[i] == carta && deck[i].GetFamilia() == carta.GetFamilia()) {
                    deck.RemoveAt(i);
                }
            }
        }

        public Carta[] ToArray() {
            return deck.ToArray();
        }
        public List<Carta> ToList() {
            return deck;
        }

    }
}
