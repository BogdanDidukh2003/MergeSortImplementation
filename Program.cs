using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MergeSortRealization
{
    public class Program
    {
        private enum SortOrder
        {
            ASC,
            DESC 
        }

        private static string pattern = ",";
        private static SortOrder _sortOrder;
        private static int[] _inputArray;
        private static int[] _outputArray;
        private static bool  _isValidFirstArg;

        public static void Main(string[] args)
        {
            _isValidFirstArg = Enum.TryParse(args[0], out _sortOrder);
            //string[] temp = Regex.Split(args[1], pattern);
            //int[] _inputArray = Array.ConvertAll(Regex.Split(args[1], pattern), s => int.Parse(s));
            _inputArray = args[1].Split(',').Select(int.Parse).ToArray();
            _outputArray = new int[_inputArray.Length];

            if (!_isValidFirstArg)
            {
                Console.WriteLine("INVALID COMMAND");
                throw new ArgumentException();
            }
            MergeSort();
        }

        private static void MergeSort()
        {
            Console.WriteLine("Success");
        }
    }
}