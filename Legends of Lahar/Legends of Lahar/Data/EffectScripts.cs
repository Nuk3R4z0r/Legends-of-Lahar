using System;
using System.Collections.Generic;

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
        public const int SCRIPT_FROZEN = 6;

        public static List<Effect> ScriptList;

        public static void GenerateScriptList()
        {
            ScriptList = new List<Effect>();                   //0 means always (passive)
            ScriptList.Add(new Effect(SCRIPT_SAMSARA, "Samsara", TYPE_PASSIVE, 0, 0, "You feel slightly more regenerative.", "")); //square picture image needed as last parameter
            ScriptList.Add(new Effect(SCRIPT_BONEBREAKER, "Bonebreaker", TYPE_ON_HIT, 0, 0, "You hit slightly harder.", ""));
            ScriptList.Add(new Effect(SCRIPT_BRAMBLE_THORNS, "BrambleThorns", TYPE_ON_RECIEVE_DMG, 0, 0, "Anyone with a malicious intent, will be harmed when hitting you.", ""));
            ScriptList.Add(new Effect(SCRIPT_SOUL_THORNS, "SoulThorns", TYPE_ON_RECIEVE_DMG, 0, 0, "You backfire a small amount of damage dealt to you.", ""));
            ScriptList.Add(new Effect(SCRIPT_LAST_RESORT, "Last Resort", TYPE_DEBUFF, 2, 0, "You feel death creeping closer by the second.", ""));
            ScriptList.Add(new Effect(SCRIPT_POISON, "Poison", TYPE_DEBUFF, 10, 0, "You have been poisoned", ""));
            ScriptList.Add(new Effect(SCRIPT_FROZEN, "Frozen", TYPE_DEBUFF, 1, 0, "You are frozen", ""));
        }

        public static int RunScript(int scriptId, int tick, Entity origin, Entity target)
        {
            int value = 0;  
            switch(scriptId)
            {
                case 0:
                    Samsara(origin);
                    break;
                case 1:
                    value = Bonebreaker(value);
                    break;
                case 2:
                    value = BrambleThorns(origin);
                    break;
                case 3:
                    value = SoulThorns(value);
                    break;
                case 4:
                    LastResort(tick, origin);
                    break;
                case 5:
                    Poison(origin);
                    break;
            }

            return value;
        }

        private static void Samsara(Entity origin)
        {
            origin.HealHealth((int)(2 + (origin.GetMaxHealth() * 0.01)), ScriptList[0].Name);
        }

        private static int Bonebreaker(int value)
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

        public static void LastResort(int tick, Entity origin)
        {
            if(tick == 0)
                origin.DamageToHealth(new Damage(Damage.TYPE_PHYSICAL, origin.GetMaxHealth(), origin.GetMaxHealth(), 0), "Last Resort", true, true, true, true);
        }

        public static void Poison(Entity origin)
        {
            origin.DamageToHealth(new Damage(Damage.TYPE_PHYSICAL, 2, 2, 0), "Poison", true, true, true, false); //needs to be rebalanced for scaling
        }
    }
}
