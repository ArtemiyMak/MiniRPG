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
            Console.WriteLine("Введи кол-во персонажей в команде(1-6)");

            int.TryParse(Console.ReadLine(), out int heroes);
            while (heroes > 6 || heroes < 1)
            {
                Console.WriteLine("Нет, введи число от 1 до 6");
                int.TryParse(Console.ReadLine(), out heroes);
            }
            List<string> ComputerTeamNames = new List<string>() { "Печеньки", "Доминаторы", "Хакеры", "Нехитрые Лисы", "RJ" };
            int computerNumber = Generator.Next(0, 5);
            string computerTeamName = ComputerTeamNames[computerNumber];
            List<Hero> playerHeroes = new List<Hero>();
            List<Hero> computerHeroes = new List<Hero>();
            List<Hero> allHeroes = new List<Hero>();
            Wizard globalWizard = new Wizard("Wizard", 500, 60);
            Thief globalThief = new Thief("Thief", 50, 200);
            PotionMaker globalPotionMaker = new PotionMaker("PotionMaker", 250, 100);
            Berserk globalBerserk = new Berserk("Berserk", 200, 160);
            Archer globalArcher = new Archer("Archer", 300, 90);
            Warrior globalWarrior = new Warrior("Warrior", 320, 120);
            allHeroes.Add(globalWizard);
            allHeroes.Add(globalThief);
            allHeroes.Add(globalPotionMaker);
            allHeroes.Add(globalBerserk);
            allHeroes.Add(globalArcher);
            allHeroes.Add(globalWarrior);
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
                while (playerHeroes.Contains(allHeroes[input - 1]))
                {
                    Console.WriteLine("Нет, введи персонажей, которых еще нет!");
                    int.TryParse(Console.ReadLine(), out input);
                }
                playerHeroes.Add(allHeroes[input - 1]);
                num++;
            }
            int computerNum = Generator.Next(1, 7);
            num = 0;
            while (num < heroes)
            {
                if (!computerHeroes.Contains(computerHeroes[computerNum - 1]))
                {
                    computerHeroes.Add(allHeroes[computerNum - 1]);
                    num++;
                }
                computerNum = Generator.Next(1, 7);
            }
            Team playerTeam = new Team(heroes, playerTeamName, playerHeroes);
            Team computerTeam = new Team(heroes, computerTeamName, computerHeroes);
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
                while (playerHeroes[playerTarget - 1].Health == 0)
                {
                    Console.WriteLine("Выбери, кого атаковать: (Мертвыми атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerTarget);
                }
                Console.WriteLine();
                int computerTarget = Generator.Next(0, heroes);
                int computerAttacker = Generator.Next(0, heroes);
                while (computerHeroes[playerAttacker - 1].Health == 0)
                {
                    computerAttacker = Generator.Next(0, heroes);
                }
                while (computerHeroes[playerTarget - 1].Health == 0)
                {
                    computerTarget = Generator.Next(0, heroes);
                }
                Console.Clear();
                int playerDamage = playerHeroes[playerAttacker].CalculateDamage();
                int computerDamage = computerHeroes[computerAttacker].CalculateDamage();
                computerHeroes[playerTarget].GetDamage(playerDamage);
                playerHeroes[computerTarget].GetDamage(computerDamage);
            }
        }        
    }
}
