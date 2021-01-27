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
        public Random generator = new Random();
        public void AddHero(Hero hero)
        {
            Heroes.Add(hero);
        }
        public bool ContainsHero(Hero hero)
        {
            if (!Heroes.Contains(hero))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Attack(Hero attackHero, Hero targetHero)
        {
            int damage = attackHero.CalculateDamage();
            targetHero.GetDamage(damage);
            return damage;
        }
        
        /*
        public List<Hero> GetPlayerHeroes(List<Hero> playerHeroes)
        {
            Console.WriteLine($"Вводи номера персонажей, которых хочешь добавить в свою команду({HeroesNum})");
            Warrior warrior = new Warrior();
            Archer archer = new Archer();
            Berserk berserk = new Berserk();
            PotionMaker potionMaker = new PotionMaker();
            Thief thief = new Thief();
            Wizard wizard = new Wizard();
            List<Hero> heroes = new List<Hero>();
            Console.Write("1");
            warrior.PrintInfo();
            Console.Write("2");
            archer.PrintInfo();
            Console.Write("3");
            berserk.PrintInfo();
            Console.Write("4");
            potionMaker.PrintInfo();
            Console.Write("5");
            thief.PrintInfo();
            Console.Write("6");
            wizard.PrintInfo();
            heroes.Add(warrior);
            heroes.Add(archer);
            heroes.Add(berserk);
            heroes.Add(potionMaker);
            heroes.Add(thief);
            heroes.Add(wizard);

            int num = 0;
            while (num < HeroesNum)
            {
                int.TryParse(Console.ReadLine(), out int input);
                if (num != 0)
                {
                    while (playerHeroes.Contains(heroes[input - 1]))
                    {
                        Console.WriteLine("Нет, введи персонажей, которых еще нет!");
                        int.TryParse(Console.ReadLine(), out input);
                    }
                    playerHeroes.Add(heroes[input - 1]);
                    Console.WriteLine($"Персонаж {heroes[input - 1].Name} добавлен. ");
                    num++;
                }
                else
                {
                    playerHeroes.Add(heroes[input - 1]);
                    Console.WriteLine($"Персонаж {heroes[input - 1].Name} добавлен. ");
                    num++;
                }
            }
            return playerHeroes;
        }
        public List<Hero> GetComputerHeroes(List<Hero> computerHeroes)
        {
            Warrior warrior = new Warrior();
            Archer archer = new Archer();
            Berserk berserk = new Berserk();
            PotionMaker potionMaker = new PotionMaker();
            Thief thief = new Thief();
            Wizard wizard = new Wizard();
            List<Hero> heroes = new List<Hero>();
            heroes.Add(warrior);
            heroes.Add(archer);
            heroes.Add(berserk);
            heroes.Add(potionMaker);
            heroes.Add(thief);
            heroes.Add(wizard);
            int computerNum = generator.Next(1, 7);
            int num = 0;
            
            while (num < HeroesNum)
            {
                if (num != 0)
                {
                    while (computerHeroes.Contains(heroes[computerNum - 1]))
                    {
                        computerNum = generator.Next(1, 7);
                    }
                    computerHeroes.Add(heroes[computerNum - 1]);
                    Console.WriteLine($"Компьютер добавил персонажа {heroes[computerNum - 1].Name}. ");
                    num++;
                }
                else
                {
                    computerHeroes.Add(heroes[computerNum - 1]);
                    Console.WriteLine($"Компьютер добавил персонажа {heroes[computerNum - 1].Name}. ");
                    num++;
                }
            }
            return computerHeroes;
        }
        */
        
    }
}
