using System;
using System.Collections.Generic;
using System.Runtime;

namespace miniRPG
{
    class Game
    {
        public Singleton singleton { get; set; }
        public int GetAttackHero(Team playerTeam, Team computerTeam, int heroesNum, bool computer)
        {
            singleton = Singleton.getInstance();
            if (!computer)
            {
                singleton.playerInteract.WriteLineStr("Выбери, кем атаковать: ");
                int playerAttackerNum = singleton.playerInteract.GetNumber(singleton.playerInteract.GetStr(), heroesNum, 1);
                while (playerTeam.CheckDeadHero(playerAttackerNum - 1))
                {
                    singleton.playerInteract.WriteLineStr("Выбери, кем атаковать: (Мертвыми атаковать нельзя)");
                    playerAttackerNum = singleton.playerInteract.GetNumber(singleton.playerInteract.GetStr(), heroesNum, 1);
                }
                return playerAttackerNum;
            }
            else
            {
                int computerAttackerNum = singleton.GetRandom(0, heroesNum);
                while (computerTeam.CheckDeadHero(computerAttackerNum))
                {
                    computerAttackerNum = singleton.GetRandom(0, heroesNum);
                }
                return computerAttackerNum;
            }
        }
        public int GetTargetHero(Team playerTeam, Team computerTeam, int heroesNum, bool computer)
        {
            singleton = Singleton.getInstance();
            if (!computer)
            {
                singleton.playerInteract.WriteStr("Выбери, кого атаковать: ");
                int playerTargetNum = singleton.playerInteract.GetNumber(singleton.playerInteract.GetStr(), heroesNum, 1);
                while (computerTeam.CheckDeadHero(playerTargetNum - 1))
                {
                    singleton.playerInteract.WriteStr("Выбери, кого атаковать: (Мертвого атаковать нельзя) ");
                    playerTargetNum = singleton.playerInteract.GetNumber(singleton.playerInteract.GetStr(), heroesNum, 1);
                }
                return playerTargetNum;
            }
            else
            {
                int computerTargetNum = singleton.GetRandom(0, heroesNum);
                while (playerTeam.CheckDeadHero(computerTargetNum))
                {
                    computerTargetNum = singleton.GetRandom(0, heroesNum);
                }
                return computerTargetNum;
            }
        }
        public void GetHeroes(Team team, int heroesNum, List<Hero> allHeroes)
        {
            singleton = Singleton.getInstance();
            if (!team.Computer)
            {
                int countedHeroes = 0;
                while (countedHeroes < heroesNum)
                {
                    int input = singleton.playerInteract.GetNumber(singleton.playerInteract.GetStr(), 6, 1);
                    if (countedHeroes != 0)
                    {
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
                            singleton.playerInteract.WriteLineStr("Нет, введи персонажей, которых еще нет!");
                            input = singleton.playerInteract.GetNumber(singleton.playerInteract.GetStr(), 6, 1);
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
                        singleton.playerInteract.WriteLineStr($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        countedHeroes++;
                    }
                    else
                    {
                        team.AddHero(team.CreateHero(input - 1));
                        singleton.playerInteract.WriteLineStr($"Персонаж {allHeroes[input - 1].Name} добавлен. ");
                        countedHeroes++;
                    }
                }
            }
            else
            {
                int computerHeroNumber = singleton.GetRandom(0, 6);
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
                        computerHeroNumber = singleton.GetRandom(0, 6);
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
                    singleton.playerInteract.WriteLineStr($"Компьютер добавил персонажа {allHeroes[computerHeroNumber].Name}.");
                    countedHeroes++;
                    computerHeroNumber = singleton.GetRandom(0, 6);
                }
            }
        }
        public bool IsGameOver(Team playerTeam, Team computerTeam, int heroes)
        {
            if (!(playerTeam.CheckTeamLive(playerTeam, heroes)) || !(computerTeam.CheckTeamLive(computerTeam, heroes)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MainGame()
        {
            singleton = Singleton.getInstance();
            singleton.playerInteract.GetTitle("MiniRPG");
            bool in_game = true;
            singleton.playerInteract.WriteStr("Придумай имя своей команды: ");
            string playerTeamName = singleton.playerInteract.GetStr();
            List<string> ComputerTeamNames = new List<string>() { "Печеньки", "Доминаторы", "Хакеры", "Лисы", "RJ", "название команды которое я не придумал" };
            int computerNumber = singleton.GetRandom(0, 6);
            string computerTeamName = ComputerTeamNames[computerNumber];
            singleton.playerInteract.WriteLineStr($"Компьютер выбрал имя - {computerTeamName}");
            singleton.playerInteract.WriteLineStr("Введи кол-во персонажей в команде(1-6)");
            int heroes = singleton.playerInteract.GetNumber(singleton.playerInteract.GetStr(), 6, 1);
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
            singleton.playerInteract.WriteLineStr($"Вводи номера персонажей, которых хочешь добавить в свою команду({heroes})");
            for (int i = 0; i < 6; ++i)
            {
                singleton.playerInteract.WriteInt(i + 1);
                allHeroes[i].PrintInfo();
            }
            GetHeroes(playerTeam, heroes, allHeroes);
            GetHeroes(computerTeam, heroes, allHeroes);
            System.Threading.Thread.Sleep(1000);
            singleton.playerInteract.GetTitle($"MiniRPG: {playerTeamName} vs {computerTeamName}");
            Console.Clear();
            while (in_game)
            {
                //данные о командах
                playerTeam.PrintTeamInfo();
                singleton.playerInteract.WriteSkip();
                computerTeam.PrintTeamInfo();
                //генерация атакующих героев и целей
                int playerAttackerNum = GetAttackHero(playerTeam, computerTeam, heroes, false);
                int playerTargetNum = GetTargetHero(playerTeam, computerTeam, heroes, false);
                singleton.playerInteract.WriteSkip();
                int computerAttackerNum = GetAttackHero(playerTeam, computerTeam, heroes, true);
                int computerTargetNum = GetTargetHero(playerTeam, computerTeam, heroes, true);
                Console.Clear();
                //атака 
                int damage = playerTeam.Attack(playerTeam.ReturnHero(playerAttackerNum - 1), computerTeam.ReturnHero(playerTargetNum - 1));
                singleton.playerInteract.WriteLineStr($"{playerTeam.ReturnHero(playerAttackerNum - 1).Name} ({playerTeamName}) нанес {damage} урона {computerTeam.ReturnHero(playerTargetNum - 1).Name} ({computerTeamName})");
                int computerDamage = computerTeam.Attack(computerTeam.ReturnHero(computerAttackerNum), playerTeam.ReturnHero(computerTargetNum));
                singleton.playerInteract.WriteLineStr($"{computerTeam.ReturnHero(computerAttackerNum).Name} ({computerTeamName}) нанес {computerDamage} урона {playerTeam.ReturnHero(computerTargetNum).Name} ({playerTeamName})");
                //проверка команд
                if (IsGameOver(playerTeam, computerTeam, heroes))
                {
                    in_game = false;
                    Console.Clear();
                    if (!playerTeam.CheckTeamLive(playerTeam, heroes) && !computerTeam.CheckTeamLive(computerTeam, heroes))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        singleton.playerInteract.WriteLineStr("Ничья! ");
                    }
                    else if (playerTeam.CheckTeamLive(playerTeam, heroes))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        singleton.playerInteract.WriteLineStr("Вы победили! ");
                        singleton.playerInteract.GetTitle("Победа!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        singleton.playerInteract.WriteLineStr("Вы проиграли...");
                        singleton.playerInteract.GetTitle("Поражение...");
                    }
                }
            }
        }
    }
}
