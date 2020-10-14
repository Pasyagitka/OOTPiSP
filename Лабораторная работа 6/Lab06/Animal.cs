using System;

namespace Lab06
{
    public abstract class Animal 
    {
        public string name;
        public int dateOfBirth;
        public int weight;
        public feedingStrategies feedingStrategy;
        public enum feedingStrategies { carnivore, herbivore, omnivore  };  

        public Animal(string Name, int DateOfBirth)
        {
            this.name = Name;
            this.dateOfBirth = DateOfBirth;
            this.weight = 10;
            this.feedingStrategy = feedingStrategies.omnivore;
        }

        public virtual void Move()
        {
            Console.WriteLine("Животное двигается");
        }

        public override string ToString()
        {
            return "Животное: Name: " + this.name + ", Year: " + this.dateOfBirth + ", Weight: " + this.weight + ", Feeding Strategy: " + this.feedingStrategy;
        }
    }
}