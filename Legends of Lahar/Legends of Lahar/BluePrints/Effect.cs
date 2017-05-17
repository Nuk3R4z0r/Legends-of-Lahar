using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Effect
    {
        public int ID { get; }
        public string Name { get; }
        public int ProcType { get; }
        public int Ticks { get; set; }
        public string Description { get; }
        public string Picture { get; }

        public Effect(int id, string name, int procType, int ticks, int mod, string desc, string pic)
        {
            ID = id;
            Name = name;
            ProcType = procType;
            Ticks = ticks;
            Description = desc;
            Picture = pic;
        }

        public Effect(Effect e)
        {
            ID = e.ID;
            Name = e.Name;
            ProcType = e.ProcType;
            Ticks = e.Ticks;
            Description = e.Description;
            Picture = e.Picture;
        }
    }
}
