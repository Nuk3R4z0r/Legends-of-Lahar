using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    class EventData
    {
        public enum Consistance { Random, Static, Single }
        private static List<Event> _events;

        public static void GenerateEvents()
        {
            _events = new List<Event>();
            Event e;
            Stage s;
            Choice c;

            ///////////////// Area.Crater events /////////////////
                            ////Tomb of Ves'Jun////
            e = new Event("Tomb of Ves'Jun", Area.AREA_CRATER, Consistance.Static);

            //Stage 0, entrance
            s = new Stage(0, "", "You find a crumbled entrance to something that looks like a tomb. Do you enter?");
            c = new Choice(ChoiceData.Type.Enter, ChoiceData.Trigger.Step, 10);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Leave, ChoiceData.Trigger.Quit, 0);
            s.AddChoice(c);
            e.AddStage(s);

            //Stage 10, crossroad
            s = new Stage(10, "", "As you manage to get into the tomb, you notice images on the walls depicting the old god of the Deserts, Ves'Jun.\r\n" +
                "Images that truly shows how harsh and feared the god is. As you go further into the tomb, the corridor splits up into a crossroad, which way do you go?");
            c = new Choice(ChoiceData.Type.Left, ChoiceData.Trigger.Step, 20);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Forward, ChoiceData.Trigger.Trial, 11, 0);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Right, ChoiceData.Trigger.Step, 30);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Leave, ChoiceData.Trigger.Quit, 0);
            s.AddChoice(c);

            //Stage 11, crossroad revisit
            s = new Stage(11, "", "As you manage to get into the tomb, you notice images on the walls depicting the old god of the Deserts, Ves'Jun.\r\n" +
                "Images that truly shows how harsh and feared the god is. As you go further into the tomb, the corridor splits up into a crossroad, which way do you go?");
            c = new Choice(ChoiceData.Type.Left, ChoiceData.Trigger.Step, 20);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Forward, ChoiceData.Trigger.Trial, 40, 0);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Right, ChoiceData.Trigger.Step, 30);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Leave, ChoiceData.Trigger.Quit, 0);
            s.AddChoice(c);
            
            //Stage 30, Right corridor
            s = new Stage(30, "", "You walk down the corridor to the right.\r\n" +
                "Its walls tells stories of the great Lahar, a gigantic volcanic mudstream with unknown origin that erased a once peaceful world.\r\n" + 
                "Some purple transparent wall blocks your way forward, pulsating with energy it seems like a seal. Do you want to try to break the seal?");
            c = new Choice(ChoiceData.Type.Forward, ChoiceData.Trigger.Trial, 31, 1);
            s.AddChoice(c);
            c = new Choice(ChoiceData.Type.Leave, ChoiceData.Trigger.Quit, 11);
            s.AddChoice(c);

            _events.Add(e);
        }
    }
}
