using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Queues
{
    public class LinkedListQueue<T>
    {
        private class Node {
            public T value { get; set; }
            public Node next { get; set; }

            public Node(T value)
            {
                this.value = value;
            }
        }

        private Node first;
        private Node last;
        private int count;

        public void Enqueue(T item) { 
            var node = new Node(item);

            if (first == null) {
                first = last = node;
                return;
            }

            last.next = node;
            last = node;
        }
    }
}
