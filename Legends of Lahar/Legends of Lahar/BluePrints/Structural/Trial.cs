using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Trial
    {
        public ChoiceData.Trigger SuccessTrigger { get; }
        public ChoiceData.Trigger FailTrigger { get; }

        public int AttributeID;

        public Trial(ChoiceData.Trigger success, ChoiceData.Trigger fail, int attributeID)
        {
            SuccessTrigger = success;
            FailTrigger = fail;
            AttributeID = attributeID;
        }
    }
}
