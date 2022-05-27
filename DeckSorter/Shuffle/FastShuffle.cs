namespace DeckSorter.Shuffle
{
    public class FastShuffle : IShuffle
    {
        private Random rnd = new Random();
        public void Shuffle(Array arr)
        {
            if (arr.Length <= 1)
                return;
            if(arr == null)
                throw new NullReferenceException(nameof(arr));
            for (var i = arr.Length - 1; i > 0; i--)
            {
                var j = rnd.Next(0, i + 1);
                var temp = arr.GetValue(i);
                arr.SetValue(arr.GetValue(j), i);
                arr.SetValue(temp, j);
            }
        }
    }
}
