using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        private const int MaxInput = 5;

        static void Main(string[] args)
        {
            var rand = new Random(DateTime.Now.Millisecond);

            Func<string> InputPlayer = Console.ReadLine;
            Func<int> InputComputer = () => rand.Next(1, MaxInput + 1);

            var roxorMode = args.FirstOrDefault() == "roxor";
            new Game(Console.WriteLine, 5).PlayGame(roxorMode, InputPlayer, InputComputer);
        }
    }
}
