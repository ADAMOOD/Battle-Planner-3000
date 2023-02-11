using System;
using System.Collections.Generic;
using System.Text;
using Battle_Planner_3000;


namespace resourceEditor
{
    public class ResourceCount
    {
        public Resource Resource { get; set; }
        public int Count { get; set; }

        public ResourceCount(Resource resource, int count)
        {
            Resource = resource;
            Count = count;
        }
       
        public ResourceCount()
        {

        }
    }
}
