using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Battle_Planner_3000;
using Battle_Planner_3000.interfaces;


namespace resourceEditor
{
    public class Resource : IBattleObject<string>
    {
        public List<string> Requirements = new List<string>();
        
        public string Name { get; set; }
        public string IDR;

        public Resource(string name,List<string> requirements)
        {
            Requirements = requirements;
            Name = name;
            IDR = Helpers.randomInt(4);
        }

        public Resource()
        {

        }
        public void addRequirements(List<string> resources)
        {
            this.Requirements.AddRange(resources);
        }
    }
}
