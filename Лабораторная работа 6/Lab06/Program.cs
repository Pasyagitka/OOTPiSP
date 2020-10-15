using System;

namespace Lab06
{
    class Program
    {
        private static void Main(string[] args)
        {
            Animal crocodile1 = new Crocodile("crocodile", 2026);
            Console.WriteLine(crocodile1); crocodile1.Move();

            Lion lion1 = new Lion("lion", 2010);
            Lion lion2 = new Lion("lion", 2017);
            Console.WriteLine(lion1); lion1.Move();
            Tiger tiger1 = new Tiger("tiger", 2001);
            Console.WriteLine(tiger1); tiger1.Move();

            Shark shark1 = new Shark("shark", 2014);
            Console.WriteLine(shark1); shark1.Move();
            ((IVitalActivity)shark1).Eat();
            shark1.VitalActivity();
            ((IVitalActivity)shark1).VitalActivity();

            Owl owl1 = new Owl("owl", 2003);
            owl1.Move();
            Console.WriteLine(owl1);
            Parrot parrot1 = new Parrot("parrot", 2020);
            parrot1.Move();
            Console.WriteLine(parrot1);

            Console.WriteLine("-----------------Массив-----------------");
            Printer a = new Printer();
            Animal[] animals = new Animal[6] { crocodile1, lion1, tiger1, shark1, owl1, parrot1 };
            for (int i = 0; i < animals.Length; i++)
            {
                a.iAmPrinting(animals[i]);
            }

            Zoo zoo = new Zoo();
            zoo.AddToZoo(crocodile1);
            zoo.AddToZoo(lion1);
            zoo.AddToZoo(lion2);
            zoo.AddToZoo(tiger1);
            zoo.AddToZoo(shark1);
            zoo.AddToZoo(owl1);
            zoo.AddToZoo(parrot1);
            zoo.ShowZoo();
            Controller.AverageWeight(zoo, "lion");
            Console.WriteLine("Количество хищных птиц в зоопарке: {0} ", Controller.PredatoryBirds(zoo));
            Controller.SortByYear(zoo);

            Zoo zoo1 = new Zoo();
            Controller.FillFromFile(zoo1);
            zoo1.ShowZoo();
        }
    }
}