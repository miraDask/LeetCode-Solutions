using System;
using System.Collections.Generic;
using System.Linq;

namespace Two_Sum
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray() ;
            var target = int.Parse(Console.ReadLine());
            var result = TwoSum(numbers, target);
            Console.WriteLine(string.Join(" ", result));
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length ; i++)
            {
                var diff = target - nums[i];

                if (map.ContainsKey(diff))
                {
                    return new int[2] {map[diff], i};
                }

                map[nums[i]] = i;
            }

            throw new ArgumentException("There are no two numbers which sum is equal to target");
        }
    }
}
