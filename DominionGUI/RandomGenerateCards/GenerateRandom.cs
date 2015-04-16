﻿using System;
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
            List<int> theList = GenerateRandomList();
            Console.WriteLine("Result: " + theList.Count);
            theList.ForEach(Console.WriteLine);
        }
        static Random random = new Random();
        public static List<int> GenerateRandomList()
        {
            int count = 10;
            int min = 0;
            int max = 25;
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
    }
}


