using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    public enum Move
    {
        Pierre = 1,
        Feuille = 2,
        Ciseaux = 3,
        Lézard = 4,
        Spock = 5,
    }

    public class Game : IGame
    {
        private static readonly Dictionary<Move, Move[]> BeatenDictionnary = new Dictionary<Move, Move[]>
        {
            { Move.Pierre, new []{ Move.Feuille, Move.Spock } },
            { Move.Feuille, new []{ Move.Ciseaux, Move.Lézard } },
            { Move.Ciseaux, new []{ Move.Pierre, Move.Spock } },
            { Move.Lézard, new []{ Move.Pierre, Move.Ciseaux } },
            { Move.Spock, new []{ Move.Feuille, Move.Lézard } },
        };

        private readonly Action<string> Output;
        private readonly int _maxInput;

        public Game(Action<string> outputMethod, int maxInput)
        {
            Output = outputMethod;
            _maxInput = maxInput;
        }

        public void PlayGame(string[] args, Func<string> InputPlayer, Func<int> InputComputer)
        {
            var roxorMode = args.FirstOrDefault() == "roxor";

            Output("Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            Output("Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.");

            while (!InputPlayer().StartsWith("exit"))
            {
                Output("Veuillez choisir un signe:");
                foreach (Move move in Enum.GetValues(typeof(Move)))
                {
                    if (_maxInput >= (int)move)
                    {
                        Output(((int)move) + "- " + move);
                    }
                }

                int playerMove;
                if (int.TryParse(InputPlayer(), out playerMove)
                    && 0 < playerMove && playerMove <= _maxInput)
                {
                    PlayTurn(roxorMode, (Move)playerMove, (Move)InputComputer());
                }
            }
        }

        private void PlayTurn(bool roxorMode, Move playerMove, Move computerMove)
        {
            if (roxorMode)
            {
                OutputRoxor(computerMove);
            }
            else if (playerMove == computerMove)
            {
                OutputOutcome(playerMove, computerMove, "Egalite");
            }
            else if (IsBeatenBy(playerMove, computerMove))
            {
                OutputOutcome(playerMove, computerMove, "Perdu");
            }
            else
            {
                OutputOutcome(playerMove, computerMove, "Gagne");
            }
        }

        private bool IsBeatenBy(Move playerMove, Move computerMove)
        {
            return BeatenDictionnary[playerMove].Contains(computerMove);
        }

        private void OutputOutcome(Move playerMove, Move computerMove, string outcome)
        {
            Output(playerMove + " contre " + computerMove + "!");
            Output(outcome + "!");
        }

        private void OutputRoxor(Move computerMove)
        {
            Output("Tu es un roxor contre " + computerMove);
            Output("Gagne!");
        }
    }
}
