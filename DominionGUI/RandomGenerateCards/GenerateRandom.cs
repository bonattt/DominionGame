using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGenerateCards
{
    class GenerateRandom
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is RandomGenerateCards");
        }
        public static List<int> GenerateRandomList(int count)
        {
            List<int> theList =  new List<int>();
	        theList.Add(2);
	        theList.Add(2);
            return theList;
        }
    }
}
