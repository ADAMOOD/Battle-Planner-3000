using System;
using System.Collections.Generic;
using Battle_Planner_3000;
using resourceEditor;

namespace UnitEditor
{
    public class BattleUnit
    {
        public List<ResourceCount> ResourcesInUnit = new List<ResourceCount>();
        public string IDU;
        public string type;
        public BattleUnit() { }
        public BattleUnit(string type)
        {
            this.type = type;
            IDU = Helpers.randomInt(4);
        }
        public BattleUnit(ResourceCount providedResource,string type)
        {
            this.type = type;
            ResourcesInUnit.Add(providedResource);
            IDU = Helpers.randomInt(4);
        }
        public BattleUnit(List<ResourceCount> listOfResources, string type)
        {
            this.type = type;
            ResourcesInUnit=listOfResources;
            IDU = Helpers.randomInt(4);
        }
        public void addResources(List<ResourceCount> resources)
        {
            this.ResourcesInUnit.AddRange(resources);
        }

    }
}
