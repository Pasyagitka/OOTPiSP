using System;

namespace Lab09
{
    public class Game
    {
        private int health = 2000;
        public const int damage = 150;
        private const int maxhealth = 2000;

        public delegate void AttackHandler();
        public event AttackHandler AttackEvent;

        public delegate void HealHandler(int heal);
        public event HealHandler HealEvent;

        public void Damage()
        {
            this.health = GetDamage(this.health, damage);
            AttackEvent?.Invoke();
        }
        public void Heal(int heal)
        {
            this.health = GetHeal(this.health, heal);
            HealEvent?.Invoke(heal);
        }
        public void Status()
        {
            Console.WriteLine($"Текущее здоровье: {health}");
        }
        O GetDamage = (health, damage) => health -= damage;
        O GetHeal = (health, heal) => health + heal > maxhealth ? health = maxhealth : health += heal;
    }
    delegate int O(int x, int y);
}
