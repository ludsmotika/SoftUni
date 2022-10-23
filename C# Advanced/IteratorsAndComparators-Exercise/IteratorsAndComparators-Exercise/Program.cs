using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators_Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> input=Console.ReadLine().Split(' ').ToList();
            ListyIterator<string> iter = new ListyIterator<string>(input.Skip(1).ToList());
            string cmd = Console.ReadLine();
            try
            {
                while (cmd != "END")
                {
                    if (cmd == "Move")
                    {
                        Console.WriteLine(iter.Move());
                    }
                    else if (cmd == "HasNext")
                    {
                        Console.WriteLine(iter.HasNext());
                    }
                    else if (cmd == "Print")
                    {
                        iter.Print();
                    }
                    else if (cmd=="PrintAll") 
                    {
                        foreach (var item in iter)
                        {
                            Console.Write(item+" ");
                        }
                        Console.WriteLine();
                    }
                    cmd = Console.ReadLine();
                }
                
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            
        }
    }
}
