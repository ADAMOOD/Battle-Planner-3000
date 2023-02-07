using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using BetterConsoleTables;
using Microsoft.Win32.SafeHandles;
using resourceEditor;
using FileSave;
using Newtonsoft.Json.Converters;
using UnitEditor;

namespace Battle_Planner_3000
{
    internal class Program
    {
        public static List<Resource> Resources = new List<Resource>();

        static void Main(string[] args)
        {
            var file = new FilesJson("saveTest");
            Resources = file.loadSavedFile();
            while (true)
            {
                var option = Input("l-list resources\nc-create new resource\ne-edit list of resources\nu-create unit");
                switch (option)
                {
                    case "l":
                    {
                        PrintTable(Resources, "name", "ID", "requirements");
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
                            var resouce = FindResource(Input("Give id me name of Resource"));
                            Console.WriteLine($"What do you wanna do with {resouce.Name}?\nd-delete it\nu-update its requirements");
                            switch (Console.ReadLine())
                            {
                                case "u":
                                    {
                                        resouce.addRequirements(GettingRequirements(resouce.Name));
                                        break;
                                    }
                                case "d":
                                    {
                                        Resources.RemoveAll(p => p.IDR == resouce.IDR);
                                        break;
                                    }
                            }
                            break;
                        }
                    case "u":
                    {
                        
                        break;
                    }
                }
                file.saveToFile(Resources);
            }
        }

        private static void PrintTable(List<Resource> listOfValues, string head1,string head2, string head3)
        {
            var table = new Table(head1, head2, head3);
            table.Config = TableConfiguration.UnicodeAlt();
            foreach (var resource in listOfValues)
            {
                string requirements = string.Join("; ", resource.Requirements);
                table.AddRow(resource.Name, resource.IDR, requirements);
            }

            Console.WriteLine(table.ToString());
        }

       /* public static BattleUnit CreateNewBattleUnit()
        {
            
        }*/
        public static Resource FindResource(string id)
        {
            foreach (var resource in Resources)
            {
                if (resource.IDR.Equals(id))
                {
                    return resource;
                }
            }
            throw new InvalidOperationException("Resource not founded");
        }
        public static Resource CreateNewRusource()
        {
            Console.WriteLine("Create a military resource\n");
            Console.WriteLine("Name of resource>");
            string name = Console.ReadLine();
            return new Resource(name, GettingRequirements(name));
        }
        private static List<string> GettingRequirements(string name)
        {
            List<string> resources = new List<string>();
            string answer;
            do
            {
                var what = Input($"{name} requires>");
                string howMuch = Input($"how much of {what}>");
                string unit = Input("In What unit>");
                answer = Input("IS IT ALL? (y/n)");
                resources.Add($"{howMuch} {unit} {what}");
            } while (answer.Equals("n"));
            return resources;
        }

        public static string Input(string query)
        {
            Console.WriteLine(query);
            return Console.ReadLine();
        }
    }

}

