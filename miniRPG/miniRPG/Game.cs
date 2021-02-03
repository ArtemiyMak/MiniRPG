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
            playerTeam.GetHeroes(heroes, allHeroes);
            computerTeam.GetHeroes(heroes, allHeroes);
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
                int playerAttackerNum = playerTeam.GetAttackHero(playerTeam, computerTeam, heroes);
                int playerTargetNum = playerTeam.GetTargetHero(playerTeam, computerTeam, heroes);
                Console.WriteLine();
                int computerAttackerNum = computerTeam.GetAttackHero(playerTeam, computerTeam, heroes);
                int computerTargetNum = computerTeam.GetTargetHero(playerTeam, computerTeam, heroes);
                Console.Clear();
                //атака
                playerTeam.Attack(playerTeam, computerTeam, playerTeam.Heroes[playerAttackerNum - 1], computerTeam.Heroes[playerTargetNum]);
                computerTeam.Attack(computerTeam, playerTeam, computerTeam.Heroes[computerAttackerNum], playerTeam.Heroes[computerTargetNum]);
                //проверка команд
                if (!(playerTeam.CheckTeamLive(playerTeam, heroes)) || !(computerTeam.CheckTeamLive(computerTeam, heroes)))
                {
                    in_game = false;
                }
            }
        }        
    }
}
