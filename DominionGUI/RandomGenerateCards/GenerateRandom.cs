using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGenerateCards
{
    public class GenerateRandom
    {
        static void Main(string[] args)
        {
            List<int> theList = GenerateRandomList(25,5);
            Console.WriteLine("Result: " + theList.Count);
            theList.ForEach(Console.WriteLine);
        }
        static Random random = new Random();
        public static List<int> GenerateRandomList(int maxvalue,int size)
        {
            int count = size;
            int min = 0;
            int max = maxvalue;
            if (max <= min || count < 0 ||
                    (count > max - min && max - min > 0))
            {
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                           " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
            }

            HashSet<int> candidates = new HashSet<int>();

            for (int top = max - count; top < max; top++)
            {
                if (!candidates.Add(random.Next(min, top + 1)))
                {
                    candidates.Add(top);
                }
            }

            List<int> result = candidates.ToList();

            for (int i = result.Count - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }

        public static Stack SuffleDeck(ArrayList inputlist)
        {
            Stack returndeck = new Stack();
            List<int> randomindex = GenerateRandomList(inputlist.Capacity, inputlist.Capacity);
            for (int i = 0; i < inputlist.Capacity; i++)
            {
                returndeck.Push(inputlist[randomindex[i]]);
            }
                return returndeck;
        }
    }
}



