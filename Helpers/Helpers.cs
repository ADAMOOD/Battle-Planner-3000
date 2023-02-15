using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Battle_Planner_3000.interfaces;

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
        public void DeleteBattleObject<T>(IBattleObject<T> BattleObject,List<T> BattleList)
        {
           // BattleList.Remove(X => X == BattleObject);
        }

    }
}