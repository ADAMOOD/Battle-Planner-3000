using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Battle_Planner_3000;
using Battle_Planner_3000.interfaces;


namespace resourceEditor
{
    public class Resource: IBattleObject<string>
    {
        public List<string> listOfThings { get; set; }
        public string Name { get; set; }
        public string IDR;

        public Resource(string name,List<string> listOfThings)
        {
            this.listOfThings = listOfThings;
            Name = name;
            IDR = Helpers.randomInt(4);
        }

        public Resource()
        {
            listOfThings = new List<string>();
        }
        public void addThings(List<string> resources)
        {
            this.listOfThings.AddRange(resources);
        }
    }
}
