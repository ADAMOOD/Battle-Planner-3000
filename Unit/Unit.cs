using System;
using System.Collections.Generic;
using Battle_Planner_3000;
using resourceEditor;

namespace UnitEditor
{
    public class Unit
    {
        public List<Resource> ResourcesInUnit = new List<Resource>();
        public string Name { get; set; }
        public string IDU;

        public Unit(Resource providedResource)
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
