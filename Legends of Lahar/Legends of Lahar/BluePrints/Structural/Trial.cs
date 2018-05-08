using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Trial
    {
        public enum Check { MoreThan, LessThan, HasSpell, HasQuest, HasQuestCompleted }

        public int TrialID { get; }
        public int RequirementID { get; }
        public int Requirement { get; }

        public string TrialMSG { get; }
        public string SuccessMSG { get; }
        public string FailMSG { get; }

        public ChoiceData.Trigger SuccessTrigger { get; }
        public ChoiceData.Trigger FailTrigger { get; }
        public Check RequirementCheck { get; }

        public Trial(int trialID, string trialMSG, ChoiceData.Trigger success, string successMSG, ChoiceData.Trigger fail, string failMSG, int requirementID, Check requirementCheck, int requirement)
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

            if(RequirementCheck == Check.HasQuest)
            {
                //stub for when quests are implemented
            }
            else if(RequirementCheck == Check.HasQuestCompleted)
            {
                //stub for when quests are implemented
            }
            else if(RequirementCheck == Check.HasSpell)
            {
                if (GameManager.CurrentGameManager.CurrentPlayer.GetSkills().Contains(SkillData.SkillList[RequirementID]))
                    pass = true;
            }
            else if(RequirementCheck == Check.LessThan)
            {
                if (GameManager.CurrentGameManager.CurrentPlayer.GetAttribute(PlayerAttributes.SPEED_ID) <= Requirement)
                    pass = true;
            }
            else //MoreThan
            {
                if (GameManager.CurrentGameManager.CurrentPlayer.GetAttribute(PlayerAttributes.SPEED_ID) >= Requirement)
                    pass = true;
            }

            if (pass)
                return SuccessTrigger;
            else
                return FailTrigger;
        }
    }
}
