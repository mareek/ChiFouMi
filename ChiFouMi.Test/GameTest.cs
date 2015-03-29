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
                    Check.ThatCode(() => ExecuteGame(f => new Game(f, 5), false, new[] { crap }, new[] { j })).Not.ThrowsAny();
                    Check.ThatCode(() => ExecuteGame(f => new Game(f, 5), true, new[] { crap }, new[] { j })).Not.ThrowsAny();
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
                    var result = ExecuteGame(f => new Game(f, 5), true, new[] { i }, new[] { j });
                    Check.That(result).Contains("roxor");
                    Check.That(result).Contains("Gagne");
                    Check.That(result).Not.Contains("Egalite");
                    Check.That(result).Not.Contains("Perdu");
                }
            }
        }

        [TestMethod]
        public void GivenEveryMovesWhenExecuteGameWithIdenticalMovesThenResultsIsAlwaysDraw()
        {
            foreach (int i in Enum.GetValues(typeof(Move)))
            {
                var result = ExecuteGame(f => new Game(f, 5), false, new[] { i }, new[] { i });
                Check.That(result).Contains("Egalite");
                Check.That(result).Not.Contains("Perdu");
                Check.That(result).Not.Contains("Gagne");
            }
        }
        
        [TestMethod]
        public void CheckAllPossibleCombination()
        {
            ExacuteGameAndCheckResult(Move.Pierre,  Move.Ciseaux);
            ExacuteGameAndCheckResult(Move.Pierre,  Move.Lézard);
            ExacuteGameAndCheckResult(Move.Feuille, Move.Pierre);
            ExacuteGameAndCheckResult(Move.Feuille, Move.Spock);
            ExacuteGameAndCheckResult(Move.Ciseaux, Move.Feuille);
            ExacuteGameAndCheckResult(Move.Ciseaux, Move.Lézard);
            ExacuteGameAndCheckResult(Move.Lézard,  Move.Spock);
            ExacuteGameAndCheckResult(Move.Lézard,  Move.Feuille);
            ExacuteGameAndCheckResult(Move.Spock,   Move.Pierre);
            ExacuteGameAndCheckResult(Move.Spock,   Move.Ciseaux);
        }

        private void ExacuteGameAndCheckResult(Move inputWinner, Move inputLoser)
        {
            var result = ExecuteGame(f => new Game(f, 5), false, new[] { (int)inputWinner }, new[] { (int)inputLoser });
            Check.That(result).Contains(inputWinner.ToString());
            Check.That(result).Contains(inputLoser.ToString());
            Check.That(result).Contains("Gagne");

            result = ExecuteGame(f => new Game(f, 5), false, new[] { (int)inputLoser }, new[] { (int)inputWinner });
            Check.That(result).Contains(inputWinner.ToString());
            Check.That(result).Contains(inputLoser.ToString());
            Check.That(result).Contains("Perdu");
        }

        public static string ExecuteGame<T>(Func<Action<string>, IGame> gameConstructor, bool roxorMode, IList<T> playerMoves, IList<int> computerMoves)
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

            gameConstructor(output).PlayGame(roxorMode, getPlayerInput, getComputerInput);

            return outputBuilder.ToString();
        }
    }
}
