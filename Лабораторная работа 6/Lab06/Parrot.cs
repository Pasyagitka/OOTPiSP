using System;

namespace Lab06
{
    class Parrot : Bird
    {
        public Parrot(string name, int year, int weight = 1) : base(name, year)
        {
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
