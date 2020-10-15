using System;

namespace Lab06
{
    internal sealed class Crocodile : Animal
    {
        public Crocodile(string name, int year, int weight = 30) : base(name, year)
        {
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.carnivore;
        }

        public override void Move()
        {
            Console.WriteLine("Крокодил ползёт");
        }

        public override string ToString()
        {
            return "Крокодил: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}