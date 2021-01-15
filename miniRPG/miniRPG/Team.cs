using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Team
    {
        public Team(int heroesNum, string name, List<Hero> heroes, bool computer)
        {
            HeroesNum = heroesNum;
            Name = name;
            Heroes = heroes;
        }
        public int HeroesNum { get; set; }
        public string Name { get; set; }
        public List<Hero> Heroes { get; set; }
        public int GetNumHeroes()
        {
            int.TryParse(Console.ReadLine(), out int heroes);
            while (heroes > 6 || heroes < 1)
            {
                Console.WriteLine("Нет, введи число от 1 до 6");
                int.TryParse(Console.ReadLine(), out heroes);
            }
            return heroes;
        }
        public List<Hero> GetHeroes()
        {
            Console.WriteLine($"Вводи номера персонажей, которых хочешь добавить в свою команду({HeroesNum})");
            for (int i = 0; i < 6; ++i)
            {
                Console.Write(i + 1);
                allHeroes[i].PrintInfo();
            }
            int num = 0;
            while (num < HeroesNum)
            {
                int.TryParse(Console.ReadLine(), out int input);
                if (!(num == 0))
                {
                    while (playerHeroes.Contains(allHeroes[input - 1]))
                    {
                        Console.WriteLine("Нет, введи персонажей, которых еще нет!");
                        int.TryParse(Console.ReadLine(), out input);
                    }
                    playerHeroes.Add(allHeroes[input - 1]);
                    Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                    num++;
                }
                else
                {
                    playerHeroes.Add(allHeroes[input - 1]);
                    Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                    num++;
                }
            }
        }
        
    }
}
