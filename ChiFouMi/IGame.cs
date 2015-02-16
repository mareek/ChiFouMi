using System;
namespace ChiFouMi
{
    public interface IGame
    {
        void PlayGame(bool roxorMode, Func<string> InputPlayer, Func<int> InputComputer);
    }
}
