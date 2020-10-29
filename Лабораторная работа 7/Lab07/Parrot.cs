using System;

namespace Lab06
{
    internal class Parrot : Bird
    {
        public Parrot(string name, int year, int weight = 1) : base(name, year)
        {
            if (weight < 0)
                throw new WrongWeightException("Вес не может быть отрицательным!");
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.herbivore;
        }

        public override void Move()
        {
            Console.WriteLine("Попугай летит");
        }

        public override string ToString()
        {
            return "Попугай: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}