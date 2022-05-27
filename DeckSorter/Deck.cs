namespace DeckSorter
{
    public class Deck
    {
        private IReadOnlyList<Card> cards;
        private static IEnumerable<Card> orderedCards
        {
            get
            {
                foreach (var suit in Enum.GetValues<Card.CardSuit>())
                    foreach (var value in Enum.GetValues<Card.CardValue>())
                        yield return new Card(suit, value);
            }
        }
        /* 
         * Как один из вариантов, чтобы хранить список карт, соответствующих одной колоде, можно создать отдельную таблицу,
         * где будут храниться величина и масть карты, и Id колоды, к которой она принадлежит. А также нужно иметь столбец,
         * который соответствует порядковому номеру карты в колоде.       
         */
        public IEnumerable<Card> Cards => cards;
        //Добавить свойство Id
        public string Name { get; }

        public Deck(string name) : this(name, orderedCards)
        {
            
        }

        public Deck(string name, IEnumerable<Card> cards)
        {
            Name = name;
            this.cards = new List<Card>(cards);
        }

        public void Shuffle(IShuffle shuffleStrategy)
        {
            var shuffledCards = cards.ToArray();
            shuffleStrategy.Shuffle(shuffledCards);
            cards = shuffledCards;
        }
    }
}
