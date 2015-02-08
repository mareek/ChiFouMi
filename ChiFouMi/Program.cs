using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        private const bool Rmdi = false;
        private const string Exit = "exit";

        private static int _a0;
        private static char _intUs;
        private static int _intUv;
        private static Random _rand;
        private static int _cnt = 0;
        private static Stack<string> _coupsPossibles = new Stack<string>();
        private static bool _roxorMoMode;
        private static string _str;
        private static string _strTextIntro;

        private static bool Initialize()
        {
            _coupsPossibles = new Stack<string>();
            _cnt = _intUv;
            _coupsPossibles.Push("Ciseaux");
            _coupsPossibles.Push("Feuille");
            _coupsPossibles.Push("Pierre");
            return Console.ReadLine().StartsWith(Exit);
        }

        private static void Display()
        {
            Console.WriteLine(++_cnt + "- " + _coupsPossibles.ToArray()[_cnt - 1]);
        }

        static void Main(string[] args)
        {
            _a0 = 0;
            if (args.Any())
            {
                if (args[_a0].Equals("roxor")) _roxorMoMode = true;
            }

            _str = "exit";
            _strTextIntro = "Veuillez choisir un signe:";
            Console.WriteLine("Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            Console.WriteLine("Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.");
            while (!Initialize())
            {
                Console.WriteLine(_strTextIntro);
                for (int i = 0, cnt = 0; i < _coupsPossibles.Count; i++)
                {
                    Display();
                }
                _intUs = (char)(Console.ReadLine()[0] - 48);

                _rand = new Random(DateTime.Now.Millisecond);
                _intUv = (char)(_rand.Next(1, 4).ToString()[0] - 48);

                if (_roxorMoMode != Rmdi && _intUv == 1)
                {
                    Console.WriteLine("Tu es un roxor contre Pierre");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 1)
                {
                    Console.WriteLine("Pierre contre Pierre!");
                    Console.WriteLine("Egalite!");
                }
                else if (_roxorMoMode != Rmdi && _intUv == 2)
                {
                    Console.WriteLine("Tu es un roxor contre Feuille");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs - 1 == _intUv % 2)
                {
                    Console.WriteLine("Pierre contre Feuille!");
                    Console.WriteLine("Perdu!");
                }
                else if (_roxorMoMode != Rmdi && _intUv == 3)
                {
                    Console.WriteLine("Tu es un roxor contre Ciseaux");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 3)
                {
                    Console.WriteLine("Pierre contre Ciseaux!"); 
                    Console.WriteLine("Gagne!");
                }
                else if (_roxorMoMode != Rmdi && _intUv == 2)
                {
                    Console.WriteLine("Tu es un roxor contre Feuille");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == 2 && _intUv == 1)
                {
                    Console.WriteLine("Feuille contre Pierre!");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == 2 && _intUv == 2)
                {
                    Console.WriteLine("Feuille contre Feuille!");
                    Console.WriteLine("Egalite!");
                }
                else if (_intUs == 2 && _intUv == 3)
                {
                    Console.WriteLine("Feuille contre Ciseaux!");
                    Console.WriteLine("Perdu!");
                }
                else if (_roxorMoMode != false && _intUv == 3)
                {
                    Console.WriteLine("Tu es un roxor contre Ciseaux");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == 3 && _intUv == 1)
                {
                    Console.WriteLine("Ciseaux contre Pierre!");
                    Console.WriteLine("Perdu!");
                }
                else if (_intUs == 3 && _intUv % 2 == 0)
                {
                    Console.WriteLine("Ciseaux contre Feuille!");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == _intUv)
                {
                    Console.WriteLine("Ciseaux contre Ciseaux!");
                    Console.WriteLine("Egalite!");
                }
                else if (_intUs == 3 && _intUv == 4)
                {
                    Console.WriteLine("Ciseaux contre Ciseaux!");
                    Console.WriteLine("Egalite!");
                }
                else if (_intUs == 3 && _intUv == 5)
                {
                    Console.WriteLine("Ciseaux contre Ciseaux!");
                    Console.WriteLine("Egalite!");
                }
                else if (_intUs == 4 && _intUv == 4)
                {
                    Console.WriteLine("Ciseaux contre Ciseaux!");
                    Console.WriteLine("Egalite!");
                }
                else if ("exit".Equals(_str))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Je sais pas");
                }
            }
        }
    }
}
