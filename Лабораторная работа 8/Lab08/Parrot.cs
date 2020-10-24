using System;

namespace Lab04
{
    class Parrot
    {
        public string name;
        public int dateOfBirth;
        public string color;
        public string feedingstrategy;

        public Parrot() 
        {
            this.name = "Parrot1";
            this.dateOfBirth = 2000;
            this.color = "Green";
            this.feedingstrategy = "carnivore";
        }

        public Parrot(string name = "Попуг", int year = 2000, string color = "Yellow", string feedingstrategy = "carnivore")
        {
            this.name = name;
            this.dateOfBirth = year;
            this.color = color;
            this.feedingstrategy = feedingstrategy;
        }

        public void Move()
        {
            Console.WriteLine("Попугай летит");
        }

        public  override string ToString()
        {
            return "Попугай: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingstrategy;
        }
    }
}
