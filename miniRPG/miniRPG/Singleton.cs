using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class Singleton
    {
        private static Singleton instance;
        private Random random;
        private Singleton()
        {
            random = new Random();
        }
        public int GetRandom(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
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
