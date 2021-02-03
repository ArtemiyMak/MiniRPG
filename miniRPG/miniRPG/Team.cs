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

        public void AddHero(int heroNum)
        {
            Warrior warrior = new Warrior();
            Archer archer = new Archer();
            Berserk berserk = new Berserk();
            PotionMaker potionMaker = new PotionMaker();
            Thief thief = new Thief();
            Wizard wizard = new Wizard();
            switch (heroNum)
            {
                case 0:
                    {
                        Heroes.Add(warrior);
                        break;
                    }
                case 1:
                    {
                        Heroes.Add(archer);
                        break;
                    }
                case 2:
                    {
                        Heroes.Add(berserk);
                        break;
                    }
                case 3:
                    {
                        Heroes.Add(potionMaker);
                        break;
                    }
                case 4:
                    {
                        Heroes.Add(thief);
                        break;
                    }
                case 5:
                    {
                        Heroes.Add(wizard);
                        break;
                    }
            }
        }
        public bool ContainsHero(Hero hero)
        {
            return !Heroes.Contains(hero);
        }
        public void GetHeroes(int heroesNum, List<Hero> allHeroes)
        {
            if(!Computer)
            {
                int num = 0;
                while (num < heroesNum)
                {
                    int.TryParse(Console.ReadLine(), out int input);
                    if (num != 0)
                    {
                        while (!ContainsHero(allHeroes[input - 1]))
                        {
                            Console.WriteLine("Нет, введи персонажей, которых еще нет!");
                            int.TryParse(Console.ReadLine(), out input);
                        }
                        AddHero(input - 1);
                        Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        num++;
                    }
                    else
                    {
                        AddHero(input - 1);
                        Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        num++;
                    }
                }
            }
            else
            {
                int computerNum = Generator.Next(0, 6);
                int num = 0;
                while (num < heroesNum)
                {
                    if (num != 0)
                    {
                        while (!ContainsHero(allHeroes[computerNum]))
                        {
                            computerNum = Generator.Next(0, 6);
                        }
                        AddHero(computerNum);
                        Console.WriteLine($"Компьютер добавил персонажа {allHeroes[computerNum].Name}.");
                        num++;
                    }
                    else
                    {
                        AddHero(computerNum);
                        Console.WriteLine($"Компьютер добавил персонажа {allHeroes[computerNum].Name}.");
                        num++;
                    }
                    computerNum = Generator.Next(0, 6);
                }
            }
        }
        public int GetAttackHero(Team playerTeam, Team computerTeam, int heroesNum)
        {
            if (!Computer)
            {
                Console.Write("Выбери, кого атаковать: ");
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
                    Console.WriteLine("Выбери, кого атаковать: (Мертвого атаковать нельзя)");
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
