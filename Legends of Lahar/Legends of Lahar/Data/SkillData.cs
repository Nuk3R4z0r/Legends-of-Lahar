using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    class SkillData
    {
        //Damage element
        public const int TYPE_PHYSICAL = 0;
        public const int TYPE_COLD = 1;
        public const int TYPE_FIRE = 2;
        public const int TYPE_VOID = 3;

        //Weapon required for use
        public const int WEAPON_ALL = 0;
        public const int WEAPON_STAFF = 1;
        public const int WEAPON_MELEE = 2;
        public const int WEAPON_RANGED = 3;

        //   1     2       3          4           5           6               7                 8                       
        // Name, Type, ManaCost, WeaponType
        public static List<Skill> SkillList;

        public static void GenerateSkillList()
        {
            SkillList = new List<Skill>();
            SkillList.Add(new Skill("Last Resort", TYPE_PHYSICAL, 0, WEAPON_ALL ));
            SkillList.Add(new Skill("Heavy Strike", TYPE_PHYSICAL, 10, WEAPON_MELEE ));
            SkillList.Add(new Skill("Firebolt", TYPE_FIRE, 5, WEAPON_STAFF ));
            SkillList.Add(new Skill("Curse Of Freezing", TYPE_COLD, 100, WEAPON_STAFF ));
            SkillList.Add(new Skill("Poison", TYPE_COLD, 10, WEAPON_MELEE));
            SkillList.Add(new Skill("Bite", TYPE_PHYSICAL, 20, WEAPON_ALL));
        }

        public static void UseSkill(int skillId, Entity origin, Entity target)
        {
            int sendBack = 0;

            origin.DamageMana(SkillList[skillId].ManaCost, SkillList[skillId].Name); // Refactor me pls
            switch(skillId)
            {
                case 0:
                    sendBack = LastResort(origin);
                    break;
                case 1:
                    sendBack = HeavyStrike(origin);
                    break;
                case 2:
                    sendBack = Firebolt(origin);
                    break;
                case 3:
                    sendBack = CurseOfFreezing(origin, target);
                    break;
                case 4:
                    sendBack = Poison(origin, target);
                    break;
                case 5:
                    sendBack = Bite(origin);
                    break;
            }

            if (sendBack != 0)
                GameManager._GM.PushToForm(origin.GetName() + " deals " + target.DamageToHealth(new Damage(SkillList[skillId].DmgType, sendBack, 0)) + " damage!");
            
        }

        public static bool CheckEquipment(int type, Entity origin)
        {
            return false;
        }

        public static int LastResort(Entity origin)
        {
            //Get mana to heal health like now or mana = maxhealth for fun?
            origin.DamageMana(origin.GetMana(), SkillList[0].ToString());
            origin.HealHealth(origin.GetMaxHealth(), SkillList[0].ToString());

            //kill next turn if mana = maxhealth for balance
            return 0;
        }
        
        public static int HeavyStrike(Entity origin)
        {
            if (CheckEquipment(WEAPON_MELEE, origin))
                return origin.GetpBonus() + (int)(Math.Pow(0.35, ((double)origin.GetLevel()) * origin.GetpBonus()));
            else
                return 0;
        }

        public static int Firebolt(Entity origin)
        {
            if (CheckEquipment(WEAPON_MELEE, origin))
                return (30 * (int)(Math.Pow(0.35, ((double)origin.GetLevel())))) + origin.GetmBonus();
            else
                return 0;
        }

        public static int CurseOfFreezing(Entity origin, Entity target)
        {
            if (CheckEquipment(WEAPON_MELEE, origin))
            {
                target.AddEffect(EffectData._scriptList.ElementAt(EffectData.SCRIPT_POISON));
                return (30 * (int)(Math.Pow(0.35, ((double)origin.GetLevel())))) + origin.GetmBonus();
            }
            else
                return 0;
        }

        public static int Poison(Entity origin, Entity target)
        {
            target.AddEffect(EffectData._scriptList.ElementAt(EffectData.SCRIPT_POISON));
            return 2 * (origin.GetpBonus() / 2);
        }

        public static int Bite(Entity origin)
        {
            return origin.GetpBonus() * 2;
        }
    }
}
