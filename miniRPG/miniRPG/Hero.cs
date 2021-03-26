using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Hero
    {
        public Singleton singleton { get; set; }
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public Hero(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public void PrintInfo()
        {
            Console.WriteLine(Health > 0 ? $".{Name} ({Health} HP), базовый урон: {Damage}" : $".{Name} ({Health} HP), базовый урон: {Damage} [Убит]");
        }
        public int CalculateDamage()
        {
            singleton = Singleton.getInstance();
            return singleton.GetRandom(Damage / 4 * 3, Damage / 4 * 5); ;
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
