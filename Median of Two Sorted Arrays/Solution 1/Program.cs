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
            var lengthOfNewArray = nums1.Length + nums2.Length;
            var newArray = new int[lengthOfNewArray];

            for (var i = 0; i < nums1.Length; i++)
            {
                newArray[i] = nums1[i];
            }

            var pointer = 0;
            for (var i = nums1.Length; i < lengthOfNewArray; i++)
            {
                newArray[i] = nums2[pointer++];
            }

            Array.Sort(newArray);
            var middle = lengthOfNewArray / 2;

            return lengthOfNewArray % 2 == 0 ? (newArray[middle] + newArray[middle - 1]) / 2.0 : newArray[lengthOfNewArray / 2];
        }
    }
}
