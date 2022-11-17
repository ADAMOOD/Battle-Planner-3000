using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using BetterConsoleTables;
using Microsoft.Win32.SafeHandles;
using resourceEditor;

namespace Battle_Planner_3000
{
    internal class Program
    {
        public static List<Resource> Resources = new List<Resource>();

        static void Main(string[] args)
        {
            var file = new FileSave.FileSave("saveTest");
            file.loadSavedFile();
            while (true)
            {

                Console.WriteLine("l-list resources\nc-create new resource\ne-edit list");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "l":
                        {
                            var table = new Table("name", "ID", "requirements");
                            table.Config = TableConfiguration.UnicodeAlt();
                            foreach (var resource in Resources)
                            {
                                string requirements = string.Join("; ", resource.Requirements);
                                table.AddRow(resource.Name, resource.IDR, requirements);
                            }
                            Console.WriteLine(table.ToString());
                            break;
                        }
                    case "c":
                        {
                            var resource = CreateNewRusource();
                            Resources.Add(resource);
                            break;
                        }
                    case "e":
                        {
                            Console.WriteLine("Give id me name of Resource");
                            var resouce = FindResource(Console.ReadLine());
                            if (resouce.Equals(null))
                            {
                                throw new InvalidOperationException("Resource not founded");
                            }
                            break;
                        }
                }
                saveDataToFile(file);
            }
        }

        public static void saveDataToFile(FileSave.FileSave file)
        {
            foreach (var resource in Resources)
            {
                file.saveFile(resource);
            }
        }
        public static Resource FindResource(string id)
        {
            foreach (var resource in Resources)
            {
                if (resource.IDR.Equals(id))
                {
                    return resource;
                }
            }
            return null;
        }
        public static Resource CreateNewRusource()
        {
            Console.WriteLine("Create a military resource\n");
            string requirements = "";
            Console.WriteLine("Name of resource>");
            string name = Console.ReadLine();
            string answer = "n";
            do
            {
                Console.WriteLine($"{name} requires>");
                string what = Console.ReadLine();
                Console.WriteLine($"how much of {what}>");
                string howMuch = Console.ReadLine();
                Console.Write("In What unit>");
                string unit = Console.ReadLine();
                Console.Write("IS IT ALL? (y/n)");
                answer = Console.ReadLine();
                requirements += $"{howMuch} {unit} {what},";
            } while (answer.Equals("n"));
            return new Resource(name, requirements);
        }
    }

}

