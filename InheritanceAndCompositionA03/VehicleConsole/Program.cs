﻿using InheritanceAndCompositionA03;

namespace VehicleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a car
            Car car1 = new Car();
            car1.AWD = true;
            car1.Make = "Ford";
            car1.Accelerate(100);
            Console.WriteLine(car1.Speed);
        }
    }
}
