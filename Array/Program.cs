namespace Program
{
    public class EnteryPoint
    {
        private static ArrayDataStructure _array;

        static EnteryPoint()
        {
            _array = new ArrayDataStructure();
        }

        public static void Main()
        {
            Console.WriteLine("Attributes\n");
            _array.Attributes();

            Console.WriteLine(new string('-',60));
            Console.WriteLine("For Loop\n");
            _array.PrintWithForLoop();
            Console.WriteLine();

            Console.WriteLine(new string('-',60));
            Console.WriteLine("Foreach Loop\n");
            _array.PrintWithForeachLoop();
            Console.WriteLine();
        }
    }

    public class ArrayDataStructure
    {
        private int[] numbers;

        public ArrayDataStructure()
        {
            numbers = new int[] { 10, -5, 9, 100, 59, 72, 3, 1000, 1, 1 };
        }

        /// <summary>
        /// prints the main attributes of Array
        /// </summary>
        public void Attributes()
        {
            int length = numbers.Length;
            Console.WriteLine($"Length is : {length}");

            int rank = numbers.Rank;
            Console.WriteLine($"Rank is : {rank}");

            bool IsFixedSize = numbers.IsFixedSize;
            Console.WriteLine($"Is Fixed Size : {IsFixedSize}");

            // You can use at as locker ( in Array there is no difference between Array and ICollection)
            object SyncRoot = numbers.SyncRoot;
        }

        public void PrintWithForLoop()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers.ElementAt(i) + " ");
            }
        }

        public void PrintWithForeachLoop()
        {
            foreach (int item in numbers)
            {
                Console.Write(item + " ");
            }
        }
    }
}
