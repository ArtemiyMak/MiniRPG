using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class PotionMaker : Hero
    {
        public PotionMaker(string name, int health, int damage) : base(name, health, damage)
        {
            Name = "PotionMaker";
            Health = 250;
            Damage = 100;
        }
    }
}
