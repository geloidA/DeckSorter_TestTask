namespace DeckSorter.Shuffle
{
    public class ManualShuffle : IShuffle
    {
        private int ShuffleCount;
        private Random rnd = new Random();

        public ManualShuffle(int shuffleCount)
        {
            ShuffleCount = shuffleCount;
        }

        public void Shuffle(Array arr)
        {
            if (arr.Length <= 1)
                return;
            if (arr == null)
                throw new NullReferenceException(nameof(arr));
            for (var i = 0; i < ShuffleCount; i++)
            {
                var separateIndex = GetRamdomizeMiddleIndex(arr.Length);
                SwapHalfs(arr, separateIndex);
            }
        }

        private int GetRamdomizeMiddleIndex(int count)
        {
            // if count == 2 then "count / 2 + rnd.Next(-1, 2)" can return an index that is out of range
            return count == 2 ? rnd.Next(0, 2) : count / 2 + rnd.Next(-1, 2);
        }

        private void SwapHalfs(Array arr, int separateIndex)
        {
            var firstPart = arr.CreateCopy(0, separateIndex + 1);
            var secondPart = arr.CreateCopy(separateIndex + 1, arr.Length - 1 - separateIndex);

            firstPart.CopyTo(arr, arr.Length - 1 - separateIndex);
            secondPart.CopyTo(arr, 0);
        }
    }
}
