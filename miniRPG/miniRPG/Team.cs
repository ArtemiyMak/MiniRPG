using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Team
    {
        public Team(int heroesNum, string name, List<Hero> heroes)
        {
            HeroesNum = heroesNum;
            Name = name;
            Heroes = heroes;
        }
        public int HeroesNum { get; set; }
        public string Name { get; set; }
        public List<Hero> Heroes { get; set; }
    }
}
