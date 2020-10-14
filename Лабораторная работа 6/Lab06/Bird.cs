using System;

namespace Lab06
{
    class Bird : Animal
    {
        public Bird(string name, int year, int weight = 1) : base(name, year)
        {
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.omnivore;
        }

        public override void Move()
        {
            Console.WriteLine("Птица летит");
        }

        public override string ToString()
        {
            return "Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}