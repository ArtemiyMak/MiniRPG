using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Thief : Hero
    {
        public Thief(string name, int health, int damage) : base(name, health, damage)
        {
            Name = "Thief";
            Health = 50;
            Damage = 200;
        }
    }
}
