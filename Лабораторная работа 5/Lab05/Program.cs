using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Program
    {
        private static void Main(string[] args)
        {
            Animal efowf = new Animal("Oleg");
            efowf.ShowInfo(); efowf.Move();
            Crocodile tom = new Crocodile("Tom", 2026);
            tom.ShowInfo(); tom.Move();

            Lion a1 = new Lion("A1");
            a1.ShowInfo(); a1.Move();

            Tiger a2 = new Tiger("A2");
            a2.ShowInfo(); a2.Move();

            Fish a3 = new Fish("A3");
            a3.ShowInfo(); a3.Move();

            Shark a4 = new Shark("A3");
            a4.ShowInfo(); a4.Move();
        }
    }
}
