using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    class Event
    {
        public string EventName { get; }
        public int AreaID { get; }
        private List<Stage> Stages;

        public Event(string eventName, int areaID)
        {
            EventName = eventName;
            AreaID = areaID;
        }

        public void AddStage(Stage s)
        {
            Stages.Add(s);
        }
    }
}
