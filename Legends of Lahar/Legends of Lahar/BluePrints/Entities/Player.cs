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
        private PlayerAttributes Att;
        private int _gold;
        private int _experiencePoints;
        public Area CurrentArea { get; set; }
        private List<int> _currentQuests;
        private List<int> _completedQuests;
        private List<int> _eventsTouched; //markers for special options in events/quests

        public Player(string name, int lvl, int health, int mana, int pdamage, int mdamage, Resist res, int dodge, Skill[] skills, PlayerAttributes att,
            List<int> currentQuests, List<int> completedQuests, List<int> eventsTouched, int gold, int exp, string pic) 
            : base(name, lvl, health, mana, pdamage, mdamage, res, dodge, skills, pic)
        {
            _experiencePoints = exp;
            _gold = gold;
            Att = att;
            _currentQuests = currentQuests;
            _completedQuests = completedQuests;
            _eventsTouched = eventsTouched;
        }

        public void AddGold(int amount)
        {
            _gold = _gold + amount;
        }

        public bool RemoveGold(int amount)  //returns if it was possible to remove gold
        {
            int newGold = _gold - amount;

            if (newGold < 0)
                return false;
            else
                _gold = _gold - amount;

            return true;
        }

        public int GetGold()
        {
            return _gold;
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
        
        public int GetAttribute(int attId)
        {
            return Att.GetAttribute(attId);
        }

        public void AddAttributePoint(int attId, int points)
        {
            Att.AddAttributePoint(attId, points);
        }
    }
}
