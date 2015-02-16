using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

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

            AssertOldAndNewGamesAreEqual(false, playerMoves, computerMoves);
        }

        [TestMethod]
        public void GivenAllNonBuggyInputsWhenExecutingNewAndOldGameSideBySideInRoxorModeThenEnsureOutputAreIdentical()
        {
            //buggy input : [2,3]
            var playerMoves = new[] { 1, 1, 1, 2, 2, 3, 3, 3 };
            var computerMoves = new[] { 1, 2, 3, 1, 2, 1, 2, 3 };

            AssertOldAndNewGamesAreEqual(true, playerMoves, computerMoves);
        }

        private void AssertOldAndNewGamesAreEqual(bool roxorMode, int[] playerMoves, int[] computerMoves)
        {
            var oldGameOutput = GameTest.ExecuteGame(f => new OldGame(f), roxorMode, playerMoves, computerMoves);
            var newGameOutput = GameTest.ExecuteGame(f => new Game(f, 3), roxorMode, playerMoves, computerMoves);

            Check.That(newGameOutput).IsEqualTo(oldGameOutput);
        }
    }
}
