using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Archer : Hero
    {
        public Archer(string name, int health, int damage) : base(name, health, damage)
        {
            Name = "Archer";
            Health = 300;
            Damage = 90;
        }
    }
}
