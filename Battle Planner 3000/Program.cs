﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;

namespace Battle_Planner_3000
{
    internal class Program
    {
        public static List<Resource> Resources = new List<Resource>();

        static void Main(string[] args)
        {
            Console.WriteLine("Create a military resource\n");
            string input = Console.ReadLine();


        }

        public static Resource CreateNewRusource()
        {
            Console.WriteLine("Create a military resource\n");
            Console.WriteLine("Name of resource>");
            string name = Console.ReadLine();
            string requirements="";
            bool end = false;
            do
            {
                Console.WriteLine($"{name} requires>");
                string what = Console.ReadLine();
                Console.WriteLine($"how much of {what}>");
                string howMuch = Console.ReadLine();
                Console.Write("In What unit>");
                string unit = Console.ReadLine();
                Console.Write("IS IT ALL? (y/n)");
                string answer = Console.ReadLine();
                if (answer.Equals("y"))
                {
                    end = true;
                }
                requirements += $"{howMuch} {unit} {what},";

            } while (!end);
            return new Resource(name, requirements);
        }
    }
}
