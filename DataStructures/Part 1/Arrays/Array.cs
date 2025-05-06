using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Part_1.Arrays
{
    public class Array
    {
        private int[] items;
        private int count;
        private int size;

        public Array(int capacity)
        {
            items = new int[capacity];
        }

        public void print() {
            for (int i = 0; i < count; i++) {
                Console.Write(items[i]);
                if(i < count - 1)
                    Console.Write(",");
            }
        }

        public void Insert(int value) {
            if (count == items.Length) {
                var resizedArray = new int[2 * items.Length];
                for (int i = 0; i < count; i++) { 
                    resizedArray[i] = items[i];
                }
                items = resizedArray;
            }

            items[count++] = value;
            size++;
        }

        public void RemoveAt(int index) {
            if (index < 0 || index >= count)
                throw new Exception("Pass a valid index");

            for (int i = index; i < count - 1; i++) {
                items[i] = items[i + 1];
            }

            count--;
            size--;
        }

        public int IndexOf(int value) {
            if (count == 0)
                throw new InvalidOperationException();

            for (int i = 0; i < count; i++) { 
                if (items[i] == value)
                    return i;
            }

            return -1;
        }

        public bool Contains(int value) { 
            return IndexOf(value) >= 0;
        }

        public int Max() {
            var max = items[0];

            for (int i = 1; i < count; i++) {
                if (items[i] > max)
                    max = items[i];
            }

            return max;
        }

        public int[] Intersect(int[] anotherArray) {
            var newItems = new int[Math.Min(items.Length, anotherArray.Length)];
            int k = 0; 

            for (int i = 0; i < count; i++) {
                for (int j = 0; j < anotherArray.Length; j++) {
                    if (items[i] == anotherArray[j]) { 

                        bool alreadyExists = false;

                        for (int m = 0; m < k; m++) {
                            if (newItems[m] == items[i]) { 
                                alreadyExists = true;
                                break;
                            }
                        }

                        if (!alreadyExists) {
                            newItems[k++] = items[i];
                        }
                    }
                    break;
                }
            }

            return newItems.Take(k).ToArray();
        }

        public void Reverse() {
            for (int i = 0; i < count / 2; i++) { 
                var temp = items[i];
                items[i] = items[count - 1 - i];
                items[count - 1 - i] = temp;
            }
        }

        public void InsertAt(int index, int value) {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("index");

            if (items.Length == count)
            {
                int[] resizedArray = new int[2 * count];
                for (int i = 0; i < count; i++)
                {
                    resizedArray[i] = items[i];
                }
                items = resizedArray;
            }

            for (int i = count - 1; i >= index; i--){
                items[i + 1] = items[i];
            }

            items[index] = value;

            count++;
            size++;
        }


        public int MaxProfit(int[] prices) {
            //[7,1,5,3,6,4]

            int bestDayToBuyStock = prices[0];
            for (int i = 1; i < prices.Length; i++) {
                if (prices[i] < bestDayToBuyStock)
                    bestDayToBuyStock = prices[i];
            }
            
        }
    }
}
