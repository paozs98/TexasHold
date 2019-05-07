using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEmServer
{
    class ListaJugadores 
    {
        List<Jugador> list = new List<Jugador>();
        public ListaJugadores()
        {
        }
      
        public void CopyTo(Jugador[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public ListaJugadores(ListaJugadores PlayerList)
        {
            this.list.AddRange(PlayerList.list);
        }

        public void Add(Jugador item)
        {
            list.Add(item);
        }

        public int IndexOf(Jugador item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, Jugador item)
        {
            list.Insert(index, item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(Jugador item)
        {
            return list.Contains(item);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public IEnumerator<Jugador> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public bool Remove(Jugador item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public Jugador this[int index]
        {
            
            get
            {
                while (index > list.Count() - 1)
                    index -= list.Count();
                while (index < 0)
                    index += list.Count();
                return list[index];
            }
            set
            {
                while (index > list.Count() - 1)
                    index -= list.Count();
                while (index < 0)
                    index += list.Count();
                list[index] = value;
            }
        }

        public Jugador GetJugador(ref int index)
        {
            while (index > list.Count() - 1)
                index -= list.Count();
            while (index < 0)
                index += list.Count();
            return list[index];
        }

        

    }
}


