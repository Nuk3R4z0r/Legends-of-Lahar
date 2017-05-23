using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class ChoiceData
    {
        public enum Type { Next, Yes, No, Take, Leave, Left, Right, Forward, Enter};

        public enum Trigger { Quit, Death, Step, Trial }

        public static List<string> ChoiceList;

        public static void GenerateChoices()
        {
            ChoiceList.Add("Next");
            ChoiceList.Add("Yes");
            ChoiceList.Add("No");
            ChoiceList.Add("Take");
            ChoiceList.Add("Leave");
            ChoiceList.Add("Left");
            ChoiceList.Add("Right");
            ChoiceList.Add("Forward");
            ChoiceList.Add("Enter");
        }
    }
}
