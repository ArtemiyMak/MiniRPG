using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Warrior : Hero
    {
        public Warrior(string name, int health, int damage) : base(name, health, damage)
        {
            Name = "Warrior";
            Health = 320;
            Damage = 120;
        }
    }
}
