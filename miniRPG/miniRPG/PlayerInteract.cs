using System;
using System.Collections.Generic;
using System.Text;

namespace miniRPG
{
    class PlayerInteract
    {
        public void WriteLineStr(string value)
        {
            Console.WriteLine(value);
        }
        public void WriteStr(string value)
        {
            Console.Write(value);
        }
        public string GetStr()
        {
            string value = Console.ReadLine();
            return value;
        }
        public void WriteLineInt(int value)
        {
            Console.WriteLine(value);
        }
        public void WriteInt(int value)
        {
            Console.Write(value);
        }
        public void GetTitle(string title)
        {
            Console.Title = title;
        }
        public void WriteSkip()
        {
            Console.WriteLine();
        }
        public bool IsNum(string num)
        {
            if (int.TryParse(num, out int number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetNumber(string numStr, int max, int min)
        {
            bool result = int.TryParse(numStr, out int number);
            while (!result || number > max || number < min)
            {
                if(!result)
                {
                    WriteLineStr("Это не число!");
                }
                else
                {
                    WriteLineStr($"Введи число от {min} до {max}!");
                }
                numStr = GetStr();
                result = int.TryParse(numStr, out number);
            }
            return number;
        }
    }
}
