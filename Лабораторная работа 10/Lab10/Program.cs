using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10
{
    public class Concert : IList<string>
    {
        public IList<string> ArtistsList = new List<string>();
        public string Name { get; set; }
        public Concert(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
           string buff = default;
           foreach (string artist in ArtistsList)
                buff += artist + " ";
            return "Концерт: \"" + Name + "\"" + ", список артистов: " + buff;
        }

        public int Count { get { return ArtistsList.Count; } }
        public bool IsReadOnly { get { return ArtistsList.IsReadOnly; } }
        public string this[int index] { get { return ArtistsList[index]; } set  { ArtistsList[index] = value; } }
        public int IndexOf(string item)
        {
            return ArtistsList.IndexOf(item);
        }
        public void Insert(int index, string item)
        {
            ArtistsList.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            ArtistsList.RemoveAt(index);
        }
        public void Add(string item)
        {
            ArtistsList.Add(item);
        }
        public void Clear()
        {
            ArtistsList.Clear();
            Console.WriteLine("Список очищен.");
        }
        public bool Contains(string item)
        {
            return ArtistsList.Contains(item);
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            ArtistsList.CopyTo(array, arrayIndex);
        }
        public bool Remove(string item)
        {
           return ArtistsList.Remove(item);
        }
        public IEnumerator<string> GetEnumerator()
        {
            return ArtistsList.GetEnumerator(); 
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
            const int N = 3; int i = 0;
            Concert conc1 = new Concert("Концерт1"), conc2 = new Concert("Концерт2"), conc3 = new Concert("Концерт3"), conc4 = new Concert("Концерт4");
            conc1.Add("Артист1");
            conc1.Add("Артист2");
            conc1.Add("Артист3");
            conc1.Add("Артист4");
            conc1.Remove("Артист3");
            Console.WriteLine(conc1);
            Dictionary<int, Concert> concertcollection = new Dictionary<int, Concert>()
            {
                [155] = conc1, [12] = conc2, [468] = conc3, [95] = conc4,
            };
            concertcollection.Add(3698, new Concert("Концерт347"));
            concertcollection.Remove(468);
            if (concertcollection.ContainsKey(458)) Console.WriteLine("Концерт с таким ключом присутсвует в словаре"); else Console.WriteLine("Концерт с таким ключом отсутсвует в словаре");
            if (concertcollection.ContainsKey(3698)) Console.WriteLine("Концерт с таким ключом присутсвует в словаре"); else Console.WriteLine("Концерт с таким ключом отсутсвует в словаре");
            foreach (KeyValuePair<int, Concert> keyValue in concertcollection)
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);


            Dictionary<int, string> s = new Dictionary<int, string>
            {
                [1] = "Mogilev",  [7] = "Minsk", [2] = "Vitebsk",   [4] = "Brest",  [5] = "Gomel",  [3] = "Grodno"
            };
            s[4] = "Moscow";
            s.Add(10, "Magadan");
            foreach (KeyValuePair<int, string> keyValue in s)
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            //удаляю N=3 первых
            foreach (int  k in s.Keys)
            {
                if (i++ == N) break;
                s.Remove(k); 
            }
            foreach (KeyValuePair<int, string> keyValue in s)
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);

            Queue<string> q = new Queue<string>();
            foreach  (string v in s.Values)
                q.Enqueue(v);
            foreach (string p in q)
                Console.WriteLine(p);
            if (q.Contains("Gomel")) Console.WriteLine("Элемент найден"); else Console.WriteLine("Элемент не найден");
            if (q.Contains("Mir")) Console.WriteLine("Элемент найден"); else Console.WriteLine("Элемент не найден");


            ObservableCollection<Concert> observableconcert = new ObservableCollection<Concert>() {conc1, conc2, conc3};
            void ChangeColl(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Concert newconc = e.NewItems[0] as Concert;
                    Console.WriteLine("Добавлен новый объект: " + newconc.Name);
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Concert oldconc = e.OldItems[0] as Concert;
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