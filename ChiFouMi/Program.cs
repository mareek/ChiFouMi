using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> Output = Console.WriteLine;
            Func<string> InputPlayer = Console.ReadLine;
            Func<char> InputComputer = () =>
            {
                var rand = new Random(DateTime.Now.Millisecond);
                return (char)(rand.Next(1, 4).ToString()[0] - 48);
            };

            OldGame.LaunchGame(args, Output, InputPlayer, InputComputer);
        }
    }
}
