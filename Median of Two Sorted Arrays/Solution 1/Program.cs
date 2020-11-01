using System;
using System.Linq;

namespace Solution_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var nums2 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var newArray = GetMergedArray(nums1, nums2);
            var middle = newArray.Length / 2;

            return newArray.Length % 2 == 0 ? (newArray[middle] + newArray[middle - 1]) / 2.0 : newArray[newArray.Length / 2];
        }

        public static int[] GetMergedArray(int[] nums1, int[] nums2)
        {
            var lengthOfNewArray = nums1.Length + nums2.Length;
            var newArray = new int[lengthOfNewArray];

            var p1 = 0;
            var p2 = 0;

            for (int i = 0; i < newArray.Length; i++)
            {
                if (p2 >= nums2.Length || p1 < nums1.Length && nums1[p1] < nums2[p2])
                {
                    newArray[i] = nums1[p1++];
                }
                else
                {
                    newArray[i] = nums2[p2++];
                }
            }

            return newArray;
        }
    }
}
