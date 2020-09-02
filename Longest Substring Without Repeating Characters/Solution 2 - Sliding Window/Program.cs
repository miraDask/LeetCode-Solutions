using System;
using System.Collections.Generic;

namespace Solution_2___Sliding_Window
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var lengthOfLongestSubstring = LengthOfLongestSubstring(input);
            Console.WriteLine(lengthOfLongestSubstring);
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var tempSet = new HashSet<char>();
            var i = 0;
            var j = 0;
            var result = 0;

            while (i < s.Length && j < s.Length)
            {
                if (tempSet.Contains(s[j]))
                {
                    tempSet.Remove(s[i]);
                    i++;
                }
                else
                {
                    tempSet.Add(s[j]);
                    result = Math.Max(result, tempSet.Count);
                    j++;
                }
            }

            return result;
        }
    }
}
