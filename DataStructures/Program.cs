using DataStructures.Part_1.Arrays;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Array

            var array = new Part_1.Arrays.Array(3);
            array.Insert(2);
            array.Insert(3);
            array.Insert(4);
            array.Insert(5);
            array.InsertAt(2, 7);
            array.RemoveAt(3);
            array.print();
            #endregion
        }
    }
}
