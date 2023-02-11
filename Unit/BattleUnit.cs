using System;
using System.Collections.Generic;
using Battle_Planner_3000;
using Battle_Planner_3000.interfaces;
using resourceEditor;

namespace UnitEditor
{
    public class BattleUnit : IBattleObject<ResourceCount>
    {
        public List<ResourceCount> listOfThings { get; set; }
        public string IDU;
        public string type;

        public BattleUnit()
        {
            listOfThings = new List<ResourceCount>();
        }
        public BattleUnit(string type)
        {
            this.type = type;
            IDU = Helpers.randomInt(4);
        }
        public BattleUnit(ResourceCount providedResource,string type)
        {
            this.type = type;
            listOfThings.Add(providedResource);
            IDU = Helpers.randomInt(4);
        }
        public BattleUnit(List<ResourceCount> listOfResources, string type)
        {
            this.type = type;
            listOfThings=listOfResources;
            IDU = Helpers.randomInt(4);
        }
        public void addResources(List<ResourceCount> resources)
        {
            this.listOfThings.AddRange(resources);
        }

    }
}
