using System;
using System.Runtime.Serialization;

namespace Lab14
{
    [Serializable]
    [DataContract]
    public class Animal 
    {
        [DataMember]
        public string name;
        public int dateOfBirth;
        [DataMember]
        public string color;
        [DataMember]
        public string feedingStrategy;      //carnivore, herbivore, omnivore

        public Animal()
        {
            this.name = "Animal";
            this.dateOfBirth = 2020;
            this.color = "White";
            this.feedingStrategy = "omnivore";
        }

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