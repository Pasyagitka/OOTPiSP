using System;

namespace Lab06
{
    abstract class Mammal : Animal
    {
        public Mammal(string name, int year, int weight = 40) : base(name, year)
        {
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.omnivore;
        }

        public override void Move()
        {
            Console.WriteLine("Животное бежит");
        }

        public override string ToString()
        {
            return "Млекопитающее: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}