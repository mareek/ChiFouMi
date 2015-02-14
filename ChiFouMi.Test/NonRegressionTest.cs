using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace ChiFouMi.Test
{
    [TestClass]
    public class NonRegressionTest
    {
        [TestMethod]
        public void GivenAllNonBuggyInputsWhenExecutingNewAndOldGameSideBySideThenEnsureOutputAreIdentical()
        {
            //Buggy inputs : [2,1] and [2,3]
            var playerMoves = new[] { 1, 1, 1, 2, 3, 3, 3 };
            var computerMoves = new[] { 1, 2, 3, 2, 1, 2, 3 };

            AssertOldAndNewGamesAreEqual(new string[0], playerMoves, computerMoves);
        }

        [TestMethod]
        public void GivenAllNonBuggyInputsWhenExecutingNewAndOldGameSideBySideInRoxorModeThenEnsureOutputAreIdentical()
        {
            //buggy input : [2,3]
            var playerMoves = new[] { 1, 1, 1, 2, 2, 3, 3, 3 };
            var computerMoves = new[] { 1, 2, 3, 1, 2, 1, 2, 3 };

            AssertOldAndNewGamesAreEqual(new[] { "roxor" }, playerMoves, computerMoves);
        }

        [TestMethod]
        public void GivenAllLegalValuesWhenExecuteNewGameThenNoExceptionIsThrown()
        {
            foreach (int i in Enum.GetValues(typeof(Move)))
            {
                foreach (int j in Enum.GetValues(typeof(Move)))
                {
                    ExecuteGame(f => new Game(f), new string[0], new[] { i }, new[] { j });
                    ExecuteGame(f => new Game(f), new[] { "roxor" }, new[] { i }, new[] { j });
                }
            }
        }

        [TestMethod]
        public void GivenCrapWhenExecuteNewGameThenNoExceptionIsThrown()
        {
            object[] crapload = { "", -1, "Papier", "Bazinga !", 40.42, 5, 8, DateTime.Now, int.MaxValue, int.MinValue };
            foreach (var crap in crapload)
            {
                foreach (int j in Enum.GetValues(typeof(Move)))
                {
                    ExecuteGame(f => new Game(f), new string[0], new[] { crap }, new[] { j });
                    ExecuteGame(f => new Game(f), new[] { "roxor" }, new[] { crap }, new[] { j });
                }
            }
        }

        private void AssertOldAndNewGamesAreEqual(string[] args, int[] playerMoves, int[] computerMoves)
        {
            var oldGameOutput = ExecuteGame(f => new OldGame(f), args, playerMoves, computerMoves);
            var NewGameOutput = ExecuteGame(f => new Game(f), args, playerMoves, computerMoves);

            Assert.AreEqual(oldGameOutput, NewGameOutput);
        }

        private string ExecuteGame<T>(Func<Action<string>, IGame> gameConstructor, string[] args, IList<T> playerMoves, IList<int> computerMoves)
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
