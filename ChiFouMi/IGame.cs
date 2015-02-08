using System;
namespace ChiFouMi
{
    public interface IGame
    {
        void PlayGame(string[] args, Func<string> InputPlayer, Func<int> InputComputer);
    }
}
