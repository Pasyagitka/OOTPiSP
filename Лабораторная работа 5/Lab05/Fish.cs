using System;

namespace Lab05
{
    abstract class Fish : Animal, IVitalActivity
    {
        public Fish(string name, int year, string color = "Blue", string feedingstrategy = "omnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Рыба плывет");
        }

        public void Eat()
        {
            Console.WriteLine("Рыба ест");
        }

        public void Sleep()
        {
            Console.WriteLine("Рыба спит... ZzZ...");
        }

        public override string ToString()
        {
            return "Рыба: Name: " + name + ", Year: " + dateOfBirth + ", Color: " + color + ", Feeding Strategy: " + feedingStrategy;
        }

        public abstract void VitalActivity();
    }
}