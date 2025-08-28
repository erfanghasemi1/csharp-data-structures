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

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Forr Loop\n");
            _array.PrintInReversed();
            Console.WriteLine();

            Console.WriteLine(new string('-' , 60));
            Console.WriteLine("Copy numbers into new array\n");
            _array.CopyTo();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.Write("Sum : ");
            _array.Aggregate();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("AggregateBy:");
            _array.AggregateBy();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("All:");
            _array.All();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Any:");
            _array.Any();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Append:");
            _array.Append();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("AsMemory:");
            _array.AsMemory();
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

        public void PrintInReversed()
        {
            // use numbers.forr
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers.ElementAt(i) + " ");
            }
        }

        public void CopyTo()
        {
            int[] NewNumbers = new int[numbers.Length + 3];
            numbers.CopyTo(NewNumbers, 3);

            foreach (var item in NewNumbers)
            {
                Console.Write(item + " ");
            }
        }

        public void Aggregate()
        {
            int sum = numbers.Aggregate(0,(acc , item) => acc + item);
            Console.WriteLine(sum);
        }

        public void AggregateBy()
        {
            IEnumerable<KeyValuePair<int,int>>? result = numbers.AggregateBy(
                keySelector: x=> Math.Abs(x) % 2 ,
                seedSelector: g => 0,
                func: (acc, item) => acc + item
            );

            foreach (KeyValuePair<int,int> item in result)
                Console.WriteLine($"{item.Key} : {item.Value}");
        }

        public void All()
        {
            bool CheckPositive = numbers.All(x => x > 0);

            Console.WriteLine($"all numbers are positive : {CheckPositive}");
        }

        public void Any()
        {
            bool CheckNegitive = numbers.Any(x => x < 0);

            Console.WriteLine($"There is Negitive number : {CheckNegitive}");
        }

        public void Append()
        {
            IEnumerable<int> NewArray = numbers.Append(85);

            foreach (int item in NewArray)
                Console.Write(item + " ");
        }

        public void AsMemory()
        {
            Memory<int> slice = numbers.AsMemory(1,2);

            slice.Span[0] = -1;
        }
    }
}
