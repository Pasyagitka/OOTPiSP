using System;

namespace Lab06
{
    class Owl : Bird
    {
        public Owl(string name, int year, string color = "Grey", string feedingstrategy = "carnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Сова летит");
        }

        public override string ToString()
        {
            return "Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}
