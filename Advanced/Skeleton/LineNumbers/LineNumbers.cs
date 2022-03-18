namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reading= new StreamReader(inputFilePath))
            {

                using (StreamWriter writing= new StreamWriter(outputFilePath))
                {
                    string line = reading.ReadLine();
                    int counter = 1;
                    while (line!=null)
                    {
                        writing.WriteLine($"Line {counter}: {line}");
                        counter++;
                        line = reading.ReadLine();
                    }
                }
            }
        }
    }
}
