using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.LinkedList
{
    public class LinkedList
    {
        private class Node {
            public int value { get; set; }
            public Node next { get; set; }

            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node? first;
        private Node? last;
        private int count;

        public void AddLast(int value) {
            if (count == 0) {
                first = last = new Node(value);
                return;
            }

            var node = new Node(value);
            last.next = node;
            last = node;

            count++;
        }

        public void AddFirst(int value) {
            if (first == null)
                first = last = new Node(value);
            else {
                var node = new Node(value);
                node.next = first;
                first = node;
            }
            count++;
        }

        public int IndexOf(int item) {
            var current = first;
            int index = 0;

            while (current != null) {
                if (current.value == item)
                    return index;

                current = current.next;
                index++;
            }
            return -1;
        }

        public bool Contains(int item) { 
            return IndexOf(item) >= 0;
        }

        public void RemoveFirst() { 
            if(first == null)
                throw new InvalidOperationException();

            if (first == last)
            {
                first = last = null;
            }
            else {
                var second = first.next;
                first.next = null;
                first = second;
            }
            count--;
        }

        public void RemoveLast() {
            if (first == last)
                first = last = null;
            else {
                var previousNode = getPreviousNode(last);
                previousNode.next = null;
                last = previousNode;
            }
            count--;
        }

        public void Reverse() {
            if (first == null)
                return;

            var previous = first;
            var current = first.next;

            while (current != null) { 
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            last = first;
            last.next = null;
            first = previous;
        }

        public int getKthNodeFromTheEnd(int k) {
            if(first == null)
                return -1;

            var firstPointer = first;
            var secondPointer = first;
            for (int i = 0; i < k - 1; i++) {
                secondPointer = secondPointer.next;
            }

            while (secondPointer != last) {
                firstPointer = firstPointer.next;
                secondPointer = secondPointer.next;
            }

            return firstPointer.value;
        }

        public void printMiddle() {
            if(first ==  null)
                return;

            var firstPointer = first;
            var secondPointer = first;

            while (secondPointer != last || secondPointer.next != last) {
                firstPointer = firstPointer.next;
                secondPointer = secondPointer.next.next;
            }

            if(secondPointer == last)
                Console.WriteLine("The middle node is "+ firstPointer.value);
            else
                Console.WriteLine(" The middle nodes are " + firstPointer.value + ", " + firstPointer.next.value);
        }

        public bool hasLoop() {
            var slowPointer = first;
            var fastPointer = first;

            while (fastPointer != null) {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next.next;

                if(slowPointer == fastPointer)
                    return true;
            }
            return false;
        }

        private Node getPreviousNode(Node node) {
            var current = first;

            while (current != null) { 
                if(current.next == node)
                    return current;

                current = current.next;
            }

            return null;
        }
    }
}
