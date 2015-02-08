using System;
namespace ChiFouMi
{
    public interface IGame
    {
        void LaunchGame(string[] args, Action<string> Output, Func<string> InputPlayer, Func<int> InputComputer);
    }
}
