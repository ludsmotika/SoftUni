using System;

namespace ExceptionsAndErrorHandling_Lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n<0)
                {
                    throw new Exception();
                }
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
