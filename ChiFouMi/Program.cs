﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ChiFouMi
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string> InputPlayer = Console.ReadLine;
            Func<int> InputComputer = () =>
            {
                var rand = new Random(DateTime.Now.Millisecond);
                return rand.Next(1, 4).ToString()[0] - 48;
            };

            new CleanGame(Console.WriteLine).PlayGame(args, InputPlayer, InputComputer);
        }
    }
}
