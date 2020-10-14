using System;

namespace Lab06
{
    sealed class Crocodile : Animal
    {
        public Crocodile(string name, int year, string color = "Green", string feedingstrategy = "carnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Крокодил ползёт");
        }

        public override string ToString()
        {
            return "Крокодил: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}
