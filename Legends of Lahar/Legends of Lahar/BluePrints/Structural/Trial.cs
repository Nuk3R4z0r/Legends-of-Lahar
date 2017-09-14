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
        public int Requirement { get; }

        public string TrialMSG { get; }
        public string SuccessMSG { get; }
        public string FailMSG { get; }

        public ChoiceData.Trigger SuccessTrigger { get; }
        public ChoiceData.Trigger FailTrigger { get; }
        public TrialData.Check RequirementCheck { get; }

        public Trial(int trialID, string trialMSG, ChoiceData.Trigger success, string successMSG, ChoiceData.Trigger fail, string failMSG, int requirementID, TrialData.Check requirementCheck, int requirement)
        {
            TrialID = trialID;
            TrialMSG = trialMSG;
            SuccessTrigger = success;
            SuccessMSG = successMSG;
            FailTrigger = fail;
            FailMSG = failMSG;
            RequirementID = requirementID;
            RequirementCheck = requirementCheck;
            Requirement = requirement;
        }

        public ChoiceData.Trigger Run()
        {
            bool pass = false;

            if(RequirementCheck == TrialData.Check.HasQuest)
            {
                //stub for when quests are implemented
            }
            else if(RequirementCheck == TrialData.Check.HasQuestCompleted)
            {
                //stub for when quests are implemented
            }
            else if(RequirementCheck == TrialData.Check.HasSpell)
            {
                if (GameManager._GM.CurrentPlayer.GetSkills().Contains(SkillData.SkillList[RequirementID]))
                    pass = true;
            }
            else if(RequirementCheck == TrialData.Check.LessThan)
            {
                if (GameManager._GM.CurrentPlayer.GetAttribute(PlayerAttributes.SPEED_ID) <= Requirement)
                    pass = true;
            }
            else //MoreThan
            {
                if (GameManager._GM.CurrentPlayer.GetAttribute(PlayerAttributes.SPEED_ID) >= Requirement)
                    pass = true;
            }

            if (pass)
                return SuccessTrigger;
            else
                return FailTrigger;
        }
    }
}
