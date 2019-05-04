using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEmServer
{// la clase para cada mano o Juego de Cada Player
    internal class Mano
    {
        private List<Carta> miMano;
        private List<int> valorMano;

        public Mano()
        {
            miMano = new List<Carta>();
            valorMano = new List<int>();
        }

        public Carta this[int index]
        {
            get
            {
                return miMano[index];
            }
            set
            {
                miMano[index] = value;
            }
        }

        public void Limpiar()
        {
            miMano.Clear();
            valorMano.Clear();
        }

        public void Agregar_Carta(Carta carta)
        {
            miMano.Add(carta);
        }

        public void Quitar_Carta(int index)
        {
            miMano.RemoveAt(index);
        }

        public void Remove(Carta carta)
        {
            miMano.Remove(carta);
        }

        public List<int> GetValorMano()
        {
            return this.valorMano;
        }

        public void SetValorMano(int value)
        {
            valorMano.Add(value);
        }

        public int Total()
        {
            return miMano.Count;
        }

        public Carta GetCarta(int index)
        {
            if (index >= miMano.Count)
                throw new ArgumentOutOfRangeException();
            return miMano[index];
        }

        List<Carta> QuickSortValor(List<Carta> miscartas)
        {
            Carta pivot;
            Random ran = new Random();

            if (miscartas.Count() <= 1)
                return miscartas;

            pivot = miscartas[ran.Next(miscartas.Count())];
            miscartas.Remove(pivot);

            var menor = new List<Carta>();
            var mayor = new List<Carta>();

            foreach (Carta i in miscartas)
            {
                if (i > pivot) { mayor.Add(i); }
                else if (i <= pivot)
                {
                    menor.Add(i);
                }
            }

            var lista = new List<Carta>();
            lista.AddRange(QuickSortValor(mayor));
            lista.Add(pivot);
            lista.AddRange(QuickSortValor(menor));
            return lista;
        }

        List<Carta> QuickSortFamila(List<Carta> misCartas)
        {

            Carta pivot;

            Random ran = new Random();

            if (misCartas.Count() <= 1)
                return misCartas;

            pivot = misCartas[ran.Next(misCartas.Count())];
            misCartas.Remove(pivot);
            var menor = new List<Carta>();
            var mayor = new List<Carta>();
            for (int i = 0; i < misCartas.Count(); i++)
            {
                if (misCartas[i].GetFamilia() > pivot.GetFamilia())
                    mayor.Add(misCartas[i]);
                else if (misCartas[i].GetFamilia() <= pivot.GetFamilia())
                    menor.Add(misCartas[i]);
            }
            var list = new List<Carta>();
            list.AddRange(QuickSortFamila(menor));
            list.Add(pivot);
            list.AddRange(QuickSortFamila(mayor));
            return list;
        }

        public void OrdenarPorValor()
        {
            miMano = QuickSortValor(miMano);
        }

        public void OrdenarPorFamilia()
        {
            miMano = QuickSortFamila(miMano);
        }

        public override string ToString()
        {
            if (this.valorMano.Count() == 0)
                return "No se a encontrado mano de Poker";

            switch (this.valorMano[0])
            {
                case 1:
                    return Carta.ValorToString(valorMano[1]) + "Carta Alta";
                case 2:
                    return "Parejas de" + Carta.ValorToString(valorMano[1]);
                case 3:
                    return "Dos Parejas " + Carta.ValorToString(valorMano[1]) + "de" + Carta.ValorToString(valorMano[2]);
                case 4:
                    return "Trio de" + Carta.ValorToString(valorMano[1]);
                case 5:
                    return Carta.ValorToString(valorMano[1]) + "Escalera";
                case 6:
                    return Carta.ValorToString(valorMano[1]) + "Color";
                case 7:
                    return Carta.ValorToString(valorMano[1]) + "FULL de " + Carta.ValorToString(valorMano[2]);
                case 8:
                    return "POKER" + Carta.ValorToString(valorMano[1]);
                case 9:
                    return Carta.ValorToString(valorMano[1]) + "Escalera Real";
                default:
                    return "Escalera Real De Color";
            }
        }

        public bool IsEqual(Mano a)
        {
            for (int i = 0; i < a.Total(); i++)
            {
                if (a[i] != miMano[i] || a[i].GetFamilia() != miMano[i].GetFamilia())
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Mano mano &&
                   EqualityComparer<List<Carta>>.Default.Equals(miMano, mano.miMano) &&
                   EqualityComparer<List<int>>.Default.Equals(valorMano, mano.valorMano);
        }

        public override int GetHashCode()
        {
            var hashCode = -849782822;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Carta>>.Default.GetHashCode(miMano);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(valorMano);
            return hashCode;
        }

        public static bool operator ==(Mano a, Mano b)
        {
            if (a.GetValorMano().Count == 0 || b.GetValorMano().Count() == 0)
                throw new NullReferenceException();
            for (int i = 0; i < a.GetValorMano().Count(); i++)
            {
                if (a.GetValorMano()[i] != b.GetValorMano()[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Mano a, Mano b)
        {
            if (a.GetValorMano().Count == 0 || b.GetValorMano().Count() == 0)
                throw new NullReferenceException();
            for (int i = 0; i < a.GetValorMano().Count(); i++)
            {
                if (a.GetValorMano()[i] != b.GetValorMano()[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator <(Mano a, Mano b)
        {
            if (a.GetValorMano().Count == 0 || b.GetValorMano().Count == 0)
                throw new NullReferenceException();
            for (int i = 0; i < a.GetValorMano().Count(); i++)
            {
                if (a.GetValorMano()[i] < b.GetValorMano()[i])
                {
                    return true;
                }
                if (a.GetValorMano()[i] > b.GetValorMano()[i])
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator >(Mano a, Mano b)
        {
            if (a.GetValorMano().Count == 0 || b.GetValorMano().Count == 0)
                throw new NullReferenceException();
            for (int i = 0; i < a.GetValorMano().Count(); i++)
            {
                if (a.GetValorMano()[i] > b.GetValorMano()[i])
                {
                    return true;
                }
                if (a.GetValorMano()[i] < b.GetValorMano()[i])
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator <=(Mano a, Mano b)
        {
            if (a.GetValorMano().Count == 0 || b.GetValorMano().Count == 0)
                throw new NullReferenceException();
            for (int i = 0; i < a.GetValorMano().Count(); i++)
            {
                if (a.GetValorMano()[i] < b.GetValorMano()[i])
                {
                    return true;
                }
                if (a.GetValorMano()[i] > b.GetValorMano()[i])
                {
                    return false;
                }

            }
            return true;
        }

        public static bool operator >=(Mano a, Mano b)
        {
            if (a.GetValorMano().Count == 0 || b.GetValorMano().Count == 0)
                throw new NullReferenceException();
            for (int i = 0; i < a.GetValorMano().Count(); i++)
            {
                if (a.GetValorMano()[i] > b.GetValorMano()[i])
                {
                    return true;
                }
                if (a.GetValorMano()[i] < b.GetValorMano()[i])
                {
                    return false;
                }

            }
            return true;
        }

        public static Mano operator +(Mano a, Mano b)
        {
            for (int i = 0; i < b.Total(); i++)
            {
                a.Agregar_Carta(b[i]);
            }
            return a;
        }



    }//Cierre de la clase Mano
}
