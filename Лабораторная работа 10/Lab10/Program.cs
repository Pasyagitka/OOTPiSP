using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10
{
    public class Concert : IList<Concert> //Реализовать интерфейс
    {
        // соберите объекты класса в коллекцию
        public IList<Concert> ConcertList = new List<Concert>();
        public string Name { get; set; }
        public Concert(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return "Концерт: \"" + Name + "\"";
        }

        public int Count { get { return ConcertList.Count; } }
        public bool IsReadOnly { get { return ConcertList.IsReadOnly; } }
        public Concert this[int index] { get { return ConcertList[index]; } set  { ConcertList[index] = value; } }
        public int IndexOf(Concert item)
        {
            return ConcertList.IndexOf(item);
        }
        public void Insert(int index, Concert item)
        {
            ConcertList.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            ConcertList.RemoveAt(index);
        }
        public void Add(Concert item)
        {
            ConcertList.Add(item);
        }
        public void Clear()
        {
            ConcertList.Clear();
            Console.WriteLine("Список очищен.");
        }
        public bool Contains(Concert item)
        {
            return ConcertList.Contains(item);
        }
        public void CopyTo(Concert[] array, int arrayIndex)
        {
            ConcertList.CopyTo(array, arrayIndex);
        }
        public bool Remove(Concert item)
        {
           return ConcertList.Remove(item);
        }
        public IEnumerator<Concert> GetEnumerator()
        {
            return ConcertList.GetEnumerator(); 
        }
        IEnumerator IEnumerable.GetEnumerator()    
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Concert 
            //удалить N последовательных элементов
            Concert conc1 = new Concert("Концерт1"), conc2 = new Concert("Концерт2"), conc3 = new Concert("Концерт3"), conc4 = new Concert("Концерт4");
            Dictionary<int, string> s = new Dictionary<int, string>
            {
                [1] = "Mogilev",  [7] = "Minsk", [2] = "Vitebsk",   [4] = "Brest",  [5] = "Gomel",  [3] = "Grodno"
            };
            s[4] = "Moscow";
            s.Add(10, "Magadan");

            foreach (KeyValuePair<int, string> keyValue in s)
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            Queue<string> q = new Queue<string>();
            foreach  (string v in s.Values)
                q.Enqueue(v);
            foreach (string p in q)
                Console.WriteLine(p);
            if (q.Contains("Vitebsk")) Console.WriteLine("Элемент найден"); else Console.WriteLine("Элемент не найден");
            if (q.Contains("Mir")) Console.WriteLine("Элемент найден"); else Console.WriteLine("Элемент не найден");


            ObservableCollection<Concert> observableconcert = new ObservableCollection<Concert>() {conc1, conc2, conc3};
            void ChangeColl(object sender, NotifyCollectionChangedEventArgs a)
            {
                if (a.Action == NotifyCollectionChangedAction.Add)
                {
                    Concert newconc = a.NewItems[0] as Concert;
                    Console.WriteLine("Добавлен новый объект: " + newconc.Name);
                }
                if (a.Action == NotifyCollectionChangedAction.Remove)
                {
                    Concert oldconc = a.OldItems[0] as Concert;
                    Console.WriteLine("Удален объект: " + oldconc.Name);
                }
            }
            observableconcert.CollectionChanged += ChangeColl;
            observableconcert.Remove(conc2);
            observableconcert.Add(conc4);
            observableconcert.Remove(conc1);
        }
    }
}