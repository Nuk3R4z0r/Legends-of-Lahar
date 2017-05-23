using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar.Data
{
    class EventData
    {
        private static List<Event> _events;

        public static void GenerateEvents()
        {
            _events = new List<Event>();
            Event e;
            Stage s;
            Choice c;

            ///////////////// Area.Crater events /////////////////
            //Tomb of Ves'Jun
            e = new Event("Tomb of Ves'Jun", Area.AREA_CRATER);

            s = new Stage(0, "", "You find a crumbled entrance to something that looks like a tomb. Do you enter?");
            c = new Choice(ChoiceData.Type.Enter, ChoiceData.Trigger.Step, 1);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Leave, ChoiceData.Trigger.Quit, 0);
            s.AddChoice(c);
            e.AddStage(s);

            s = new Stage(0, "", "As you manage to get into the tomb, you notice images on the walls depicting the old god of the Deserts, Ves'Jun.\r\n" +
                "Images that truly shows how harsh and feared the god is. As you go further into the tomb, the corridor splits up into a crossroad, which way do you go?");
            c = new Choice(ChoiceData.Type.Left, ChoiceData.Trigger.Step, 1);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Forward, ChoiceData.Trigger.Trial, 1, new Trial(ChoiceData.Trigger.Step, ChoiceData.Trigger.Death, PlayerAttributes.SPEED_ID));
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Right, ChoiceData.Trigger.Step, 1);
            s.AddChoice(c);

            _events.Add(e);
        }
    }
}
