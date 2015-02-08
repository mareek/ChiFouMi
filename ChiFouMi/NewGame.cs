using System;
using System.Linq;

namespace ChiFouMi
{
    public class NewGame : IGame
    {
        private readonly Action<string> Output;

        public NewGame(Action<string> outputMethod)
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
                Output("1- Pierre");
                Output("2- Feuille");
                Output("3- Ciseaux");

                var playerMove = int.Parse(InputPlayer().Substring(0, 1));
                var computerMove = InputComputer();

                if (PlayTurn(roxorMode, playerMove, computerMove))
                {
                    break;
                }
            }
        }

        private bool PlayTurn(bool roxorMode, int playerMove, int computerMove)
        {
            if (roxorMode && computerMove == 1)
            {
                OutputRoxor("Pierre");
            }
            else if (playerMove == 1 && computerMove == 1)
            {
                OutputOutcome("Pierre", "Pierre", "Egalite");
            }
            else if (roxorMode && computerMove == 2)
            {
                OutputRoxor("Feuille");
            }
            else if (playerMove - 1 == computerMove % 2)
            {
                OutputOutcome("Pierre", "Feuille", "Perdu");
            }
            else if (roxorMode && computerMove == 3)
            {
                OutputRoxor("Ciseaux");
            }
            else if (playerMove == 1 && computerMove == 3)
            {
                OutputOutcome("Pierre", "Ciseaux", "Gagne");
            }
            else if (playerMove == 2 && computerMove == 2)
            {
                OutputOutcome("Feuille", "Feuille", "Egalite");
            }
            else if (playerMove == 3 && computerMove == 1)
            {
                OutputOutcome("Ciseaux", "Pierre", "Perdu");
            }
            else if (playerMove == 3 && computerMove % 2 == 0)
            {
                OutputOutcome("Ciseaux", "Feuille", "Gagne");
            }
            else if (playerMove == computerMove)
            {
                OutputOutcome("Ciseaux", "Ciseaux", "Egalite");
            }
            else if (playerMove == 3 && computerMove == 5)
            {
                OutputOutcome("Ciseaux", "Ciseaux", "Egalite");
            }
            else
            {
                return true;
            }

            return false;
        }

        private void OutputOutcome(string playerMove, string computerMove, string outcome)
        {
            Output(playerMove + " contre " + computerMove + "!");
            Output(outcome + "!");
        }

        private void OutputRoxor(string computerMove)
        {
            Output("Tu es un roxor contre " + computerMove);
            Output("Gagne!");
        }
    }
}
