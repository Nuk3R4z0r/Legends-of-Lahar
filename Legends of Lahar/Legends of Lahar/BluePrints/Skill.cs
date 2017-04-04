using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Skill
    {
        public string Name { get; }
        public int DmgType { get; }
        public int ManaCost { get; }
        public int WpnType { get; }

        public Skill( string name, int dmgType, int manaCost, int wpnType)
        {
            Name = name;
            DmgType = dmgType;
            ManaCost = manaCost;
            WpnType = wpnType;
        }
    }
}
