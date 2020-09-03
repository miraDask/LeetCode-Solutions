using System;

namespace Solution_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            Console.WriteLine(Reverse(input));
        }

        public static int Reverse(int x)
        {
            var inputToCharArr = x.ToString().ToCharArray();
            bool isNegative = inputToCharArr[0] == '-';

            Array.Reverse(inputToCharArr);
            int result = 0;

            try
            {
                var reveresedCharArrToString = string.Join("", inputToCharArr);
                if (isNegative)
                {
                    reveresedCharArrToString = '-' + reveresedCharArrToString.Remove(inputToCharArr.Length - 1);
                }
                result = int.Parse(reveresedCharArrToString);
            }
            catch
            {
                return result;
            }

            return result;
        }
    }
}
