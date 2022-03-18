using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream readingBytes= new FileStream(inputFilePath,FileMode.Open))
            {
                using (FileStream outputBytes = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] input = new byte[4096];
                    int count = readingBytes.Read(input,0,input.Length);
                    while (count!=0)
                    {
                        outputBytes .Write(input,0,count);
                        count = readingBytes.Read(input, 0, input.Length);
                    }
                }
            }
        }
    }
}
