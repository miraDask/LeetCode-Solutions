using System;

namespace Solution_1
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
            if (s.Length == 1)
            {
                return s.Length;
            }

            var temp = string.Empty;
            var result = 0;

            for (var i = 0; i < s.Length - 1; i++)
            {

                temp += s[i];

                for (var j = i + 1; j < s.Length; j++)
                {
                    if (j == s.Length || temp.Contains(s[j]))
                    {
                        break;
                    }

                    temp += s[j];
                }

                result = Math.Max(temp.Length, result);
                temp = string.Empty;
            }
            return result;
        }
    }
}
