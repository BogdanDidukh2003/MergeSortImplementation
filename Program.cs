using System;
using System.Diagnostics;
using System.Linq;

namespace MergeSortRealization
{
    public class Program
    {
        private enum SortOrder
        {
            asc,
            desc 
        }

        private const char Separator = ',';
        
        private static SortOrder _sortOrder;
        private static int[] _arrayToSort;
        private static bool  _isValidFirstArg;
        private static Stopwatch _stopwatch;
        private static double _time;
        private static int _comparisonsCounter = 0;
        private static string _output = String.Empty;
        private static int[] _outputArray;

        public static void Main(string[] args)
        {
            _stopwatch = new Stopwatch();

            _isValidFirstArg = Enum.TryParse(args[0], out _sortOrder);
            _arrayToSort = args[1].Split(Separator).Select(int.Parse).ToArray();

            if (!_isValidFirstArg)
            {
                Console.WriteLine("INVALID COMMAND");
                throw new ArgumentException();
            }

            _stopwatch.Start();

            
            _outputArray = MergeSort(_arrayToSort);
            
            _stopwatch.Stop();

            _time = _stopwatch.Elapsed.TotalMilliseconds;
            
            ConsoleOutput();
        }

        private static void ConsoleOutput()
        {
            Console.WriteLine("MergeSort:");
            Console.WriteLine(_time + "ms");
            Console.WriteLine("Comparisons:" + _comparisonsCounter);
            foreach (var item in MergeSort(_outputArray))
            {
                _output += item;
                _output += Separator;
            }
            _output = _output.TrimEnd(Separator);
            
            Console.WriteLine(_output);
        }
        
        public static int[] MergeSort(int[] inputArray)
        {
            if (inputArray.Length <= 1)
            {
                return inputArray;
            }

            int[] result = new int[inputArray.Length];  

            int middleIndex = inputArray.Length / 2;  
            int[] leftArray = new int[middleIndex];
            int[] rightArray = new int[inputArray.Length - middleIndex]; 
            
            Array.Copy(inputArray, 0, leftArray, 0, middleIndex);
            Array.Copy(inputArray, middleIndex, rightArray, 0, inputArray.Length - middleIndex);
            
            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);
            result = Merge(leftArray, rightArray);  
            return result;
        }
  
        public static int[] Merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;  
            
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)  
                {  
                    if (_sortOrder == SortOrder.asc)
                    {
                        if (left[indexLeft] <= right[indexRight])
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }

                    if (_sortOrder == SortOrder.desc)
                    {
                        if (left[indexLeft] >= right[indexRight])
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }

                    _comparisonsCounter++;
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }  
            }
            return result;
        }
    }
}