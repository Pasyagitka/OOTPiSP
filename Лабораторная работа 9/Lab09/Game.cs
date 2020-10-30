using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    class Game
    {
        public int health;
        public int damage;

        public void Attack()
        {
            Console.WriteLine("Атака");
        }
        public void Heal()
        {
            Console.WriteLine("Исцеление");
        }

        delegate void AttackHandler(string message);
        event AttackHandler AttackEvent;
        delegate void HealHandler(string message);
        event HealHandler HealEvent;
    }
}
