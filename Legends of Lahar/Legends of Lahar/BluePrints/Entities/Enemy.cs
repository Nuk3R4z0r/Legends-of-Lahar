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
    public class Enemy : Entity
    {
        private int _experienceReward;
        private int _goldReward;
        private Item[] _lootReward; //STUB, for loot when the player has killed the enemy
        private int _areaId;
        
        public Enemy(string name, int lvl, int health, int mana, int pdamage, int mdamage, Resist res, int dodge, Skill[] skills, Item[] iReward, int gReward, int eReward, int areaId, string pic) 
            : base(name, lvl, health, mana, pdamage, mdamage, res, dodge, skills, pic)
        {
            _experienceReward = eReward;
            _goldReward = gReward;
            _lootReward = iReward;
            _areaId = areaId;
        }

        public Enemy(Enemy blueprint) 
            : base(blueprint)
        {
            _experienceReward = blueprint.GetExpReward();
            _goldReward = blueprint.GetExpReward();
            _lootReward = blueprint.GetItemRewards();
        }

        public int GetExpReward()
        {
            return _experienceReward;
        }

        public int GetGoldReward()
        {
            return _goldReward;
        }

        public Item[] GetItemRewards()
        {
            return _lootReward;
        }

        public int GetAreaId()
        {
            return _areaId;
        }
    }
}
