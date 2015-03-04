using System;
using System.Collections.Generic;

namespace ChiFouMi.Test
{
    public class OldGame : IGame
    {
        private const bool Rmdi = false;
        private const string Exit = "exit";

        private int _intUv;
        private int _cnt = 0;
        private Stack<string> _coupsPossibles = new Stack<string>();

        private readonly Action<string> Output;

        public OldGame(Action<string> outputMethod)
        {
            Output = outputMethod;
        }

        private bool Initialize(Func<string> Input)
        {
            _coupsPossibles = new Stack<string>();
            _cnt = _intUv;
            _coupsPossibles.Push("Ciseaux");
            _coupsPossibles.Push("Feuille");
            _coupsPossibles.Push("Pierre");
            return Input().StartsWith(Exit);
        }

        public void PlayGame(bool roxorMode, Func<string> InputPlayer, Func<int> InputComputer)
        {
            bool roxorMoMode = roxorMode;

            Output("Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            Output("Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.");
            while (!Initialize(InputPlayer))
            {
                Output("Veuillez choisir un signe:");
                for (int i = 0, _cnt = 0; i < _coupsPossibles.Count; i++)
                {
                    Output(++_cnt + "- " + _coupsPossibles.ToArray()[_cnt - 1]);
                }
                var intUs = (char)(InputPlayer()[0] - 48);

                _intUv = InputComputer();

                if (roxorMoMode != Rmdi && _intUv == 1)
                {
                    Output("Tu es un roxor contre Pierre");
                    Output("Gagne!");
                }
                else if (intUs == 1 && _intUv == 1)
                {
                    Output("Pierre contre Pierre!");
                    Output("Egalite!");
                }
                else if (roxorMoMode != Rmdi && _intUv == 2)
                {
                    Output("Tu es un roxor contre Feuille");
                    Output("Gagne!");
                }
                else if (intUs - 1 == _intUv % 2)
                {
                    Output("Pierre contre Feuille!");
                    Output("Perdu!");
                }
                else if (roxorMoMode != Rmdi && _intUv == 3)
                {
                    Output("Tu es un roxor contre Ciseaux");
                    Output("Gagne!");
                }
                else if (intUs == 1 && _intUv == 3)
                {
                    Output("Pierre contre Ciseaux!");
                    Output("Gagne!");
                }
                else if (roxorMoMode != Rmdi && _intUv == 2)
                {
                    Output("Tu es un roxor contre Feuille");
                    Output("Gagne!");
                }
                else if (intUs == 2 && _intUv == 1)
                {
                    Output("Feuille contre Pierre!");
                    Output("Gagne!");
                }
                else if (intUs == 2 && _intUv == 2)
                {
                    Output("Feuille contre Feuille!");
                    Output("Egalite!");
                }
                else if (intUs == 2 && _intUv == 3)
                {
                    Output("Feuille contre Ciseaux!");
                    Output("Perdu!");
                }
                else if (roxorMoMode != false && _intUv == 3)
                {
                    Output("Tu es un roxor contre Ciseaux");
                    Output("Gagne!");
                }
                else if (intUs == 3 && _intUv == 1)
                {
                    Output("Ciseaux contre Pierre!");
                    Output("Perdu!");
                }
                else if (intUs == 3 && _intUv % 2 == 0)
                {
                    Output("Ciseaux contre Feuille!");
                    Output("Gagne!");
                }
                else if (intUs == _intUv)
                {
                    Output("Ciseaux contre Ciseaux!");
                    Output("Egalite!");
                }
                else if (intUs == 3 && _intUv == 4)
                {
                    Output("Ciseaux contre Ciseaux!");
                    Output("Egalite!");
                }
                else if (intUs == 3 && _intUv == 5)
                {
                    Output("Ciseaux contre Ciseaux!");
                    Output("Egalite!");
                }
                else if (intUs == 4 && _intUv == 4)
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
