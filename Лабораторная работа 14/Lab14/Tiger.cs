using System;
using System.Xml.Serialization;

namespace Lab14
{
    [Serializable]
    public class Tiger : Animal
    {
        [NonSerialized]
        private string a;

        public Tiger() 
        {
            this.a ="aaa";
            this.name = "Animal";
            this.dateOfBirth = 2020;
            this.color = "White";
            this.feedingStrategy = "omnivore";
        }

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
            return base.GetHashCode(); 
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
