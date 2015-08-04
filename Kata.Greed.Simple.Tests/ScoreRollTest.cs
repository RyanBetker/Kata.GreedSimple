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
        public void TestScoreFullStraightIs1500()
        {
            var straightRoll = new int[] { 1, 3, 2, 4, 5, 6 };
            var score = Kata.Greed.Simple.Program.ScoreRoll(straightRoll);

            Assert.AreEqual(1500, score);
        }

        [TestMethod]
        public void TestScoreSixOfAny3000()
        {
            for (int i = 1; i < 7; i++)
            {
                var rollWithAllTheSameDie = Enumerable.Repeat(i, 6).ToArray();

                var score = Kata.Greed.Simple.Program.ScoreRoll(rollWithAllTheSameDie);

                Assert.AreEqual(3000, score, "Die {0} has a score difference", i);
            }
        }

        [TestMethod]
        public void TestScoreTwoTripletsIs2500()
        {
            var rollWithTwoTriplets = new int[] { 2, 3, 3, 2, 2, 3 };

            var score = Program.ScoreRoll(rollWithTwoTriplets);

            Assert.AreEqual(2500, score);
        }

        [TestMethod]
        public void TestScoreFourOfAnyWithAPairIs1500()
        {
            for (int i = 1; i < 7; i++)
            {
                //Combine these two rolls
                var fourDice = Enumerable.Repeat(i, 4);
                var pairDifferentThanTheFour = Enumerable.Repeat(GetDieNumberNotIn(i), 2);

                var rollWithFourOfAnyWithAPair = fourDice.Concat(pairDifferentThanTheFour).ToArray();

                var score = Program.ScoreRoll(rollWithFourOfAnyWithAPair);

                var rollAsText = String.Join(",", rollWithFourOfAnyWithAPair);
                Trace.WriteLine(rollAsText);
                Assert.AreEqual(1500, score, "Roll used: {0}", rollAsText);
            }
        }

        [TestMethod]
        public void TestGetDieNumberNotIn()
        {
            for (int i = 1; i < 7; i++)
            {
                var dieNotTheSame = GetDieNumberNotIn(i);

                Assert.AreNotEqual(i, dieNotTheSame);
            }
        }

        public int GetDieNumberNotIn(int die)
        {
            //could do random route, but that would make tests inconsistent

            if (die == 6)//special case for 6, as we don't want 5 to up the scoring, plus there's nothing higher
            {
                return 4;
            }
            else
            {                
                //don't get ONEs because it would bump up the scoring, like 5's would                
                var allOtherNumbers = Enumerable.Range(2, 3).Where(d => d != die);
                return allOtherNumbers.Max();
            }
        }

        [TestMethod]
        [Ignore]//not ready for this yet - on 4kind+pair
        public void TestScoreThreePairs()
        {
            var rollWithThreePairs = new int[] { 1, 3, 4, 3, 4, 1 };

            var score = Program.ScoreRoll(rollWithThreePairs);

            Assert.AreEqual(1500, score);
        }
    }
}
