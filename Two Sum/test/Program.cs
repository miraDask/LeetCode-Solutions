using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstring("au"));
        }
        public static int LengthOfLongestSubstring(string s)
        {
            var sToCharArr = s.ToCharArray();
            var res = string.Empty;
            var l = 0;

            if (sToCharArr.Length == 1)
            {
                return sToCharArr.Length;
            }

            for (var i = 0; i < sToCharArr.Length - 1; i++)
            {

                res += sToCharArr[i];

                for (var j = i + 1; j < sToCharArr.Length; j++)
                {


                    if (j == sToCharArr.Length || res.Contains(sToCharArr[j]))
                    {
                        break;
                    }

                    res += sToCharArr[j];
                }

                l = res.Length > l ? res.Length : l;
                res = string.Empty;
            }
            return l;
        }
    }
}
