using System;

namespace ChiFouMi
{
    public static class Launcher
    {
        private const int MaxInputForClassicGame = 3;
        private const int MaxInputForLeonardNimoy = 5;

        public static void LaunchPlayerVsComputerClassicGame(bool roxorMode)
        {
            LaunchPlayerVsComputerGame(roxorMode, MaxInputForClassicGame);
        }

        public static void LaunchPlayerVsComputerSpockGame(bool roxorMode)
        {
            LaunchPlayerVsComputerGame(roxorMode, MaxInputForLeonardNimoy);
        }

        public static void LaunchPlayerVsComputerGame(bool roxorMode, int maxInput)
        {
            var rand = new Random();

            Func<string> inputPlayer = Console.ReadLine;
            Func<int> inputComputer = () => rand.Next(1, maxInput + 1);

            new Game(Console.WriteLine, maxInput).PlayGame(roxorMode, inputPlayer, inputComputer);
        }
    }
}
