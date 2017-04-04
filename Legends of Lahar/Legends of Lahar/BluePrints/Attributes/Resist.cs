using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Resist
    {
        private int Physical;
        private int Fire;
        private int Cold;
        private int Void;

        public Resist(int phys, int fire, int cold, int vod)
        {
            Physical = phys;
            Fire = fire;
            Cold = cold;
            Void = vod;
        }

        public int GetResistance(int dmgType)
        {
            switch(dmgType)
            {
                case 0:
                    return Physical;
                case 1:
                    return Fire;
                case 2:
                    return Cold;
                case 3:
                    return Void;
            }
            return 0;
        }
    }
}
