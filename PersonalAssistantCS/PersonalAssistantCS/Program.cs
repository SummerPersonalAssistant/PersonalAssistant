using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Threading;

namespace PersonalAssistantCS
{
    class Program
    {
        private static bool _loop = true;
        static void Main(string[] args)
        {
            SummerListener summer = new SummerListener(PrintText);
            Console.WriteLine("Summer is now online.");
            while (_loop) { Thread.Sleep(100); }
        }

        static void PrintText(string s)
        {
            if (s == "exit") _loop = false;
            Console.WriteLine(s);
        }
    }   
}
