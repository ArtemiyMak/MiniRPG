﻿using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Hero
    {
        Random random = new Random();
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
            if (Health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($".{Name} ({Health} HP), базовый урон: {Damage}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($".{Name} ({Health} HP), базовый урон: {Damage} [Убит]");
                Console.ForegroundColor = ConsoleColor.White;
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
