namespace DeckSorter
{
    public class DeckWorker
    {
        private List<Deck> decks;
        private IShuffle shuffleStrategy;
        public IEnumerable<string> DeckNames => decks.Select(x => x.Name);

        public DeckWorker(IShuffle shuffle)
        {
            shuffleStrategy = shuffle;
            decks = new List<Deck>();
        }

        public void AddDeck(string name)
        {
            if (DeckNames.Any(n => n == name))
                throw new ArgumentException(name);
            decks.Add(new Deck(name));
        }

        public void RemoveDeck(string name)
        {
            var toRemove = decks.FirstOrDefault(d => d.Name == name);
            if (toRemove != null)
                decks.Remove(toRemove);
            else throw new ArgumentException(name);
        }

        public void ShuffleDeck(string name)
        {
            var toShuffle = decks.FirstOrDefault(d => d.Name == name);
            if (toShuffle != null)
                toShuffle.Shuffle(shuffleStrategy);
            else throw new ArgumentException(name);
        }

        public Deck GetDeck(string name)
        {
            if (!DeckNames.Any(n => n == name))
                throw new ArgumentException(name);
            return decks.First(d => d.Name == name);
        }
    }
}