using System;
using System.Collections.Generic;
using System.Runtime;

namespace miniRPG
{
    class Game
    {
        public void GetHeroes(Team team, int heroesNum, List<Hero> allHeroes)
        {
            Random Generator = new Random();
            if (!team.Computer)
            {
                int num = 0;
                while (num < heroesNum)
                {
                    int.TryParse(Console.ReadLine(), out int input);
                    if (num != 0)
                    {
                        //team.ContainsHero(allHeroes[input - 1])
                        Hero playerHero = team.CreateHero(input - 1);
                        bool haveHero = playerHero.Equals(allHeroes[input - 1]);
                        while (haveHero)
                        {
                            Console.WriteLine("Нет, введи персонажей, которых еще нет!");
                            int.TryParse(Console.ReadLine(), out input);
                        }
                        team.AddHero(playerHero);
                        Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        num++;
                    }
                    else
                    {
                        team.AddHero(team.CreateHero(input - 1));
                        Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        num++;
                    }
                }
            }
            else
            {
                int computerHeroNumber = Generator.Next(0, 6);
                int countedHeroes = 0;
                while (countedHeroes < heroesNum)
                {
                    while (team.ContainsHero(allHeroes[computerHeroNumber]))
                    {
                        computerHeroNumber = Generator.Next(0, 6);
                    }
                    team.AddHero(team.CreateHero(computerHeroNumber));
                    Console.WriteLine($"added: {computerHeroNumber}");
                    Console.WriteLine($"Компьютер добавил персонажа {allHeroes[computerHeroNumber].Name}.");
                    countedHeroes++;
                    computerHeroNumber = Generator.Next(0, 6);
                }
            }
        }
        public void MainGame()
        {
            Random Generator = new Random();
            Console.Title = "MiniRPG";
            bool in_game = true;
            Console.Write("Придумай имя своей команды: ");
            string playerTeamName = Console.ReadLine();
            List<string> ComputerTeamNames = new List<string>() { "Печеньки", "Доминаторы", "Хакеры", "Лисы", "RJ" };
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
            allHeroes.Add(globalWarrior);
            allHeroes.Add(globalArcher);
            allHeroes.Add(globalBerserk);
            allHeroes.Add(globalPotionMaker);
            allHeroes.Add(globalThief);
            allHeroes.Add(globalWizard);

            Team playerTeam = new Team(playerTeamName, playerHeroes, false);
            Team computerTeam = new Team(computerTeamName, computerHeroes, true);
            Console.WriteLine($"Вводи номера персонажей, которых хочешь добавить в свою команду({heroes})");
            
            for (int i = 0; i < 6; ++i)
            {
                Console.Write(i + 1);
                allHeroes[i].PrintInfo();
            }
            GetHeroes(playerTeam, heroes, allHeroes);
            GetHeroes(computerTeam, heroes, allHeroes);
            System.Threading.Thread.Sleep(10000);
            Console.Title = $"MiniRPG: {playerTeamName} vs {computerTeamName}";
            Console.Clear();
            while (in_game)
            {
                //данные о командах
                playerTeam.PrintTeamInfo();
                Console.WriteLine();
                computerTeam.PrintTeamInfo();
                //генерация атакующих героев и целей
                int playerAttackerNum = playerTeam.GetAttackHero(playerTeam, computerTeam, heroes);
                int playerTargetNum = playerTeam.GetTargetHero(playerTeam, computerTeam, heroes);
                Console.WriteLine();
                int computerAttackerNum = computerTeam.GetAttackHero(playerTeam, computerTeam, heroes);
                int computerTargetNum = computerTeam.GetTargetHero(playerTeam, computerTeam, heroes);
                Console.Clear();
                //атака
                playerTeam.Attack(playerTeam, computerTeam, playerTeam.Heroes[playerAttackerNum - 1], computerTeam.Heroes[playerTargetNum - 1]);
                computerTeam.Attack(computerTeam, playerTeam, computerTeam.Heroes[computerAttackerNum], playerTeam.Heroes[computerTargetNum]);
                //проверка команд
                if (!(playerTeam.CheckTeamLive(playerTeam, heroes)) || !(computerTeam.CheckTeamLive(computerTeam, heroes)))
                {
                    in_game = false;
                    Console.Clear();
                    if(!playerTeam.CheckTeamLive(playerTeam, heroes) && !computerTeam.CheckTeamLive(computerTeam, heroes))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Ничья! ");
                    }

                    if (playerTeam.CheckTeamLive(playerTeam, heroes))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Вы победили! ");
                        Console.Title = "YOU WIN=)";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Вы проиграли...");
                        Console.Title = "YOU LOSE=(";
                    }
                    Console.ReadLine();
                }
            }
        }        
    }
}
