using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    class EffectData
    {
        public const int TYPE_PASSIVE = 0;
        public const int TYPE_ON_HIT = 1;
        public const int TYPE_ON_RECIEVE_DMG = 2;
        public const int TYPE_DEBUFF = 3;

        public const int SCRIPT_SAMSARA = 0;
        public const int SCRIPT_BONEBREAKER = 1;
        public const int SCRIPT_BRAMBLE_THORNS = 2;
        public const int SCRIPT_SOUL_THORNS = 3;
        public const int SCRIPT_LAST_RESORT = 4;
        public const int SCRIPT_POISON = 5;

        public static List<Effect> _scriptList;

        public static void GenerateScriptList()
        {
            _scriptList = new List<Effect>();                   //0 means always
            _scriptList.Add(new Effect(0, "Samsara", TYPE_PASSIVE, 0, 0, "You feel slightly more regenerative.", "")); //square picture image needed as last parameter
            _scriptList.Add(new Effect(1, "Skullbreaker", TYPE_ON_HIT, 0, 0, "You hit slightly harder.", ""));
            _scriptList.Add(new Effect(2, "BrambleThorns", TYPE_ON_RECIEVE_DMG, 0, 0, "Anyone with a malicious intent, will be harmed when hitting you.", ""));
            _scriptList.Add(new Effect(3, "SoulThorns", TYPE_ON_RECIEVE_DMG, 0, 0, "You backfire a small amount of damage dealt to you.", ""));
            _scriptList.Add(new Effect(4, "Last Resort", TYPE_DEBUFF, 1, 0, "You feel death creeping closer by the second.", ""));
            _scriptList.Add(new Effect(5, "Poison", TYPE_DEBUFF, 10, 0, "You have been poisoned", ""));
            _scriptList.Add(new Effect(6, "Frozen", TYPE_DEBUFF, 1, 0, "You are frozen", ""));
        }

        public static int RunScript(int scriptId, Entity origin, Entity target)
        {
            int value = 0;  
            switch(scriptId)
            {
                case 0:
                    Samsara(origin);
                    break;
                case 1:
                    value = Skullbreaker(value);
                    break;
                case 2:
                    value = BrambleThorns(origin);
                    break;
                case 3:
                    value = SoulThorns(value);
                    break;
                case 4:
                    value = LastResort(origin);
                    break;
                case 5:
                    value = Poison(origin);
                    break;
            }

            return value;
        }

        private static void Samsara(Entity origin)
        {
            origin.HealHealth((int)(2 + (origin.GetMaxHealth() * 0.01)), _scriptList[0].Name);
        }

        private static int Skullbreaker(int value)
        {
            return Convert.ToInt16(value * 1.05);
        }

        private static int BrambleThorns(Entity origin)
        {
            return origin.GetLevel();
        }

        private static int SoulThorns(int value)
        {
            return (int)(value * 0.1);
        }

        public static int LastResort(Entity origin)
        {
            return origin.GetMaxHealth();
        }

        public static int Poison(Entity origin)
        {
            int dmg = origin.DamageToHealth(new Damage(Damage.TYPE_PHYSICAL, 2, 2, 0));
            GameManager._GM.PushToForm(origin.GetName() + " lost " + dmg + " health to poison");
            return dmg;
        }
    }
}
