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
            ArrayList theList = new ArrayList();
            List<int> randomsize10list = GenerateRandom.GenerateRandomList(10, 10);
            /*for (int i = 0; i < 10; i++)
            {
                theList.Add(randomsize10list[i]);
            }*/

            theList.Add(4);
            theList.Add(5);
            theList.Add(5);
            theList.Add(15);
            theList.Add(5);
            theList.Add(4);
            theList.Add(5);
            theList.Add(11);
            theList.Add(15);
            theList.Add(29);
            Stack olddeck = new Stack(10);
            for (int i = 0; i < theList.Count; i++)
            {
                olddeck.Push(theList[i]);
            }
            Console.WriteLine(olddeck.Count);
            Stack randomdeck = GenerateRandom.SuffleDeck(theList);
            while (olddeck.Count > 0)
            {
                 Console.WriteLine("Olddeck: " + olddeck.Pop()+"        Newdeck: "  + randomdeck.Pop());
            }
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
            Stack returndeck = new Stack(inputlist.Count);
            List<int> randomindex = GenerateRandomList(inputlist.Count, inputlist.Count);
            for (int i = 0; i < inputlist.Count; i++)
            {
                returndeck.Push(inputlist[randomindex[i]]);
            }
                return returndeck;
        }
    }
}



