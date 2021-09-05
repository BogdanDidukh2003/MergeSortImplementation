using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace MergeSortRealization
{
    public class Program
    {
        private enum SortOrder
        {
            ASC,
            DESC 
        }

        private const char Separator = ',';
        
        private static SortOrder _sortOrder;
        private static int[] _inputArray;
        private static int[] _outputArray;
        private static bool  _isValidFirstArg;
        private static Stopwatch _stopwatch;
        private static long _time;
        private static int _comparisonsCounter = 0;
        private static int _swapsCounter = 0;
        private static string _output = new string(string.Empty);
        
        public static void Main(string[] args)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            _isValidFirstArg = Enum.TryParse(args[0], out _sortOrder);
            _inputArray = args[1].Split(Separator).Select(int.Parse).ToArray();
            _outputArray = new int[_inputArray.Length];

            if (!_isValidFirstArg)
            {
                Console.WriteLine("INVALID COMMAND");
                throw new ArgumentException();
            }
            
            MergeSort();
            
            _stopwatch.Stop();

            _time = _stopwatch.ElapsedMilliseconds;
            
            ConsoleOutput();
        }

        private static void ConsoleOutput()
        {
            Console.WriteLine("MergeSort:");
            Console.WriteLine(_time + "ms");
            Console.WriteLine("Comparisons:" + _comparisonsCounter);
            Console.WriteLine("Swaps:" + _swapsCounter);
            foreach (var item in _outputArray)
            {
                _output += item;
                _output += Separator;
            }
            _output = _output.TrimEnd(Separator);
            
            Console.WriteLine(_output);
        }

        private static void MergeSort()
        {
            _outputArray = _inputArray;
        }
    }
}