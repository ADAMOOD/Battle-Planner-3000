using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Battle_Planner_3000.interfaces
{
    public interface IBattleObject<T>
    {
        List<T> listOfThings { get; set; }

        public void addThings(List<T> things);
    }
}