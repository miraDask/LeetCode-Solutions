using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            var output = ThreeSum(input);

            foreach (var row in output)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            var result = new List<IList<int>>();

            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (nums[i] != nums[i - 1]))
                {
                    var sum = 0 - nums[i];
                    var low = i + 1;
                    var high = nums.Length - 1;

                    while (low < high)
                    {

                        var currentSum = nums[low] + nums[high];
                        if (currentSum == sum)
                        {
                            result.Add(new List<int>() { nums[i], nums[low], nums[high] });
                            while (low < high && nums[low] == nums[low + 1])
                            {
                                low++;
                            }

                            while (low < high && nums[high] == nums[high - 1])
                            {
                                high--;
                            }

                            low++;
                            high--;

                        }
                        else if (currentSum > sum)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }

            }

            return result;
        }
    }
}
// test inputs:
//0,0,0
// -1,-1,0,1
