using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    class Stage
    {
        public int StageID { get; }
        public string NarrationFile { get; }
        public string Text { get; }
        public List<Choice> Choices { get; }

        public Stage(int stageID, string narrationFile, string text)
        {
            Text = text;
            NarrationFile = narrationFile;
            Text = text;
        }

        public void AddChoice(Choice c)
        {
            Choices.Add(c);
        }
    }
}
