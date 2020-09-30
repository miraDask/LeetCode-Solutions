using System;
using System.Linq;

namespace Solution2
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

            if(strs.Length <= 1)
            {
                result = strs.Length == 0 ? result : strs[0];
                return result;
            }

            var firstString = strs[0];

            for (int i = 0; i < firstString.Length; i++)
            {
                var current = firstString[i];
                var exists = true;

                for (int j = 1; j < strs.Length; j++)
                {
                    if (i > strs[j].Length - 1 || strs[j][i] != current)
                    {
                        exists = false;
                        break;
                    }
                    
                }

                if(exists)
                {
                    result += current;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
