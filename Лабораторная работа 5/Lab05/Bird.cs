using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Bird : Animal
    {
        public Bird(string _name, int _year = 0, string _color = "Yellow", string _feedingstrategy = "omnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
        public override void Move()
        {
            Console.WriteLine("Птица летит");
        }
    }
    class Owl : Bird
    {
        public Owl(string _name, int _year = 0, string _color = "Grey", string _feedingstrategy = "carnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
        public override void Move()
        {
            Console.WriteLine("Сова летит");
        }
    }
    class Parrot : Bird
    {
        public Parrot(string _name, int _year = 0, string _color = "Green", string _feedingstrategy = "carnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
        public override void Move()
        {
            Console.WriteLine("Попугай летит");
        }
    }
}
