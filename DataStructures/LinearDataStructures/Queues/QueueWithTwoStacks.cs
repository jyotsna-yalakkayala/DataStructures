using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Queues
{
    public class QueueWithTwoStacks
    {
        private Stack<int> stack1 = new Stack<int>();
        private Stack<int> stack2 = new Stack<int>();

        public int Dequeue() {
            if (stack1.Count == 0 && stack2.Count == 0)
                throw new Exception("Cannot dequeue an emoty queue");

            if (stack2.Count == 0) {
                while (stack1.Count > 0) {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Pop();
        }

        public void Enqueue(int item) {
            stack1.Push(item);
        }
    }
}
