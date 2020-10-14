using System;

namespace Lab05
{
    abstract class Mammal : Animal
    {
        public Mammal(string name, int year, string color = "White", string feedingstrategy = "omnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Животное бежит");
        }

        public override string ToString()
        {
            return "Млекопитающее: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}