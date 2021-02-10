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
        public Random Generator = new Random();

        public Hero CreateHero(int hero)
        {
            switch (hero)
            {
                case 0:
                    {
                        Warrior warrior = new Warrior();
                        return warrior;
                    }
                case 1:
                    {
                        Archer archer = new Archer();
                        return archer;
                    }
                case 2:
                    {
                        Berserk berserk = new Berserk();
                        return berserk;
                    }
                case 3:
                    {
                        PotionMaker potionMaker = new PotionMaker();
                        return potionMaker;
                    }
                case 4:
                    {
                        Thief thief = new Thief();
                        return thief;
                    }
                case 5:
                    {
                        Wizard wizard = new Wizard();
                        return wizard;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        public void AddHero(Hero hero)
        {
            Heroes.Add(hero);
        }
        public bool ContainsHero(Hero hero)
        {
            return Heroes.Contains(hero);
        }
        
        public int GetAttackHero(Team playerTeam, Team computerTeam, int heroesNum)
        {
            if (!Computer)
            {
                Console.Write("Выбери, кем атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerAttackerNum);
                while (playerTeam.Heroes[playerAttackerNum - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кем атаковать: (Мертвыми атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerAttackerNum);
                }
                return playerAttackerNum;
            }
            else
            {
                int computerAttackerNum = Generator.Next(0, heroesNum);
                while (computerTeam.Heroes[computerAttackerNum].Health == 0)
                {
                    computerAttackerNum = Generator.Next(0, heroesNum);
                }
                return computerAttackerNum;
            }
        }
        public int GetTargetHero(Team playerTeam, Team computerTeam, int heroesNum)
        {
            if (!Computer)
            {
                Console.Write("Выбери, кого атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerTargetNum);
                while (computerTeam.Heroes[playerTargetNum - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кого атаковать: (Мертвого атаковать нельзя) ");
                    int.TryParse(Console.ReadLine(), out playerTargetNum);
                }
                return playerTargetNum;
            }
            else
            {
                int computerTargetNum = Generator.Next(0, heroesNum);
                while (playerTeam.Heroes[computerTargetNum].Health == 0)
                {
                    computerTargetNum = Generator.Next(0, heroesNum);
                }
                return computerTargetNum;
            }
        }
        public void Attack(Team attackTeam, Team targetTeam, Hero attackHero, Hero targetHero)
        {
            int damage = attackHero.CalculateDamage();
            targetHero.GetDamage(damage);
            Console.WriteLine($"{attackHero.Name} ({attackTeam.Name}) нанес {damage} урона {targetHero.Name} ({targetTeam.Name})");
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
    }
}
