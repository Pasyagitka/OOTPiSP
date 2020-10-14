using System;

namespace Lab06
{
    class Bird : Animal
    {
        public Bird(string name, int year, string color = "Yellow", string feedingstrategy = "omnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Птица летит");
        }

        public override string ToString()
        {
            return "Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}