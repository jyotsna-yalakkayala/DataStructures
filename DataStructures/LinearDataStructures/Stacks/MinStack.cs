namespace DataStructures.Part_1.Stacks
{
    public class MinStack
    {
        private Stack<int> minStack = new Stack<int>();
        private Stack<int> mainStack = new Stack<int>();

        public void Push(int value) {
            mainStack.Push(value);

            if(minStack.Count == 0 || minStack.Pop() > value)
                minStack.Push(value);
        }

        public int Pop() {
            if (mainStack.Count == 0)
                throw new InvalidOperationException();

            var popped = mainStack.Pop();
            if (popped == minStack.Peek())
                minStack.Pop();

            return popped;
        }

        public int Min() { 
            if(mainStack.Count == 0)
                throw new InvalidOperationException();

            return minStack.Count;
        }
    }
}
