using System;
using System.IO;

namespace StreamsFilesAndDirectories_Lab
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            using (StreamReader input = new StreamReader(inputFilePath))
            {
                int counter = 0;
                string currentLine = input.ReadLine();
                using (StreamWriter output = new StreamWriter(outputFilePath))
                {
                    while (currentLine != null)
                    {
                        if (counter % 2 == 1)
                        {
                            output.WriteLine(currentLine);
                        }
                        counter++;
                        currentLine = input.ReadLine();
                    }
                }
            }
        }

    }

}
