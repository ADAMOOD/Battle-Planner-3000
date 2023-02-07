using System;
using System.Collections.Generic;
using Battle_Planner_3000;
using resourceEditor;

namespace UnitEditor
{
    public class BattleUnit
    {
        public List<Resource> ResourcesInUnit = new List<Resource>();
        public string IDU;
        public BattleUnit(Resource providedResource)
        {
            ResourcesInUnit.Add(providedResource);
            IDU = Helpers.randomInt(4);
        }
        public void addResources(List<Resource> resources)
        {
            this.ResourcesInUnit.AddRange(resources);
        }

    }
}
