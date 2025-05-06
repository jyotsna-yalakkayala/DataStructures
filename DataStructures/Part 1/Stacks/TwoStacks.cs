namespace DataStructures.Part_1.Stacks
{
    public class TwoStacks
    {
        //[10,20, 30, 40, 50]

        private int[] items;
        private int frontPointer;
        private int backPointer;

        public TwoStacks(int capacity)
        {
            items = new int[capacity];
            frontPointer = 0;
            backPointer = items.Length;
        }

        public void Push1(int item) {
            if (isFull())
                throw new InvalidOperationException();

            items[frontPointer++] = item;
        }

        public void Push2(int item) { 
            if(isFull())
                throw new InvalidOperationException();

            items[--backPointer] = item;
        }

        public int Pop1() {
            if (isEmpty())
                throw new InvalidOperationException();

            return items[--frontPointer];
        }

        public int Pop2() { 
            if(isEmpty())
                throw new InvalidOperationException();

            return items[backPointer++];
        }

        public bool isFull() {
            return frontPointer == backPointer;
        }

        public bool isEmpty() { 
            return frontPointer == 0 && backPointer == items.Length;
        }
    }
}
