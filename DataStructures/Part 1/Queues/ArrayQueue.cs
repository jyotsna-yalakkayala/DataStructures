using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Queues
{
    public class ArrayQueue
    {
        private int[] items = new int[10];
        private int front;
        private int rear;
        private int count;
        //[10,20,30,40,50]

        public void Enqueue(int item) {
            if (isFull())
                throw new InvalidOperationException();

            items[rear] = item;
            rear = (rear + 1) % items.Length;
            count++;
        }

        public int Dequeue()
        {
            if (isEmpty())
                throw new InvalidOperationException();

            var item = items[front];
            front = (front + 1) % items.Length;
            count--;

            return item;
        }

        public int[] toArray() { 
            var result = new int[count];
            for (int i = 0; i < count; i++) { 
                result[i] = items[i];
            }
            return result;
        }

        public int Peek() {
            if (isEmpty())
                throw new InvalidOperationException();

            return items[front];
        }

        public bool isFull() {
            return count == items.Length;
        }

        public bool isEmpty() {
            return count == 0;
        }
    }
}
