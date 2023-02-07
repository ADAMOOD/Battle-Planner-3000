using System;
using System.Collections.Generic;

namespace Battle_Planner_3000
{
    public class Helpers
    {
        public static List<string> IDS = new List<string>();
        public static string randomInt(int intLength)
        {
            var random = new Random();
            string idr = "";
            do
            {
                for (int i = 0; i < intLength; i++)
                {
                    idr += random.Next(0, 9).ToString();
                }
            } while (IDS.Contains(idr));
            IDS.Add(idr);
            return idr;
        }

    }
}