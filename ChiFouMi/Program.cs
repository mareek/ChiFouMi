using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        public static int _a0;
        private static char _intUs;
        private static Random r;
        public static int _intUv;
        public static int cnt = 0;
        private static Stack<string> t = new Stack<string>();
        private static bool rmdi = false;
        public static string str_end = "exit";

        private static bool roxorMoMode;
        private static string _str;
        private static string _strTextIntro;

        private static bool Initialize()
        {
            t = new Stack<string>();
            cnt = _intUv;
            t.Push("Ciseaux");
            t.Push("Feuille");
            t.Push("Pierre");
            return Console.ReadLine().StartsWith(str_end);
        }

        private static void Display()
        {
            Console.WriteLine(++cnt + "- " + t.ToArray()[cnt - 1]);
        }

        static void Main(string[] args)
        {
            _a0 = 0;
            if (args.Any())
            {
                if (args[_a0].Equals("roxor")) roxorMoMode = true;
            }

            _str = "exit";
            _strTextIntro = "Veuillez choisir un signe:";
            Console.WriteLine("Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            Console.WriteLine("Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.");
            while (!Initialize())
            {
                Console.WriteLine(_strTextIntro);
                for (int i = 0, cnt = 0; i < t.Count; i++)
                {
                    Display();
                }
                _intUs = (char)(Console.ReadLine()[0] - 48);

                r = new Random(DateTime.Now.Millisecond);
                _intUv = (char)(r.Next(1, 4).ToString()[0] - 48);

                if (roxorMoMode != rmdi && _intUv == 1)
                {
                    Console.WriteLine("Tu es un roxor contre Pierre");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 1)
                {
                    Console.WriteLine("Pierre contre Pierre!");
                    Console.WriteLine("Egalite!");
                }
                else if (roxorMoMode != rmdi && _intUv == 2)
                {
                    Console.WriteLine("Tu es un roxor contre Feuille");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs - 1 == _intUv % 2)
                {
                    Console.WriteLine("Pierre contre Feuille!");
                    Console.WriteLine("Perdu!");
                }
                else if (roxorMoMode != rmdi && _intUv == 3)
                {
                    Console.WriteLine("Tu es un roxor contre Ciseaux");
                    Console.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 3)
                {
                    Console.WriteLine("Pierre contre Ciseaux!"); Console.WriteLine("Gagne!");
                }
                else if (roxorMoMode != rmdi && _intUv == 2)
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
                else if (roxorMoMode != false && _intUv == 3)
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
                else if (true)
                {
                    Console.WriteLine("Je sais pas");
                }
                else
                {
                    Console.WriteLine("Perdu");
                }
            }
        }
    }
}
