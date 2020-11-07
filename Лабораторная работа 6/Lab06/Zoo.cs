using System;
using System.Collections.Generic;

namespace Lab06
{
    public class Zoo
    {
        public List<Animal> List = new List<Animal>();
        //private string name;
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}

        public void AddToZoo(Animal exemplar)
        {
            List.Add(exemplar);
        }
        public void RemoveFromZoo(Animal exemplar)
        {
            List.Remove(exemplar);
        }
        public void ShowZoo()
        {
            foreach (var exemplar in List)
                Console.WriteLine(exemplar);
        }
    }
}
