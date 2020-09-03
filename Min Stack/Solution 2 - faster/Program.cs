using System;
using System.Collections.Generic;

namespace Solution_2___faster
{

    public class MinStack
    {
        private Stack<int> storage = new Stack<int>();
        private Stack<int> minValues = new Stack<int>();

        public void Push(int x)
        {
            this.storage.Push(x);
            if (minValues.Count == 0 || x <= minValues.Peek())
            {
                minValues.Push(x);
            }
        }

        public void Pop()
        {
            var last =  this.storage.Pop();
            if (last == minValues.Peek())
            {
                minValues.Pop();
            }
        }

        public int Top()
        {
            return this.storage.Peek();
        }

        public int GetMin()
        {
            return this.minValues.Peek();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var comands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var minStack = new MinStack();

            for (int i = 0; i < comands.Length; i++)
            {
                switch (comands[i])
                {
                    case "top":
                        Console.WriteLine(minStack.Top());
                        break;
                    case "pop":
                        minStack.Pop();
                        break;
                    case "getMin":
                        Console.WriteLine(minStack.GetMin());
                        break;
                    default:
                        var value = int.Parse(comands[i].Split(" ")[1]);
                        minStack.Push(value);
                        break;
                }
            }
        }
    }
}
