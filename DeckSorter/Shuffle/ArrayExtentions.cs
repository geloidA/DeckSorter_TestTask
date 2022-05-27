using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckSorter.Shuffle
{
    public static class ArrayExtentions
    {
        public static Array CreateCopy(this Array arr, int startIndex, int length)
        {
            var arrCopy = Array.CreateInstance(typeof(object), length);
            Array.Copy(arr, startIndex, arrCopy, 0, length);
            return arrCopy;
        }
    }
}
