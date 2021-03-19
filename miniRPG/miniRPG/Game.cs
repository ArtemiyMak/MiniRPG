﻿using System;
using System.Collections.Generic;
using System.Runtime;

namespace miniRPG
{
    class Game
    {
        Random Generator = new Random();
        public int GetAttackHero(Team playerTeam, Team computerTeam, int heroesNum, bool computer)
        {
            if (!computer)
            {
                Console.Write("Выбери, кем атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerAttackerNum);
                while (playerTeam.CheckDeadHero(playerAttackerNum - 1))
                //while (playerTeam.Heroes[playerAttackerNum - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кем атаковать: (Мертвыми атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerAttackerNum);
                }
                return playerAttackerNum;
            }
            else
            {
                int computerAttackerNum = Generator.Next(0, heroesNum);
                while (computerTeam.CheckDeadHero(computerAttackerNum))
                //while (computerTeam.Heroes[computerAttackerNum].Health == 0)
                {
                    computerAttackerNum = Generator.Next(0, heroesNum);
                }
                return computerAttackerNum;
            }
        }
        public int GetTargetHero(Team playerTeam, Team computerTeam, int heroesNum, bool computer)
        {
            if (!computer)
            {
                Console.Write("Выбери, кого атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerTargetNum);
                while (computerTeam.CheckDeadHero(playerTargetNum - 1))
                //while (computerTeam.Heroes[playerTargetNum - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кого атаковать: (Мертвого атаковать нельзя) ");
                    int.TryParse(Console.ReadLine(), out playerTargetNum);
                }
                return playerTargetNum;
            }
            else
            {
                int computerTargetNum = Generator.Next(0, heroesNum);
                //while (playerTeam.Heroes[computerTargetNum].Health == 0)
                while (playerTeam.CheckDeadHero(computerTargetNum))
                {
                    computerTargetNum = Generator.Next(0, heroesNum);
                }
                return computerTargetNum;
            }
        }
        public void GetHeroes(Team team, int heroesNum, List<Hero> allHeroes)
        {
            Random Generator = new Random();
            if (!team.Computer)
            {
                int countedHeroes = 0;
                while (countedHeroes < heroesNum)
                {
                    int.TryParse(Console.ReadLine(), out int input); 
                    if (countedHeroes != 0)
                    {
                        //team.ContainsHero(allHeroes[input - 1])
                        
                        bool haveHero = false;
                        foreach (Hero hero in team.Heroes)
                        {
                            Type heroType = hero.GetType();
                            Type baseHeroType = allHeroes[input - 1].GetType();
                            if (heroType == baseHeroType)
                            {
                                haveHero = true;
                                break;
                            }
                        }
                        while (haveHero)
                        {
                            Console.WriteLine("Нет, введи персонажей, которых еще нет!");
                            int.TryParse(Console.ReadLine(), out input);
                            foreach (Hero hero in team.Heroes)
                            {
                                Type heroType = hero.GetType();
                                Type baseHeroType = allHeroes[input - 1].GetType();
                                if (heroType == baseHeroType)
                                {
                                    haveHero = true;
                                    break;
                                }
                                else
                                {
                                    haveHero = false;
                                }
                            }
                        }
                        Hero playerHero = team.CreateHero(input - 1);
                        team.AddHero(playerHero);
                        Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        countedHeroes++;
                    }
                    else
                    {
                        team.AddHero(team.CreateHero(input - 1));
                        Console.WriteLine($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        countedHeroes++;
                    }
                }
            }
            else
            {
                int computerHeroNumber = Generator.Next(0, 6);
                int countedHeroes = 0;
                while (countedHeroes < heroesNum)
                {
                    bool haveHero = false;
                    foreach (Hero hero in team.Heroes)
                    {
                        Type heroType = hero.GetType();
                        Type baseHeroType = allHeroes[computerHeroNumber].GetType();
                        if (heroType == baseHeroType)
                        {
                            haveHero = true;
                            break;
                        }
                        else
                        {
                            haveHero = false;
                        }
                    }
                    while (haveHero)
                    {
                        computerHeroNumber = Generator.Next(0, 6);
                        foreach (Hero hero in team.Heroes)
                        {
                            Type heroType = hero.GetType();
                            Type baseHeroType = allHeroes[computerHeroNumber].GetType();
                            if (heroType == baseHeroType)
                            {
                                haveHero = true;
                                break;
                            }
                            else
                            {
                                haveHero = false;
                            }
                        }
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
            System.Threading.Thread.Sleep(1000);
            Console.Title = $"MiniRPG: {playerTeamName} vs {computerTeamName}";
            Console.Clear();
            while (in_game)
            {
                //данные о командах
                playerTeam.PrintTeamInfo();
                Console.WriteLine();
                computerTeam.PrintTeamInfo();
                //генерация атакующих героев и целей
                int playerAttackerNum = GetAttackHero(playerTeam, computerTeam, heroes, false);
                int playerTargetNum = GetTargetHero(playerTeam, computerTeam, heroes, false);
                Console.WriteLine();
                int computerAttackerNum = GetAttackHero(playerTeam, computerTeam, heroes, true);
                int computerTargetNum = GetTargetHero(playerTeam, computerTeam, heroes, true);
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
                    else if (playerTeam.CheckTeamLive(playerTeam, heroes))
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
