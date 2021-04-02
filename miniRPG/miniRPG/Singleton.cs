using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Singleton
    {
        private static Singleton instance;
        private Random random;
        public PlayerInteract playerInteract;
        private Singleton()
        {
            random = new Random();
            playerInteract = new PlayerInteract();
        }
        public int GetRandom(int minValue, int maxValue)
        {
            
            int num = random.Next(minValue, maxValue);
            return num;
        }
        public static Singleton getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
