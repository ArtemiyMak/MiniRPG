using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Game
    {
        public void MainGame()
        {
            Random Generator = new Random();
            Console.Title = "MiniRPG";
            bool in_game = true;
            Console.Write("Придумай имя своей команды: ");
            string playerTeamName = Console.ReadLine();
            List<string> ComputerTeamNames = new List<string>() { "Печеньки", "Доминаторы", "Хакеры", "Нехитрые Лисы", "RJ" };
            int computerNumber = Generator.Next(0, 5);
            string computerTeamName = ComputerTeamNames[computerNumber];
            Console.WriteLine($"Компьютер выбрал имя - {computerTeamName}");
            Console.WriteLine("Введи кол-во персонажей в команде(1-6)");
            int.TryParse(Console.ReadLine(), out int heroes);
            while (heroes > 6 || heroes < 1)
            {
                Console.WriteLine("Нет, введи число от 1 до 6");
                int.TryParse(Console.ReadLine(), out heroes);
            }       
            List<Hero> playerHeroes = new List<Hero>();
            List<Hero> computerHeroes = new List<Hero>();
            List<Hero> allHeroes = new List<Hero>();
            Wizard globalWizard = new Wizard();
            Thief globalThief = new Thief();
            PotionMaker globalPotionMaker = new PotionMaker();
            Berserk globalBerserk = new Berserk();
            Archer globalArcher = new Archer();
            Warrior globalWarrior = new Warrior();
            allHeroes.Add(globalWizard);
            allHeroes.Add(globalThief);
            allHeroes.Add(globalPotionMaker);
            allHeroes.Add(globalBerserk);
            allHeroes.Add(globalArcher);
            allHeroes.Add(globalWarrior);

            Team playerTeam = new Team(playerTeamName, playerHeroes, false);
            Team computerTeam = new Team(computerTeamName, computerHeroes, true);
            Console.WriteLine($"Вводи номера персонажей, которых хочешь добавить в свою команду({heroes})");
            for (int i = 0; i < 6; ++i)
            {
                Console.Write(i + 1);
                allHeroes[i].PrintInfo();
            }
            int num = 0;
            while (num < heroes)
            {
                int.TryParse(Console.ReadLine(), out int input);
                if (num != 0)
                {
                    while (!playerTeam.HaveHero(allHeroes[input - 1]))
                    {
                        Console.WriteLine("Нет, введи персонажей, которых еще нет!");
                        int.TryParse(Console.ReadLine(), out input);
                    }
                    playerTeam.AddHero(allHeroes[input - 1]);
                    Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                    num++;
                }
                else
                {
                    playerTeam.AddHero(allHeroes[input - 1]);
                    Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                    num++;
                }
            }
            int computerNum = Generator.Next(1, 7);
            num = 0;
            while (num < heroes)
            {
                if (num != 0)
                {
                    while (computerTeam.HaveHero(allHeroes[computerNum - 1]))
                    {
                        computerNum = Generator.Next(1, 7);
                    }
                    computerTeam.AddHero(allHeroes[computerNum - 1]);
                    Console.WriteLine($"Компьютер добавил персонажа {allHeroes[computerNum - 1].Name}. ");
                    num++;
                }
                else
                {
                    computerTeam.AddHero(allHeroes[computerNum - 1]);
                    Console.WriteLine($"Компьютер добавил персонажа {allHeroes[computerNum - 1].Name}. ");
                    num++;
                }
                computerNum = Generator.Next(1, 7);
            }
            System.Threading.Thread.Sleep(2500);
            Console.Title = $"MiniRPG: {playerTeamName} vs {computerTeamName}";
            Console.Clear();
            while (in_game)
            {
                Console.WriteLine($"Команда {playerTeamName}");
                Console.WriteLine("--------------------------------------");
                for (int i = 0; i < heroes; ++i)
                {
                    Console.Write(i + 1);
                    playerHeroes[i].PrintInfo();
                }
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Команда {computerTeamName}");
                Console.WriteLine("--------------------------------------");
                for (int i = 0; i < heroes; ++i)
                {
                    Console.Write(i + 1);
                    computerHeroes[i].PrintInfo();
                }
                Console.WriteLine("--------------------------------------");
                Console.Write("Выбери, кем атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerAttacker);
                while (playerHeroes[playerAttacker - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кем атаковать: (Мертвыми атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerAttacker);
                }
                Console.Write("Выбери, кого атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerTarget);
                while (computerHeroes[playerTarget - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кого атаковать: (Мертвого атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerTarget);
                }
                Console.WriteLine();
                int computerTarget = Generator.Next(0, heroes);
                int computerAttacker = Generator.Next(0, heroes);
                while (computerHeroes[computerAttacker].Health == 0)
                {
                    computerAttacker = Generator.Next(1, heroes + 1);
                }
                while (playerHeroes[computerTarget].Health == 0)
                {
                    computerTarget = Generator.Next(1, heroes + 1);
                }
                Console.Clear();
                int playerDamage = playerHeroes[playerAttacker - 1].CalculateDamage();
                int computerDamage = computerHeroes[computerAttacker].CalculateDamage();
                computerHeroes[playerTarget - 1].GetDamage(playerDamage);
                playerHeroes[computerTarget].GetDamage(computerDamage);
                Console.WriteLine($"{playerHeroes[playerAttacker - 1].Name} ({playerTeam.Name}) нанес {playerDamage} урона {computerHeroes[playerTarget - 1].Name} ({computerTeam.Name})");
                Console.WriteLine($"{computerHeroes[computerAttacker].Name} ({computerTeam.Name}) нанес {computerDamage} урона {playerHeroes[computerTarget].Name} ({playerTeam.Name})");
                int deadPlayerHeroes = 0;
                int deadComputerHeroes = 0;
                foreach (Hero hero in playerHeroes)
                {
                    if(hero.Health == 0)
                    {
                        deadPlayerHeroes++;
                    }
                }
                foreach (Hero hero in computerHeroes)
                {
                    if (hero.Health == 0)
                    {
                        deadComputerHeroes++;
                    }
                }
                if ((deadPlayerHeroes == heroes) || (deadComputerHeroes == heroes))
                {
                    in_game = false;
                }
            }
        }        
    }
}
