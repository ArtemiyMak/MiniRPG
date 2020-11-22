using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Wizard : Hero
    {
        public Wizard(string name, int health, int damage) : base (name, health, damage)
        {
            Name = "Wizard";
            Health = 500;
            Damage = 60;
        }
    }
}
