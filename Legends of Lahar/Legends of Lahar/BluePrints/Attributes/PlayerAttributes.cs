using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    [Serializable]
    public class PlayerAttributes
    {
        public const int STRENGTH_ID = 0; 
        public const int DEXTERITY_ID = 1; 
        public const int SPEED_ID = 2; 
        public const int INTELLIGENCE_ID = 3; 

        List<int> Attributes;

        public PlayerAttributes(int strength, int dexterity, int speed, int intelligence)
        {
            Attributes = new List<int>();
            Attributes.Add(strength);
            Attributes.Add(dexterity);
            Attributes.Add(speed);
            Attributes.Add(intelligence);
        }

        public int GetAttribute(int attId)
        {
            return Attributes[attId];
        }

        public void AddAttributePoint(int attId, int points)
        {
            Attributes[attId] += points;
        }
    }
}
