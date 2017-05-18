using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Legends_Of_Lahar
{
    [Serializable]
    public class Item
    {
        public string Name { get; }
        public string Type { get; }
        public Damage Dmg { get; }
        public int BonusHealth { get; }
        public int BonusMana { get; }
        public int BonusPhysicalDamage { get; }
        public int BonusMagicalDamage { get; }
        public Resist BonusResist { get; }
        public int BonusDodge { get; }
        public int CurrentDurability { get; }
        public int MaxDurability { get; }
        public string Image { get; }
        public string Lore { get; }

        public Item(string name, string type, Damage dmg, int bonusHealth, int bonusMana, int bonusPhysicalDamage, int bonusMagicalDamage, Resist bonusResist,
            int bonusDodge, int cDurabiliy, int mDurability, Effect script, string image, string lore )
        {
            Name = name;
            Type = type;
            Dmg = dmg;
            BonusHealth = bonusHealth;
            BonusMana = bonusMana;
            BonusPhysicalDamage = bonusPhysicalDamage;
            BonusMagicalDamage = bonusMagicalDamage;
            BonusResist = bonusResist;
            BonusDodge = bonusDodge;
            CurrentDurability = cDurabiliy;
            MaxDurability = mDurability;
            Image = image;
            Lore = lore;
        }
    }
}
