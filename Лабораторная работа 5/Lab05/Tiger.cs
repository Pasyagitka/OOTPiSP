using System;

namespace Lab05
{
    class Tiger : Mammal
    {
        public Tiger(string name, int year, string color = "Orange", string feedingstrategy = "carnivore") : base(name, year)
        {
            this.color = color;
            this.feedingStrategy = feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Тигр бежит");
        }

        public override string ToString()
        {
            return "Тигр: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(); //как this только для базового всегда
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
