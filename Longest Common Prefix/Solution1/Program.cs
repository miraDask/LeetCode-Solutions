using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").ToArray();
            Console.WriteLine(LongestCommonPrefix(input));
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            var result = string.Empty;
            if (strs.Length <= 1)
            {
                result = strs.Length == 1 ? strs[0] : result;
                return result;
            }

            var indexOfShortest = FindShortest(strs);
            var shortestString = strs[indexOfShortest] ;

            var rest = strs.Where((x, i) => i != indexOfShortest).ToList(); 

            for (var i = shortestString.Length; i >= 0; i--)
            {
                var current = shortestString.Substring(0, i);
                var existsInAllStrings = true;
                foreach (var str in rest)
                {
                    var x = str.Substring(0, i);
                    if (x != current)
                    {
                        existsInAllStrings = false;
                        break;
                    }
                }

                if (existsInAllStrings)
                {
                    result = current;
                    return result;
                }

            }

            return result;
        }

        public static int FindShortest(string[] strs)
        {
            var index = -1;
            var minLenght = int.MaxValue;
            for (var i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < minLenght)
                {
                    minLenght = strs[i].Length;
                    index = i;
                }
            }

            return index;
        }
    }
}
