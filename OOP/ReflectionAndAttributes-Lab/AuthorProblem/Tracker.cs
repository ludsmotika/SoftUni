using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
        Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods((BindingFlags)60);
            foreach (MethodInfo method in methods) 
            {
                foreach (var item in method.GetCustomAttributes())
                {
                    Console.WriteLine($"{method.Name} is written by {(item as AuthorAttribute).Name}");
                }
            }
        }
    }
}
