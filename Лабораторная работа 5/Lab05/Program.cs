using System;

namespace Lab05
{
    class Program
    {
        private static void Main(string[] args)
        {
            Animal crocodile1 = new Crocodile("crocodile1", 2026);
            Console.WriteLine(crocodile1); crocodile1.Move();

            Lion lion1 = new Lion("lion1", 2010);
            Console.WriteLine(lion1); lion1.Move();
            Tiger tiger1 = new Tiger("tiger1", 2001);
            Console.WriteLine(tiger1); tiger1.Move();

            Shark shark1 = new Shark("shark1", 2014);
            Console.WriteLine(shark1); shark1.Move();
            ((IVitalActivity)shark1).Eat();
            shark1.VitalActivity();
            ((IVitalActivity)shark1).VitalActivity();

            Owl owl1 = new Owl("owl1", 2003);
            owl1.Move();
            Console.WriteLine(owl1);
            Parrot parrot1 = new Parrot("Гоша", 2020);
            parrot1.Move();
            Console.WriteLine(parrot1);

            Console.WriteLine("-----------------Массив-----------------");
            Printer a = new Printer();
            Animal[] animals = new Animal[6] { crocodile1, lion1, tiger1, shark1, owl1, parrot1 };
            for (int i = 0; i < animals.Length; i++)
            {
                a.iAmPrinting(animals[i]);
            }
        }
    }
}