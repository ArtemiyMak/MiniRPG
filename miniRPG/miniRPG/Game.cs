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
                    while (!playerTeam.ContainsHero(allHeroes[input - 1]))
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
            int computerNum = Generator.Next(0, 6);
            num = 0;
            while (num < heroes)
            {
                if (num != 0)
                {
                    while (!computerTeam.ContainsHero(allHeroes[computerNum]))
                    {
                        computerNum = Generator.Next(0, 6);
                    }
                    computerTeam.AddHero(allHeroes[computerNum]);
                    Console.WriteLine($"Компьютер добавил персонажа {allHeroes[computerNum].Name}.");
                    num++;
                }
                else
                {
                    computerTeam.AddHero(allHeroes[computerNum]);
                    Console.WriteLine($"Компьютер добавил персонажа {allHeroes[computerNum].Name}.");
                    num++;
                }
                computerNum = Generator.Next(0, 6);
            }
            System.Threading.Thread.Sleep(2500);
            Console.Title = $"MiniRPG: {playerTeamName} vs {computerTeamName}";
            Console.Clear();
            while (in_game)
            {
                playerTeam.PrintTeamInfo();
                Console.WriteLine();
                computerTeam.PrintTeamInfo();
                Console.Write("Выбери, кем атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerAttackerNum);
                while (playerTeam.Heroes[playerAttackerNum - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кем атаковать: (Мертвыми атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerAttackerNum);
                }
                Console.Write("Выбери, кого атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerTargetNum);
                while (computerTeam.Heroes[playerTargetNum - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кого атаковать: (Мертвого атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerTargetNum);
                }
                Console.WriteLine();
                int computerTargetNum = Generator.Next(0, heroes);
                int computerAttackerNum = Generator.Next(0, heroes);
                while (computerTeam.Heroes[computerAttackerNum].Health == 0)
                {
                    computerAttackerNum = Generator.Next(0, heroes);
                }
                while (playerTeam.Heroes[computerTargetNum].Health == 0)
                {
                    computerTargetNum = Generator.Next(0, heroes);
                }
                Console.Clear();

                int playerDamage = playerTeam.Attack(playerTeam.Heroes[playerAttackerNum - 1], computerTeam.Heroes[playerTargetNum]);
                int computerDamage = computerTeam.Attack(computerTeam.Heroes[computerAttackerNum], playerTeam.Heroes[computerTargetNum]);

                Console.WriteLine($"{playerTeam.Heroes[playerAttackerNum - 1].Name} ({playerTeam.Name}) нанес {playerDamage} урона {computerTeam.Heroes[playerTargetNum - 1].Name} ({computerTeam.Name})");
                Console.WriteLine($"{computerTeam.Heroes[computerAttackerNum].Name} ({computerTeam.Name}) нанес {computerDamage} урона {playerTeam.Heroes[computerTargetNum].Name} ({playerTeam.Name})");
                int deadPlayerHeroes = 0;
                int deadComputerHeroes = 0;
                foreach (Hero hero in playerTeam.Heroes)
                {
                    if(hero.Health == 0)
                    {
                        deadPlayerHeroes++;
                    }
                }
                foreach (Hero hero in computerTeam.Heroes)
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
