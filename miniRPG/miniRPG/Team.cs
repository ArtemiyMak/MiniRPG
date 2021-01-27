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
        public void StartAttack()
        {
            //еще делать
        }
        public int Attack(Hero attackHero, Hero targetHero)
        {
            int damage = attackHero.CalculateDamage();
            targetHero.GetDamage(damage);
            return damage;
        }
        public void PrintTeamInfo()
        {
            Console.WriteLine($"Команда {Name}");
            Console.WriteLine("--------------------------------------");
            int num = 0;
            foreach (Hero hero in Heroes)
            {
                Console.Write($"{num}.");
                hero.PrintInfo();
                num++;
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
