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
        public static List<BattleUnit> BattleUnits = new List<BattleUnit>();
        static void Main(string[] args)
        {
            var resourcesfile = new FilesJson("saveTest");
            var unitFile = new FilesJson("savedUnits");
            Resources = resourcesfile.loadSavedFile<Resource>();
            BattleUnits = unitFile.loadSavedFile<BattleUnit>();
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
                            BattleUnits.Add(CreateNewBattleUnit());
                            break;
                        }
                    case "lu":
                    {
                      // PrintTable(BattleUnits,"1","2","3");
                        break;
                    }
                }
                resourcesfile.saveToFile(Resources);
                unitFile.saveToFile(BattleUnits);
            }
        }

        private static void PrintTable(List<Resource> listOfValues, string head1, string head2, string head3)
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
        private static void PrintTable<T>(List<BattleUnit> listOfValues, string head1, string head2, string head3)
        {
            var table = new Table(head1, head2, head3);
            table.Config = TableConfiguration.UnicodeAlt();
            foreach (var resource in listOfValues)
            {
                string requirements = string.Join("; ", resource.ResourcesInUnit);
                table.AddRow(resource.type, resource.IDU, resource.ResourcesInUnit);
            }
            Console.WriteLine(table.ToString());
        }
        public static BattleUnit CreateNewBattleUnit()
        {
            string type = Input("Creating Battle Unit\nGive me a Unit Type");
            string id = Input("give me resource id");
            if (id.Length == 0)
            {
                return new BattleUnit(type);
            }
            var resource = FindResource(id);
            return new BattleUnit(resource, type);
        }
        private static List<string> GettingResources(string name)
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
            string name = Input("Create a military resource\nName of resource>");
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

