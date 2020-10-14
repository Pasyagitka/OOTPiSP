using System;

namespace Lab05
{
    class Lion : Mammal
    {
        public Lion(string name, int year, string color = "Yellow", string feedingstrategy = "carnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Лев бежит");
        }

        public override string ToString()
        {
            return "Лев: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}
