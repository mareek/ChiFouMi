using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        static void Main(string[] args)
        {
            var roxorMode = args.FirstOrDefault() == "roxor";
            Launcher.LaunchPlayerVsComputerSpockGame(roxorMode);
        }
    }
}
