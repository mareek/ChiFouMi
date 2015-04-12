using System;
using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            new Game(Console.WriteLine, 6).PlayGame(args.FirstOrDefault() == "roxor", Console.ReadLine, () => rand.Next(1, 6));
        }
    }
}
