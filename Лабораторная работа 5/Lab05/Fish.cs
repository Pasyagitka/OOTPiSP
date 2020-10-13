using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Fish : Animal
    {
        public Fish(string _name, int _year = 0, string _color = "Blue", string _feedingstrategy = "omnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
        public override void Move()
        {
            Console.WriteLine("Рыба плывет");
        }
    }

    class Shark : Fish
    {
        public Shark(string _name, int _year = 0, string _color = "Grey", string _feedingstrategy = "carnivore") : base(_name)
        {
            this.DateOfBirth = _year;
            this.Color = _color;
            this.FeedingStrategy = _feedingstrategy;
        }
        public override void Move()
        {
            Console.WriteLine("Акула плывет");
        }
    }
}
