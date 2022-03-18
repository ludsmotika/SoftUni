﻿using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double radius = double.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(width, height);
            Circle circle = new Circle(radius);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());



            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());

        }
    }
}
