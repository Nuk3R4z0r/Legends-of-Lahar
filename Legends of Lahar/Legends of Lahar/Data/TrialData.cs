﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    //Create Trials
    public static class TrialData
    {
        public static List<Trial> trials;

        static void GenerateTrials()
        {
            Trial t;
            trials = new List<Trial>();

            t = new Trial(0, "The ground starts crumbling behind you!", 
                ChoiceData.Trigger.Step, "Because of your speed, you manage to make it across, could there be more traps like this in here?", 
                ChoiceData.Trigger.Death, "You make a run for the end of the corridor but just as you are about to reach the end, your speed fails you as you feel the ground disappear beneath you and you fall to your death",
                PlayerAttributes.SPEED_ID, Trial.Check.MoreThan, 31);

            trials.Add(t);

            t = new Trial(1, "You use your intelligence trying to dispell the seal!",
                ChoiceData.Trigger.Step, "The seal starts fizzling and disappear. In that same moment feelings of guilt starts rushing through you and you walk further down the corridor...",
                ChoiceData.Trigger.Back, "The seal does not seem to be affected and you go back the way you came.",
                PlayerAttributes.INTELLIGENCE_ID, Trial.Check.MoreThan, 50);

            trials.Add(t);
        }
    }
}
