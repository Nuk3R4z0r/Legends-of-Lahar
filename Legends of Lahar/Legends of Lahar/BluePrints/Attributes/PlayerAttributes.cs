using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    [Serializable]
    class PlayerAttributes
    {
        public const int STRENGTH_ID = 0; //Deserts area 0
        public const int DEXTERITY_ID = 1; //Deserts area 1
        public const int SPEED_ID = 0; //Deserts area 0
        public const int INTELLIGENCE_ID = 1; //Deserts area 1

        List<int> Attributes;

        public PlayerAttributes(int strength, int dexterity, int speed, int intelligence)
        {
            Attributes = new List<int>();
            Attributes.Add(strength);
            Attributes.Add(dexterity);
            Attributes.Add(speed);
            Attributes.Add(intelligence);
        }
    }
}
