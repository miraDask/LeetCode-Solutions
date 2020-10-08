using System;

namespace Solution1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(MyAtoi(input));
        }

        public static int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            var toArr = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var first = toArr[0];
            var sub = string.Empty;

            for (var i = 0; i < first.Length; i++)
            {
                if (first[i] == '-' && i == 0)
                {
                    sub += first[i];
                    continue;
                }
                if (first[i] == '+' && i == 0)
                {
                    continue;
                }

                if (first[i] == '0' && sub.Length < 1)
                {
                    continue;
                }

                if (Char.IsDigit(first[i]))
                {
                    sub += first[i];
                }
                else
                {
                    break;
                }
            }

            if (sub.Length == 0 || sub.Length == 1 && !Char.IsDigit(sub[0]))
            {
                return 0;
            }

            int result = 0;

            try
            {
                result = int.Parse(sub);
            }
            catch
            {

                if (sub[0] == '-')
                {
                    result = int.MinValue;
                }
                else
                {
                    result = int.MaxValue;
                }
            }
            
            return result;
        }
    }
}
