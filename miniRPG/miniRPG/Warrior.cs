using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Warrior : Hero
    {
        public string name;
        public int health;
        public int damage;
        public Warrior(string name, int health, int damage) : base(name, health, damage)
        {
            name = "Warrior";
            health = 320;
            damage = 120;
        }
    }
}
