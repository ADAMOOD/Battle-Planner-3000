using System;
using System.Collections.Generic;
using System.Linq;

namespace resourceEditor
{
    public class Resource
    {
        public List<string> Requirements = new List<string>();
        public string Name { get; set; }
        public string IDR;

        public Resource(string name, string input)
        {
            Requirements = input.Split(',').ToList();
            Name = name;
            IDR = RandomIdr();
        }

        private static string RandomIdr()
        {
            var random = new Random();
            string idr = "";
            for (int i = 0; i < 4; i++)
            {
                idr += random.Next(0, 9).ToString();
            }

            return idr;
        }
       

    }

}
