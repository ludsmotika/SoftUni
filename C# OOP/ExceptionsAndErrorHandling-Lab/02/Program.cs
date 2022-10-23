using System;
using System.Collections.Generic;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> validNumbers = new List<int>();
            while (true)
            {
                try
                {
                    int n = ReadNumber(1, 100);
                    validNumbers.Add(n);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
           

            while (validNumbers.Count < 10)
            {
                try
                {
                    int n = ReadNumber(validNumbers[validNumbers.Count-1], 100);
                    validNumbers.Add(n);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            
            Console.WriteLine(String.Join(", ",validNumbers));
        }
        public static int ReadNumber(int start, int end)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n > start && n < end)
                {
                    return n;
                }
                else
                {
                    throw new ArgumentException($"Your number is not in range {start} - 100!");
                }
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid Number!");
            }
        }
    }
}
