using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Trial
    {
        public int TrialID { get; }
        public int RequirementID { get; }

        public string TrialMSG { get; }
        public string SuccessMSG { get; }
        public string FailMSG { get; }

        public ChoiceData.Trigger SuccessTrigger { get; }
        public ChoiceData.Trigger FailTrigger { get; }
        public TrialData.Check Requirement { get; }

        public Trial(int trialID, string trialMSG, ChoiceData.Trigger success, string successMSG, ChoiceData.Trigger fail, string failMSG, int requirementID, TrialData.Check requirement)
        {
            TrialID = trialID;
            TrialMSG = trialMSG;
            SuccessTrigger = success;
            SuccessMSG = successMSG;
            FailTrigger = fail;
            FailMSG = failMSG;
            RequirementID = requirementID;
            Requirement = requirement;
        }
    }
}
