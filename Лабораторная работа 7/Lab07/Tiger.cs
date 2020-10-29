using System;

namespace Lab06
{
    internal class Tiger : Mammal
    {
        public Tiger(string name, int year, int weight = 20) : base(name, year)
        {
            if (weight < 0)
                throw new WrongWeightException("Вес не может быть отрицательным!");
            this.weight = weight;
            this.feedingStrategy = feedingStrategies.carnivore;
        }

        public override void Move()
        {
            Console.WriteLine("Тигр бежит");
        }

        public override string ToString()
        {
            return "Тигр: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}