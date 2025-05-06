using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Queues
{
    public class ReverseQueue
    {
        public Queue<int> QueueReverser(Queue<int> queue) { 
            var stack = new Stack<int>();

            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while(stack.Count > 0)
                queue.Enqueue(stack.Pop());

            return queue;
        }

        public Queue<int> QueueReverserUptoKthElements(Queue<int> queue, int k) {
            if (queue == null || k <= 0 || k > queue.Count)
                throw new InvalidOperationException();

            var stack = new Stack<int>();
            int remainingElements = queue.Count - k;

            for(int i = 0; i < k; i++)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

            for (int i = 0; i < remainingElements; i++)
                queue.Enqueue(queue.Dequeue());

            return queue;
        }
    }
}
