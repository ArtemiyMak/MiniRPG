using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Hero
    {
        Random random = new Random();
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Hero(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public void PrintInfo()
        {
            if (Health > 0)
            {
               Console.WriteLine($". {Name} ({Health} HP), базовый урон: {Damage}");
            }
            else
            {
                Console.WriteLine($". {Name} ({Health} HP), базовый урон: {Damage} [Убит]");
            }
        }
        public int CalculateDamage()
        {
            int calculatingDamage = random.Next(Damage / 4 * 3, Damage / 4 * 5);
            return calculatingDamage;
        }
        public void GetDamage(int gettingDamage)
        {
            if (Health - gettingDamage <= 0)
            {
                Health = 0;
            }
            else
            {
                Health -= gettingDamage;
            }
        }
    }
}
