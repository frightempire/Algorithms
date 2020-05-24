using System;
using Algorithms.StackQueue.Modifications;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var deque = new Deque<int>();
            deque.AddFirst(1);
            deque.AddFirst(2);
            Console.WriteLine(deque.RemoveLast());
            deque.AddLast(3);
            Console.WriteLine(deque.RemoveFirst());
            deque.AddLast(4);

            Console.WriteLine("DEQUEUE");
            foreach (var element in deque)
            {
                Console.WriteLine(element);
            }

            Console.ReadLine();
        }
    }
}