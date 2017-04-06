using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class MonsterData
    {
        //   0     1      2       3        4              5            6       7        8         9       10        11
        // name, level, health, mana, physicalDamage, magicalDamage, resist, dodge, lootReward, gold, expreward, areaCode
        // Items position i denne liste er den samme som dens Id.
        private static List<Enemy> monsters = new List<Enemy>();
        public static void GenerateMonsters()
        {
            monsters.Add(new Enemy("Rat", 1, 15, 10, 10, 10, new Resist(10, 0, 20, 0), 50, new Skill[] { SkillData.SkillList[4], SkillData.SkillList[5] } , new Item[] { ItemData.GetItem(0) }, 0, 0, Area.AREA_CRATER, "\\Enemies\\Rat.jpg"));
        }

        //henter en liste af enemies bestemt efter hvilket område man er i, areaCode
        public static List<Enemy> GetMonsterList(int areaCode)
        {
            List<Enemy> monsterList = new List<Enemy>();

            foreach(Enemy rawr in monsters)
            {
                if(rawr.GetAreaId() == areaCode)
                {
                    monsterList.Add(rawr);
                }
            }

            return monsterList;
        }

        //henter enkelt monster hvis man ved man skal bruge et bestemt. angivet af monsterId
        public static Enemy GetMonster(int monsterId)
        {
            return monsters[monsterId];
        }
    }
}
