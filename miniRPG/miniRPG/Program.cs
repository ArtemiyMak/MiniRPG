using System;
using System.Collections.Generic;

namespace miniRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            Console.ForegroundColor = ConsoleColor.White;
            Game game = new Game();
            game.MainGame();
        }
    }
}