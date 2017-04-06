using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    class ChoiceData
    {
        public enum Type { Next, YesNo, TakeLeave, LeftRight, LeftRightForward};

        public static List<string[]> ChoiceList;

        public static void GenerateChoices()
        {
            ChoiceList.Add(new string[]{ "Next"});
            ChoiceList.Add(new string[] { "Yes", "No" });
            ChoiceList.Add(new string[] { "Take", "Leave" });
            ChoiceList.Add(new string[] { "Left", "Right" });
            ChoiceList.Add(new string[] { "Left", "Right", "Forward" });
        }
    }
}
