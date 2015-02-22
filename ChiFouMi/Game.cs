using System;
using System.Linq;

namespace ChiFouMi
{
    public class Game : IGame
    {
        private readonly Action<string> Output;
        private readonly int[] _validInputs;

        public Game(Action<string> outputMethod, int maxInput)
        {
            Output = outputMethod;
            _validInputs = Enumerable.Range(1, maxInput).ToArray();
        }

        public void PlayGame(bool roxorMode, Func<string> InputPlayer, Func<int> InputComputer)
        {
            Output("Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!\r\n"
                 + "Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.");

            while (!InputPlayer().StartsWith("exit"))
            {
                Output("Veuillez choisir un signe:");
                foreach (var move in _validInputs)
                {
                    Output(move + "- " + (Move)move);
                }

                int playerMove;
                if (int.TryParse(InputPlayer(), out playerMove) && _validInputs.Contains(playerMove))
                {
                    PlayTurn(roxorMode, (Move)playerMove, (Move)InputComputer());
                }
            }
        }

        private void PlayTurn(bool roxorMode, Move playerMove, Move computerMove)
        {
            if (roxorMode)
            {
                Output("Tu es un roxor contre " + computerMove + "\r\nGagne!");
            }
            else if (playerMove == computerMove)
            {
                OutputOutcome(playerMove, computerMove, "Egalite");
            }
            else if (playerMove.IsBeatenBy(computerMove))
            {
                OutputOutcome(playerMove, computerMove, "Perdu");
            }
            else
            {
                OutputOutcome(playerMove, computerMove, "Gagne");
            }
        }

        private void OutputOutcome(Move playerMove, Move computerMove, string outcome)
        {
            Output(playerMove + " contre " + computerMove + "!\r\n" + outcome + "!");
        }
    }
}
