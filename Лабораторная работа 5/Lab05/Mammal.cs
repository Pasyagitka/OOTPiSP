using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Mammal : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Животное бежит");
        }
        public Mammal(string _name, int _year = 0, string _color = "White", string _feedingstrategy = "omnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
    }
    class Lion : Mammal
    {
        public Lion(string _name, int _year = 0, string _color = "Yellow", string _feedingstrategy = "carnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
        public override void Move()
        {
            Console.WriteLine("Лев бежит");
        }
    }
    class Tiger : Mammal
    {
        public Tiger(string _name, int _year = 0, string _color = "Orange", string _feedingstrategy = "carnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
        public override void Move()
        {
            Console.WriteLine("Тигр бежит");
        }
    }
}
