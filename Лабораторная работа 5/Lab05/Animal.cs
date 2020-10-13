using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Animal
    {
        public string Name;
        public int DateOfBirth;
        public string Color;
        public string FeedingStrategy;
        //carnivore, herbivore, omnivore

        public Animal(string Name)
        {
            this.Name = Name;
            this.DateOfBirth = 2000;
            this.Color = "White";
            this.FeedingStrategy = "omnivore";
        }

        public void ShowInfo()
        {
            Console.WriteLine("Name: {0}, Year: {1}, Color: {2}, Feeding Strategy: {3}", this.Name, this.DateOfBirth, this.Color, this.FeedingStrategy);
        }

        public virtual void Move()
        {
            Console.WriteLine("Животное двигается");
        }
        //die
        //после eat sleep
    }
    class Crocodile : Animal
    {
        public Crocodile(string _name, int _year = 0, string _color = "Green", string _feedingstrategy = "carnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }

        public override void Move()
        {
            Console.WriteLine("Крокодил ползёт");
        }

    }
}

