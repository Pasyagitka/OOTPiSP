using System;

namespace Lab06
{
    abstract class Animal
    {
        public string name;
        public int dateOfBirth;
        public string color;
        public string feedingStrategy;      //carnivore, herbivore, omnivore

        public Animal(string Name, int DateOfBirth)
        {
            this.name = Name;
            this.dateOfBirth = DateOfBirth;
            this.color = "White";
            this.feedingStrategy = "omnivore";
        }

        public virtual void Move()
        {
            Console.WriteLine("Животное двигается");
        }

        public override string ToString()
        {
            return "Животное: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Color: " + this.color + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}