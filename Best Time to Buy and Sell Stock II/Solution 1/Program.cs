using System;
using System.Linq;

namespace Solution_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            Console.WriteLine(MaxProfit(input));
        }

        public static int MaxProfit(int[] prices)
        {
            var totalProfit = 0;

            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    totalProfit += prices[i] - prices[i - 1];
                }
            }

            return totalProfit;
        }
    }
}

//test input:
//7,1,5,3,6,4
