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
    }
}
