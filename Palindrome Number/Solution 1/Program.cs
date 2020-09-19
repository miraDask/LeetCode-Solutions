using System;

namespace Solution_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(IsPalindrome(number));
        }

        public static bool IsPalindrome(int x)
        {
            var toCharArr = x.ToString().ToCharArray();
            var n = toCharArr.Length / 2;
            for (var i = 0; i < n; i++)
            {
                for (var j = toCharArr.Length - 1; j >= n ; j--)
                {
                    if (toCharArr[i] != toCharArr[j])
                    {
                        return false;
                    }

                    if (j == n)
                    {
                        break;
                    }

                    i++;
                }

                break;
            }
            
            return true;
        }
    }
}
