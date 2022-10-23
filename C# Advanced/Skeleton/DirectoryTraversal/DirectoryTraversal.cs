namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

           string reportContent =TraverseDirectory(path);
           Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] collection=Directory.GetFiles(inputFolderPath);
            var filesInfo = new Dictionary<string, Dictionary<string, double>>();
            foreach (var file in collection)
            {
                string fileName= Path.GetFileName(file);
                string extension= Path.GetExtension(file);
                double fileSize= File.OpenRead(file).Length/1024.0;
                if (filesInfo.ContainsKey(extension)==false)
                {
                    filesInfo.Add(extension, new Dictionary<string, double>());
                }
                filesInfo[extension].Add(fileName, fileSize);
            }
            filesInfo = filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x=>x.Key ,y=>y.Value);
            StringBuilder output= new StringBuilder();
            foreach (var item in filesInfo)
            {
               output.AppendLine(item.Key);
                var dict = filesInfo[item.Key].OrderByDescending(x => x.Value).ToDictionary(x=>x.Key,y=>y.Value);
                foreach (var file in dict)
                {
                    output.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }
            return output.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllText(path, textContent);
        }

    }
}
