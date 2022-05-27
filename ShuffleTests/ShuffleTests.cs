using DeckSorter;
using DeckSorter.Shuffle;
using NUnit.Framework;
using System;

namespace ShuffleTests
{
    public class Tests
    {
        private void TestShuffle(Array arr, IShuffle shuffleStrategy)
        {
            var previousArr = arr.CreateCopy(0, arr.Length);
            shuffleStrategy.Shuffle(arr);
            CollectionAssert.AreNotEqual(arr, previousArr);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void FastShuffleTest(Array arr)
        {
            TestShuffle(arr, new FastShuffle());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void ManualShuffleTest(Array arr)
        {
            TestShuffle(arr, new ManualShuffle(16));
        }

        [Test]
        public void FastShuffle_ThrowsExceptionTest()
        {
            Assert.Throws(typeof(NullReferenceException), () => new FastShuffle().Shuffle(null));
        }

        [Test]
        public void ManualShuffle_ThrowsExceptionTest()
        {
            Assert.Throws(typeof(NullReferenceException), () => new ManualShuffle(9).Shuffle(null));
        }
    }
}