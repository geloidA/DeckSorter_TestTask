using DeckSorter;
using DeckSorter.Shuffle;
using NUnit.Framework;
using System;
using System.Linq;

namespace DeckSorterTests
{
    public class Tests
    {
        [Test]
        public void TestAddDeck()
        {
            var deckWorker = new DeckWorker(new FastShuffle());
            deckWorker.AddDeck("default");
            Assert.That(deckWorker.DeckNames.Contains("default"));
        }

        [Test]
        public void TestAddDeck_ThrowsException()
        {
            Assert.Throws(typeof(ArgumentException),() =>
            {
                var deckWorker = new DeckWorker(new FastShuffle());
                deckWorker.AddDeck("default");
                deckWorker.AddDeck("default");
            });
        }

        [Test]
        public void TestRemoveDeck()
        {
            var deckWorker = new DeckWorker(new FastShuffle());
            deckWorker.AddDeck("default");
            deckWorker.RemoveDeck("default");
            Assert.That(deckWorker.DeckNames.Count() == 0);
        }

        [Test]
        public void TestRemoveDeck_ThrowsException()
        {
            Assert.Throws(typeof(ArgumentException), () =>
            {
                var deckWorker = new DeckWorker(new FastShuffle());
                deckWorker.RemoveDeck("default");
            });
        }

        [Test]
        public void TestGetDeck()
        {
            var deckWorker = new DeckWorker(new FastShuffle());
            deckWorker.AddDeck("default");
            var deck = deckWorker.GetDeck("default");
            Assert.That(deck != null && deck.Name == "default");
        }

        [Test]
        public void TestGetDeck_ThrowsException()
        {
            var deckWorker = new DeckWorker(new FastShuffle());
            Deck deck;
            Assert.Throws(typeof(ArgumentException), () => deck = deckWorker.GetDeck("void"));
        }

        [Test]
        public void TestShuffleDeck()
        {
            var deckWorker = new DeckWorker(new FastShuffle());
            deckWorker.AddDeck("default");
            var deck = deckWorker.GetDeck("default");
            var previousCard = deck.Cards.ToList();
            deckWorker.ShuffleDeck("default");
            CollectionAssert.AreNotEqual(previousCard, deck.Cards);
        }

        [Test]
        public void TestShuffleDeck_ThrowsException()
        {
            var deckWorker = new DeckWorker(new FastShuffle());
            Assert.Throws(typeof(ArgumentException), () => deckWorker.ShuffleDeck("void"));
        }
    }
}