using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Berserk : Hero
    {
        public Berserk(string name, int health, int damage) : base(name, health, damage)
        {
            Name = "Berserk";
            Health = 200;
            Damage = 160;
        }
    }
}
