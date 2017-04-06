using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Skill
    {
        public int ID { get; }
        public string Name { get; }
        public int DmgType { get; }
        public int ManaCost { get; }
        public int WpnType { get; }

        public Skill( int id, string name, int dmgType, int manaCost, int wpnType)
        {
            ID = id;
            Name = name;
            DmgType = dmgType;
            ManaCost = manaCost;
            WpnType = wpnType;
        }
    }
}
