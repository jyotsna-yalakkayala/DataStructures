using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Queues
{
    public class StackWithTwoQueues
    {
        private Queue<int> queue1 = new Queue<int>();
        private Queue<int> queue2 = new Queue<int>();

        public int Pop() {
            if (queue1.Count == 0 && queue2.Count == 0)
                throw new Exception();

            while (queue1.Count > 1) {
                queue2.Enqueue(queue1.Dequeue());
            }

            var item = queue1.Dequeue();
            swapQueues();

            return item;
        }

        public void Push(int item) {
            queue1.Enqueue(item);
        }

        private void swapQueues() {
            var temp = queue1;
            queue1 = queue2; 
            queue2 = temp;
        }
    }
}
