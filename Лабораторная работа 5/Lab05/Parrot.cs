using System;

namespace Lab05
{
    class Parrot : Bird
    {
        public Parrot(string name, int year, string color = "Green", string feedingstrategy = "carnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Попугай летит");
        }

        public override string ToString()
        {
            return "Попугай: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}
