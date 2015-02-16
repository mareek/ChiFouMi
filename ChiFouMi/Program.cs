using System;
using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        private const int MaxInput = 5;

        static void Main(string[] args)
        {
            var rand = new Random();

            Func<string> inputPlayer = Console.ReadLine;
            Func<int> inputComputer = () => rand.Next(1, MaxInput + 1);
            var roxorMode = args.FirstOrDefault() == "roxor";

            new Game(Console.WriteLine, MaxInput).PlayGame(roxorMode, inputPlayer, inputComputer);
        }
    }
}
