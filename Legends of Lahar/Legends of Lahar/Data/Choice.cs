using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Choice
    {
        public ChoiceData.Type Type { get; }
        public ChoiceData.Trigger Trigger { get; }
        public int NextStageID { get; }
        public Trial ChoiceTrial { get; }

        public Choice(ChoiceData.Type type, ChoiceData.Trigger trigger, int nextStageID)
        {
            Type = type;
            Trigger = trigger;
            NextStageID = nextStageID;
        }

        public Choice(ChoiceData.Type type, ChoiceData.Trigger trigger, int nextStageID, Trial trial)
        {
            Type = type;
            Trigger = trigger;
            NextStageID = nextStageID;
            ChoiceTrial = trial;
        }
    }
}
