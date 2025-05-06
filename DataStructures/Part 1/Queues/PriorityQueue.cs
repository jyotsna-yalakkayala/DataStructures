using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Queues
{
    public class PriorityQueue
    {
        private int[] items;
        private int count = 0;

        public PriorityQueue(int capacity)
        {
            items = new int[capacity];
        }

        public void Enqueue(int item) {
            if (count == items.Length)
                throw new InvalidOperationException();
            int i;
            for (i = count - 1; i >= 0; i--) {
                if (item < items[i])
                    items[i + 1] = items[i];
                else
                    break;
            }

            items[i + 1] = item;
            count++;
        }

        public int Dequeue() {
            if (count == 0)
                throw new InvalidOperationException();

            return items[--count];
        }
    }
}
