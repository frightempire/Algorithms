using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "1 2 3 - - 4 5 6 -";
            var operations = input.Split(' ');
            var queue = new LinkedListQueue<int>();
            var stack = new LinkedListStack<int>();

            foreach (var operation in operations)
            {
                if (operation == "-")
                {
                    queue.Dequeue();
                    stack.Pop();
                }
                else
                {
                    queue.Enqueue(Convert.ToInt32(operation));
                    stack.Push(Convert.ToInt32(operation));
                }
            }

            Console.WriteLine("QUEUE");
            foreach (var element in queue)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("STACK");
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            Console.ReadLine();
        }
    }
}