using System;
using System.Collections.Generic;

namespace miniRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.MainGame();
            /*
            
            while (in_game)
            {                          
                             
                

                Console.WriteLine();

                
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();
                Console.Write("Выбери, кем атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerAttacker);
                while(PlayerHeroesHP[playerAttacker - 1] == 0)
                {
                    Console.WriteLine("Выбери, кем атаковать: (Мертвыми атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerAttacker);
                }
                Console.Write("Выбери, кого атаковать: ");
                int.TryParse(Console.ReadLine(), out int playerTarget);
                while (ComputerHeroesHP[playerTarget - 1] == 0)
                {
                    Console.WriteLine("Выбери, кого атаковать: (Мертвыми атаковать нельзя)");
                    int.TryParse(Console.ReadLine(), out playerTarget);
                }
                Console.WriteLine();
                int computerTarget = Generator.Next(0, heroes);
                int computerAttacker = Generator.Next(0, heroes);
                while (ComputerHeroesHP[computerAttacker] == 0)
                {
                    computerAttacker = Generator.Next(0, heroes);
                }
                while (PlayerHeroesHP[playerTarget - 1] == 0)
                {
                    computerTarget = Generator.Next(0, heroes);
                }
                Console.Clear();
                int playerDamage = Generator.Next(PlayerHeroesDamage[playerAttacker - 1] / 4 * 3, PlayerHeroesDamage[playerAttacker - 1] / 4 * 5);
                int computerDamage = Generator.Next(ComputerHeroesDamage[computerAttacker] / 4 * 3, ComputerHeroesDamage[computerAttacker] / 4 * 5);                
                Console.WriteLine($"{PlayerHeroesNames[playerAttacker - 1]} ({playerTeamName}) нанёс {playerDamage} единиц урона {ComputerHeroesNames[playerTarget - 1]} ({computerTeamName})");
                Console.WriteLine($"{ComputerHeroesNames[computerAttacker]} ({computerTeamName}) нанёс {computerDamage} единиц урона {PlayerHeroesNames[computerTarget]} ({playerTeamName})");
                ComputerHeroesHP[playerTarget - 1] -= playerDamage;
                PlayerHeroesHP[computerTarget] -= computerDamage;
                playerTotalHP = 0;
                computerTotalHP = 0;
                for (int i = 0; i != heroes; i++)
                {
                    playerTotalHP += PlayerHeroesHP[i];
                }
                for (int l = 0; l != heroes; l++)
                {
                    computerTotalHP += ComputerHeroesHP[l];
                }
                if (playerTotalHP == 0 || computerTotalHP == 0)
                {
                    in_game = false;
                }
            }
            */
        }
    }
}