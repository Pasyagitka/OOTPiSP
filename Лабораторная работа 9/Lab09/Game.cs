using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add dmg nm
namespace Lab09
{
    class Game
    {
        public int health = 2000;
        public int damage = 150;

        public void Attack()
        {
            Console.WriteLine("Атака");
            this.AttackEvent?.Invoke();
        }
        public void Heal(int heal)
        {
            Console.WriteLine("Исцеление");
            if (HealEvent != null) health += this.HealEvent(heal);
        }

        public delegate void AttackHandler();
        public event AttackHandler AttackEvent;
        public delegate int HealHandler(int heal);
        public event HealHandler HealEvent;
    }
}
