using System;

namespace Lab06
{
    internal class Lion : Mammal
    {
        public Lion(string name, int year, int weight = 55) : base(name, year)
        {
            if  (weight < 0)
                throw new WrongWeightException("Вес не может быть отрицательным!");
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.carnivore;
        }

        public override void Move()
        {
            Console.WriteLine("Лев бежит");
        }

        public override string ToString()
        {
            return "Лев: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}