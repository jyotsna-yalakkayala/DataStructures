using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Stacks
{
    public class Stack
    {
        #region ImplementingStack

        //[10,20,30,40,50]
        //    F         R  

        private int[] items = new int[5];
        private int count;

        public void Push(int value) {
            if (items.Length == count)
                throw new InvalidOperationException("Stack is already full");

            items[count++] = value;
        }

        public int Pop() {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty. Cannot be popped");

            return items[--count];
        }

        public int Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty. Cannot be popped");

            return items[count - 1];
        }
        #endregion

        #region Stack Problems
        private char[] leftBrackets = { '(', '{', '[', '<' };
        private char[] rightBrackets = { ')', '}', ']', '>' };
        public string reverse(string input) {
            var stack = new Stack<char>();
            var stringBuilder = new StringBuilder();

            foreach (char ch in input) {
                stack.Push(ch);
            }

            while (stack.Count > 0) {
                stringBuilder.Append(stack.Pop()).ToString();
            }
            
            return stringBuilder.ToString();
        }

        public bool isExpressionBalanced(string input) {
            var stack = new Stack<char>();

            foreach (char ch in input) {
                if (isLeftBracket(ch))
                    stack.Push(ch);
                if (isRightBracket(ch)) {
                    if (stack.Count == 0 || !isMatchingBracket(stack.Pop(), ch))
                        return false;
                }
            }

            return stack.Count == 0;
        }

        public bool isTheExpressionBalanced(string input) { 
            var stack = new Stack<char>();

            var dict = new Dictionary<char, char>() {
                { ')', '('},
                { '}', '{'},
                { ']', '['},
                { '>' , '<'}
            };

            foreach (char ch in input) { 
                if(dict.ContainsValue(ch))
                    stack.Push(ch);
                if (dict.ContainsKey(ch)) { 
                    if(stack.Count == 0 || stack.Pop() != dict[ch])
                        return false;
                }
            }

            return stack.Count == 0;
        }
        private bool isLeftBracket(char ch) { 
            return leftBrackets.Contains(ch);
        }

        private bool isRightBracket(char ch) { 
            return rightBrackets.Contains(ch); 
        }

        private bool isMatchingBracket(char left, char right) {
            return Array.IndexOf(leftBrackets, left) == Array.IndexOf(rightBrackets, right);
        }
        #endregion
    }
}
