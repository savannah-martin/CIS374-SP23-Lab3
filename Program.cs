using System;
using System.Collections.Generic;
using Lab3.SortingAlgorithms;
using System.Diagnostics;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> intList = GenerateRandomIntList(1_000, 5_000);
            //List<int> intList = GenerateReversedIntList(1_000, 5_000);
            List<int> intList = GenerateNearlySortedIntList(1_000_000, 5_000);

            double totalTime = 0.0;
            double averageTime = 0.0;


            //SelectionSort<int> selectionSort = new SelectionSort<int>();
            //Console.WriteLine("SELECTION SORT");

            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort(selectionSort, intListCopy);
            //}

            //averageTime = totalTime / 11;
            //Console.WriteLine($"average: {averageTime}");



            BubbleSort<int> bubbleSort = new BubbleSort<int>();
            Console.WriteLine("BUBBLE SORT");

            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort(bubbleSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"average: {averageTime}");



            QuickSort<int> quickSort = new QuickSort<int>();
            Console.WriteLine("QUICK SORT");
            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort(quickSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"average: {averageTime}");



            HeapSort<int> heapSort = new HeapSort<int>();
            Console.WriteLine("HEAP SORT");
            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort(heapSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"average: {averageTime}");



            CountingSort countingSort = new CountingSort();
            Console.WriteLine("COUNTING SORT");
            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort(countingSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"average: {averageTime}");



            RadixSort radixSort = new RadixSort();
            Console.WriteLine("RADIX SORT");
            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort(radixSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"average: {averageTime}");
        }

        public static double TimeSort<T>(ISortable<T> sortable, List<T> items) where T : IComparable<T>
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(ref items);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);

            return ts.TotalSeconds;

        }

        public static double TimeSort(ISortableInt sortable, List<int> items)
        {
            int[] array = items.ToArray();

            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var sorted = sortable.Sort(array);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);


            return ts.TotalSeconds;
        }


        public static List<int> GenerateRandomIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for(int i=0; i < length; i++)
            {
                list.Add(random.Next(maxValue));               
            }

            return list;
        }

        public static List<int> GenerateReversedIntList(int length, int maxValue)
        {
            List<int> templist = GenerateRandomIntList(length, maxValue);
            templist.Sort();
            templist.Reverse();

            return templist;
        }

        public static List<int> GenerateNearlySortedIntList(int length, int maxValue)
        {
            List<int> templist = GenerateRandomIntList(length, maxValue);
            templist.Sort();

            Random random = new Random();

            for (int i = 0; i == length * .025; i++)
            {
                int rand1 = random.Next(length);
                int rand2 = random.Next(length);
                Swap(templist, rand1, rand2);
            }

            return templist;

        }

        private static void Swap(List<int> list, int first, int second)
        {
                int tmp = list[first];
                list[first] = list[second];
                list[second] = tmp;
        }

        public static List<double> GenerateRandomDoubleList(int length, double maxValue)
        {
            List<double> list = new List<double>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.NextDouble()* maxValue);
            }

            return list;
        }
    }
}
