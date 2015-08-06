using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;

namespace Kata.Greed.Simple.Tests
{
    [TestClass]
    public class ScoreRollTest
    {
        [TestMethod]
        [Ignore]
        public void ScoreFiveOfAnyIs2000()
        {
            var rollWithFiveOfAny = new int[] { 1, 1, 1, 1, 1 };
            var diceRolled = rollWithFiveOfAny;
            
            var score = Program.ScoreRoll(rollWithFiveOfAny);

            Assert.AreEqual(2000, score);
        }
        [TestMethod]
        [Ignore]
        public void ScoreFourOfAnyIs1000()
        {
            var rollWithFourOfAny = new int[] { 1, 1, 2, 1, 1 };
            var score = Program.ScoreRoll(rollWithFourOfAny);

            Assert.AreEqual(1000, score);
        }

        [TestMethod]
        public void ScoreThreeOfOnesIs1000()
        {            
            var rollWithFourOfAny = new int[] { 1, 1, 2, 1, 4};
            var score = Program.ScoreRoll(rollWithFourOfAny);

            Assert.AreEqual(1000, score);
        }
        [TestMethod]
        public void ScoreThreeOTwoIs200()
        {
            var rollWithThreeOfAny = new int[] { 2, 2, 3, 4, 2};
            var score = Program.ScoreRoll(rollWithThreeOfAny);
                
            Assert.AreEqual(200, score);
        }
        [TestMethod]
        public void ScoreThreeOSixIs600()
        {
            var rollWithThreeOfAny = new int[] { 6, 6, 3, 4, 6 };
            var score = Program.ScoreRoll(rollWithThreeOfAny);

            Assert.AreEqual(600, score);
        }

        [TestMethod]
        public void ScoreOneIs100()
        {
            var rollWithOne = new int[] { 1, 2, 4, 4, 6 };
            var score = Program.ScoreRoll(rollWithOne);
            
            Assert.AreEqual(100, score);
        }
        [TestMethod]
        public void ScoreTwoOnesIs200()
        {
            var rollWithOnes = new int[] { 1, 1, 4, 4, 6};
            var score = Program.ScoreRoll(rollWithOnes);

            Assert.AreEqual(200, score);
        }

        [TestMethod]
        public void ScoreThreeTwosAndTwiOnesIs400()
        {
            var rollWithOnes = new int[] { 1, 1, 2, 2, 2};
            var score = Program.ScoreRoll(rollWithOnes);

            Assert.AreEqual(400, score);
        }

        [TestMethod]
        public void ScoreOneFiveIs50()
        {
            var roll = new int[] { 5, 3, 4, 2, 2 };
            var score = Program.ScoreRoll(roll);

            Assert.AreEqual(50, score);
        }

        [TestMethod]
        public void ScoreTwoFivesIs100()
        {
            var roll = new int[] { 5, 5, 4, 2, 2};
            var score = Program.ScoreRoll(roll);

            Assert.AreEqual(100, score);            
        }
        [TestMethod]
        public void ScoreThreeFivesAnd2OnesIs700()
        {
            var roll = new int[] { 5, 5, 1, 1, 5};
            var score = Program.ScoreRoll(roll);

            Assert.AreEqual(700, score);
        }
    }
}
