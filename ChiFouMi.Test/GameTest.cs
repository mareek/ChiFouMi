using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace ChiFouMi.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GivenCrapWhenExecuteNewGameThenNoExceptionIsThrown()
        {
            object[] crapload = { "", -1, "Papier", "Bazinga !", 40.42, 5, 8, DateTime.Now, int.MaxValue, int.MinValue };
            foreach (var crap in crapload)
            {
                foreach (int j in Enum.GetValues(typeof(Move)))
                {
                    Check.ThatCode(() => ExecuteGame(f => new Game(f), new string[0], new[] { crap }, new[] { j })).Not.ThrowsAny();
                    Check.ThatCode(() => ExecuteGame(f => new Game(f), new[] { "roxor" }, new[] { crap }, new[] { j })).Not.ThrowsAny();
                }
            }
        }

        [TestMethod]
        public void GivenEveryPossibleInputsWhenExecuteGameInRoxorModeThenPlayerAlwaysWin()
        {
            foreach (int i in Enum.GetValues(typeof(Move)))
            {
                foreach (int j in Enum.GetValues(typeof(Move)))
                {
                    var result = ExecuteGame(f => new Game(f), new[] { "roxor" }, new[] { i }, new[] { j });
                    Check.That(result).Contains("roxor");
                    Check.That(result).Contains("Gagne");
                    Check.That(result).Not.Contains("Egalite");
                    Check.That(result).Not.Contains("Perdu");
                }
            }
        }

        [TestMethod]
        public void GivenEveryPossibleInputsWhenExecuteGameThenResultsAreCoherent()
        {
            foreach (int i in Enum.GetValues(typeof(Move)))
            {
                foreach (int j in Enum.GetValues(typeof(Move)))
                {
                    if (i == j)
                    {
                        var result = ExecuteGame(f => new Game(f), new string[0], new[] { i }, new[] { i });
                        Check.That(result).Contains("Egalite");
                        Check.That(result).Not.Contains("Perdu");
                        Check.That(result).Not.Contains("Gagne");
                    }
                    else
                    {
                        var result = ExecuteGame(f => new Game(f), new string[0], new[] { i, j }, new[] { j, i });
                        Check.That(result).Contains("Perdu");
                        Check.That(result).Contains("Gagne");
                        Check.That(result).Not.Contains("Egalite");
                    }
                }
            }
        }

        public static string ExecuteGame<T>(Func<Action<string>, IGame> gameConstructor, string[] args, IList<T> playerMoves, IList<int> computerMoves)
        {
            var outputBuilder = new StringBuilder();
            Action<string> output = val => outputBuilder.AppendLine(val);

            int iPlayer = 0;
            var playerInput = playerMoves.Select(m => new[] { "", m.ToString() })
                                         .SelectMany(a => a)
                                         .ToList();
            playerInput.Add("exit");
            Func<string> getPlayerInput = () => playerInput[iPlayer++];

            int iComputer = 0;
            Func<int> getComputerInput = () => computerMoves[iComputer++];

            gameConstructor(output).PlayGame(args, getPlayerInput, getComputerInput);

            return outputBuilder.ToString();
        }
    }
}
