using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution_1
{
    public class MinStack
    {
        private List<int> storage;
        /** initialize your data structure here. */
        public MinStack()
        {
            this.storage = new List<int>();
        }

        public void Push(int x)
        {
            this.storage.Add(x);
        }

        public void Pop()
        {
            this.storage.RemoveAt(this.storage.Count - 1);
        }

        public int Top()
        {
            return this.storage[this.storage.Count - 1];
        }

        public int GetMin()
        {
            return this.storage.Min(x => x);
        }
    }
    
    class Program
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
// test:
//push -2, push 0, push -3, getMin, pop, top, getMin 
