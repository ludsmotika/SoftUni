namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string outputPath = Console.ReadLine();
            string inputPath = Console.ReadLine();
            CopyAllFiles(inputPath, outputPath);
        }
        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            Directory.Delete(outputPath, true);
            string[] filesInDir = Directory.GetFiles(inputPath);
            foreach (string file in filesInDir) 
            {
                Directory.Move(file, outputPath);
            }
        }
    }

    
}

