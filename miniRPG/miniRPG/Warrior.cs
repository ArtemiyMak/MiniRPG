using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Warrior : Hero
    {
        string name = "Warrior";
        int health = 320;
        int damage = 120;
        public Warrior() : base(name, health, damage)
        {
            
        }
    }
}
