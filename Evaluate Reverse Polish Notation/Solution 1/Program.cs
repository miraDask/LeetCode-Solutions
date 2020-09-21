using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").ToArray();
            var calculationResult = EvalRPN(input);
            Console.WriteLine(calculationResult);
        }

        public static int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();

            for (var i = 0; i < tokens.Length; i++)
            {
                var current = tokens[i];
                var isNumber = int.TryParse(current, out int number);

                if (isNumber)
                {
                    stack.Push(number);
                }
                else
                {
                    var secondElement = stack.Pop();
                    var firstElement = stack.Pop();

                    var tempResult = current switch
                    {
                        "-" => firstElement - secondElement,
                        "+" => firstElement + secondElement,
                        "/" => firstElement / secondElement,
                        "*" => firstElement * secondElement,
                        _ => throw new NotImplementedException()
                    };

                    stack.Push(tempResult);
                }
            }

            return stack.Pop();
        }
    }
}

// test inputs:
//4, 13, 5, /, +
//2, 1, +, 3, *
