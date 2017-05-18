using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Legends_Of_Lahar
{
    //Nedarver fra Entity
    [Serializable]
    public class Player : Entity
    {
        private int _gold;
        private int _experiencePoints;
        
        public Player(string name, int lvl, int health, int mana, int pdamage, int mdamage, Resist res, int dodge, Skill[] skills, int gold, int exp, string pic) 
            : base(name, lvl, health, mana, pdamage, mdamage, res, dodge, skills, pic)
        {
            _experiencePoints = exp;
            _gold = gold;
        }

        //For leveling the player
        public int AddExperiencePoints(int amount)
        {
            _experiencePoints = _experiencePoints + amount;
            //
            if (10 * Math.Pow(1.5, base.GetLevel()) < _experiencePoints)
            {
                AddLevel();
                return 1;
            }

            return 0;
        }
        
    }
}
