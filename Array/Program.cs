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

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Avg:");
            _array.Avg();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Chunk:");
            _array.Chunk();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Concat:");
            _array.Concat();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Contains:");
            _array.Contains();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Count:");
            _array.Count();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Distinct:");
            _array.Distinct();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Element at:");
            _array.ElementAt(5);
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Except:");
            _array.Except();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Sequence equal:");
            _array.SequenceEqual();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Maximum:");
            _array.Max();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Minimum:");
            _array.Min();
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Order:");
            _array.Order();
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

        public void Avg()
        {
            double? avg = numbers.Average(x => x > 0 ? x : null);

            Console.WriteLine((int)avg!);
        }

        public void Chunk()
        {
            IEnumerable<int[]> chunk = numbers.Chunk(3);

            foreach (var item in chunk)
            {
                foreach (var item1 in item)
                    Console.Write(item1 + " ");
                Console.WriteLine();
            }
        }

        public void Concat()
        {
            int[] a = new int[] { 1, 2, 3 };

            foreach (int item in numbers.Concat(a))
            {
                Console.Write(item + " ");
            }  
        }

        public void Contains()
        {
            bool Has402 = numbers.Contains(402);

            Console.WriteLine($"Array has 402 : {Has402}");
        }

        public void Count()
        {
            int PositiveNumbers = numbers.Count(x => x > 0);

            int NegitiveNumbers = numbers.Count(x => x < 0);

            Console.WriteLine($"Count of positive numbers : {PositiveNumbers}");
            Console.WriteLine($"Count of negitive numbers : {NegitiveNumbers}");

        }

        public void Distinct()
        {
            foreach ( int item in numbers.Distinct())
                Console.Write(item + " ");
        }

        public void ElementAt(int i)
        {
            int element = numbers.ElementAt(i);
            Console.Write(element);
        }

        public void Except()
        {
            IEnumerable<int> NewNumbers = numbers.Except(new int[] {72 , -5 , 1});

            foreach (var item in NewNumbers)
            {
                Console.Write(item + " ");
            }
        }

        public void SequenceEqual()
        {
            bool IsEqual = numbers.SequenceEqual(new int[] { 1, 5, 1000 }.AsEnumerable());

            Console.WriteLine($"Is equal : {IsEqual}");
        }

        public void Max()
        {
            int TotalMax = numbers.Max();
            Console.WriteLine($"Maximum is : {TotalMax}");

            int min = numbers.Max(x => -x);
            Console.WriteLine($"Minimum is : {-min}");
        }

        public void Min()
        {
            int TotalMin = numbers.Min();
            Console.WriteLine($"Minimum : {TotalMin}");

            int max = numbers.Min(x => -x);
            Console.WriteLine($"Maximum : {-max}");
        }

        public void Order()
        {
            Console.Write("Ascending order : ");
            foreach (var item in numbers.Order())
            {
                Console.Write(item + " ");
            }
        }
    }
}
