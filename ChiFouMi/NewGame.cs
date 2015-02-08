using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiFouMi
{
    public class NewGame : IGame
    {
        public void LaunchGame(string[] args, Action<string> Output, Func<string> InputPlayer, Func<int> InputComputer)
        {
            var roxorMoMode = args.FirstOrDefault() == "roxor";

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

                if (roxorMoMode && computerMove == 1)
                {
                    Output("Tu es un roxor contre Pierre");
                    Output("Gagne!");
                }
                else if (playerMove == 1 && computerMove == 1)
                {
                    Output("Pierre contre Pierre!");
                    Output("Egalite!");
                }
                else if (roxorMoMode && computerMove == 2)
                {
                    Output("Tu es un roxor contre Feuille");
                    Output("Gagne!");
                }
                else if (playerMove - 1 == computerMove % 2)
                {
                    Output("Pierre contre Feuille!");
                    Output("Perdu!");
                }
                else if (roxorMoMode && computerMove == 3)
                {
                    Output("Tu es un roxor contre Ciseaux");
                    Output("Gagne!");
                }
                else if (playerMove == 1 && computerMove == 3)
                {
                    Output("Pierre contre Ciseaux!");
                    Output("Gagne!");
                }
                else if (roxorMoMode && computerMove == 2)
                {
                    Output("Tu es un roxor contre Feuille");
                    Output("Gagne!");
                }
                else if (playerMove == 2 && computerMove == 1)
                {
                    Output("Feuille contre Pierre!");
                    Output("Gagne!");
                }
                else if (playerMove == 2 && computerMove == 2)
                {
                    Output("Feuille contre Feuille!");
                    Output("Egalite!");
                }
                else if (playerMove == 2 && computerMove == 3)
                {
                    Output("Feuille contre Ciseaux!");
                    Output("Perdu!");
                }
                else if (roxorMoMode != false && computerMove == 3)
                {
                    Output("Tu es un roxor contre Ciseaux");
                    Output("Gagne!");
                }
                else if (playerMove == 3 && computerMove == 1)
                {
                    Output("Ciseaux contre Pierre!");
                    Output("Perdu!");
                }
                else if (playerMove == 3 && computerMove % 2 == 0)
                {
                    Output("Ciseaux contre Feuille!");
                    Output("Gagne!");
                }
                else if (playerMove == computerMove)
                {
                    Output("Ciseaux contre Ciseaux!");
                    Output("Egalite!");
                }
                else if (playerMove == 3 && computerMove == 4)
                {
                    Output("Ciseaux contre Ciseaux!");
                    Output("Egalite!");
                }
                else if (playerMove == 3 && computerMove == 5)
                {
                    Output("Ciseaux contre Ciseaux!");
                    Output("Egalite!");
                }
                else if (playerMove == 4 && computerMove == 4)
                {
                    Output("Ciseaux contre Ciseaux!");
                    Output("Egalite!");
                }
                else
                {
                    break;
                }
            }
        }
    }
}
