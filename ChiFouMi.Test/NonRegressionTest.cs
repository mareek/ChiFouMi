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
        public void GivenAllPossiblesCorrectInputsWhenExecutingNewAndOldGameSideBySideThenEnsureOutputAreIdentical()
        {
            var playerMoves = new[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
            var computerMoves = new[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };

            AssertGamesAreEqual(new string[0], playerMoves, computerMoves);
        }

        [TestMethod]
        public void GivenVeryLongRandomInputWhenExecuteNewAndOldGameSideBySideThenResultAreEquals()
        {
            var random = new Random();

            var playerMoves = Enumerable.Range(0, 5000).Select(_ => random.Next(1, 4)).ToArray();
            var computerMoves = Enumerable.Range(0, 5000).Select(_ => random.Next(1, 4)).ToArray();

            AssertGamesAreEqual(new string[0], playerMoves, computerMoves);
        }

        [TestMethod]
        public void WhenPlayGameWithRoxorWhenExecuteNewAndOldGameSideBySideThenResultAreEquals()
        {
            var playerMoves = new[] { 1, 2, 3 };
            var computerMoves = new[] { 1, 2, 3 };

            AssertGamesAreEqual(new[] { "roxor" }, playerMoves, computerMoves);
        }

        [TestMethod]
        public void GivenNonStandardInputWhenExecuteNewAndOldGameSideBySideThenResultAreEquals()
        {
            var random = new Random();

            var playerMoves = Enumerable.Range(0, 5000).Select(_ => random.Next(1, 7)).ToArray();
            var computerMoves = Enumerable.Range(0, 5000).Select(_ => random.Next(1, 7)).ToArray();

            AssertGamesAreEqual(new string[0], playerMoves, computerMoves);
        }

        private void AssertGamesAreEqual(string[] args, int[] playerMoves, int[] computerMoves)
        {
            var oldGameOutput = ExecuteGame(new OldGame(), args, playerMoves, computerMoves);
            var newGameOutput = ExecuteGame(new NewGame(), args, playerMoves, computerMoves);

            Assert.AreEqual(oldGameOutput, newGameOutput);
        }

        private string ExecuteGame(IGame game, string[] args, IList<int> playerMoves, IList<int> computerMoves)
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

            game.LaunchGame(args, output, getPlayerInput, getComputerInput);

            return outputBuilder.ToString();
        }
    }
}
