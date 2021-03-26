using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Team
    {
        public Team(string name, List<Hero> heroes, bool computer)
        {
            Name = name;
            Heroes = heroes;
            Computer = computer;
        }
        public string Name { get; set; }
        public List<Hero> Heroes { get; set; }
        public bool Computer { get; set; }
        
        public void AddHero(Hero hero)
        {
            Heroes.Add(hero);
        }
        public void PrintTeamInfo()
        {
            Console.WriteLine($"Команда {Name}");
            Console.WriteLine("--------------------------------------");
            int num = 0;
            foreach (Hero hero in Heroes)
            {
                Console.Write(num + 1);
                hero.PrintInfo();
                num++;
            }
            Console.WriteLine("--------------------------------------");
        }
        public bool ContainsHero(Hero hero)
        {
            return Heroes.Contains(hero);
        }
        public bool CheckTeamLive(Team team, int heroesNum)
        {
            int deadHeroes = 0;
            foreach (Hero hero in team.Heroes)
            {
                if (hero.Health == 0)
                {
                    deadHeroes++;
                }
            }
            return !(deadHeroes == heroesNum);
        }
        public bool CheckDeadHero(int num)
        {
            if(Heroes[num].Health == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Attack(Team attackTeam, Team targetTeam, Hero attackHero, Hero targetHero)
        {
            int damage = attackHero.CalculateDamage();
            targetHero.GetDamage(damage);
            return damage;
        }
        public Hero ReturnHero(int num)
        {
            return Heroes[num];
        }
        public Hero CreateHero(int hero)
        {
            switch (hero)
            {
                case 0:
                    {
                        return new Warrior();
                    }
                case 1:
                    {
                        return new Archer();
                    }
                case 2:
                    {
                        return new Berserk();
                    }
                case 3:
                    {
                        return new PotionMaker();
                    }
                case 4:
                    {
                        return new Thief();
                    }
                case 5:
                    {
                        return new Wizard();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
