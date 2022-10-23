namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";
           
            using (StreamReader input = new StreamReader(inputFilePath))
            {
                string line = input.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        Console.WriteLine(ProcessLines(line));

                    }
                    line = input.ReadLine();
                    counter++;
                }
            }
        }

        public static string ProcessLines(string line)
        {
            char[] forbidden = new char[] { ',', '.', '!', '?', '-' };
            StringBuilder text = new StringBuilder();
            foreach (var item in line)
            {
                if (forbidden.Contains(item))
                {
                    text.Append('@');
                }
                else { text.Append(item); }
            }
            string output = text.ToString();
            string[] newText = output.Split(" ");
            return string.Join(" ", newText.Reverse());

        }
    }

}
