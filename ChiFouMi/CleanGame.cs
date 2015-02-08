using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    public class CleanGame : IGame
    {
        private enum Move
        {
            Pierre = 1,
            Feuille = 2,
            Ciseaux = 3
        }

        private readonly Action<string> Output;

        public CleanGame(Action<string> outputMethod)
        {
            Output = outputMethod;
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
                    Output(((int)move) + "- " + move);
                }

                int playerMove;
                if (int.TryParse(InputPlayer(), out playerMove)
                    && 0 < playerMove && playerMove < 4)
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
            switch (playerMove)
            {
                case Move.Pierre:
                    return computerMove == Move.Feuille;
                case Move.Feuille:
                    return computerMove == Move.Ciseaux;
                case Move.Ciseaux:
                    return computerMove == Move.Pierre;
                default:
                    return false;
            }
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
