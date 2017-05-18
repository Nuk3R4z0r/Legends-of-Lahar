using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class ItemData
    {
        public const int TYPE_ARMOR = 0;
        public const int TYPE_HELM = 1;
        public const int TYPE_WEAPON = 2;
        public const int TYPE_OFFHAND = 3;
        public const int TYPE_BELT = 4;
        public const int TYPE_LEGS = 5;
        public const int TYPE_FEET = 6;

        public const int ITEM_RUSTED_SWORD = 0;
        public const int ITEM_SHORT_SWORD = 1;
        public const int ITEM_LONG_SWORD = 2;
        public const int ITEM_HUNGERING_COLD = 3;
        public const int ITEM_HUNGARIAN = 4;
        public const int ITEM_MALADATH = 5;
        public const int ITEM_GREAT_SWORD = 6;
        public const int ITEM_SUBRAMI = 7;
        public const int ITEM_SWORD_OF_DESTINY = 8;
        public const int ITEM_SHORT_AXE = 9;
        public const int ITEM_DOUBLE_AXE = 10;
        public const int ITEM_GALLATH = 11;

        //   1     2       3          4           5           6               7                 8                       
        // Name, Type, Damage, BonusHealth, BonusMana, BonusPhysicalDamage, BonusMagicalDamage,
        //      9           10              11               12         13    14      15         16
        // BonusResist, BonusDodge, CurrentDurability, MaxDurability, Effect, Image, Lore, DropKoefficient
        // Items position is the same is its ID.                                           Needs implementation
        private static List<Item> _items = new List<Item>();

        public static void GenerateItems()
        {
            // One Hand Swords
            // Normal
            _items.Add(new Item( "Rusted Sword", "One Handed Sword", new Damage(Damage.TYPE_PHYSICAL, 2, 4, 0), 0, 0, 0, 0, new Resist(0, 0, 0, 0), 0, 10, 10, null, "", "Old Rusted and heavily worn sword." ));
            _items.Add(new Item( "Short Sword", "One Handed Sword", new Damage(Damage.TYPE_PHYSICAL, 4, 7, 0), 0, 0, 0, 0, new Resist(0, 0, 0, 0), 0, 15, 15, null, "", "A short sword with fine quality." ));
            _items.Add(new Item( "Long Sword", "One Handed Sword", new Damage(Damage.TYPE_PHYSICAL, 7, 10, 0), 0, 0, 0, 0, new Resist(0, 0, 0, 0), 0, 18, 18, null, "", "A long sword with fine quality." ));
            
            // Rare
            _items.Add(new Item( "The Hungering Cold", "One Handed Sword", new Damage(Damage.TYPE_COLD, 30, 42, 9), 5, 0, 0, 0, new Resist(0, 0, 0, 0), 0, 60, 60, null, "", "Worn by the frost king Hugar, this sword has been born during the cold winter in the frozen caves and therefore it gives great magical resistance." ));
            _items.Add(new Item( "Hungarian, the devil’s lost tongue", "One Handed Sword", new Damage(Damage.TYPE_PHYSICAL, 24, 32, 0), 30, 0, 5, 0, new Resist(0, 0, 0, 0), 0, 50, 50, null, "", "Hungarian is the strongest devil in these lands, he lost his tongue centuries ago and yet it still holds great power!" ));
            _items.Add(new Item( "Maladath, Runed blade of the dark flight", "One handed Sword", new Damage(Damage.TYPE_PHYSICAL, 15, 22, 0), 10, 0, 5, 0, new Resist(0, 0, 0, 0), 20, 40, 40, null, "", "Maladath was the great beast tamer, when his companion died in combat he engraved this sword with the blood of the tiger." ));

            // Two Handed Swords
            // Normal
            _items.Add(new Item( "Great Sword", "Two Handed Sword", new Damage(Damage.TYPE_PHYSICAL, 12, 24, 0), 0, 0, 0, 0, new Resist(0, 0, 0, 0), 0, 0, 0, null, "", "A heavy sword crafted in the far lands." ));
            // Rare
            _items.Add(new Item( "Subrami, Sharpened divine stones", "Two Handed Sword", new Damage(Damage.TYPE_PHYSICAL, 50, 70, 0), 50, 20, 10, 10, new Resist(0, 0, 0, 0), 0, 60, 60, null, "", "The divine stones are filled with power so great that they are thhought of as a myth." ));
            _items.Add(new Item( "Sword of Destiny", "Two Handed Sword", new Damage(Damage.TYPE_PHYSICAL, 15, 30, 0), 20, 10, 5, 0, new Resist(0, 0, 0, 0), 0, 50, 50, null, "", "Those who believe in the old gods says that the destiny of the first men is carved within." ));

            // One Handed Axes
            // Normal
            _items.Add(new Item( "Short Axe", "One Handed Axe", new Damage(Damage.TYPE_PHYSICAL, 3, 9, 2), 0, 0, 0, 0, new Resist(0, 0, 0, 0), 0, 15, 15, null, "", "A short axe in fine condition." ));
            _items.Add(new Item( "Double bladed axe", "One Handed Axe", new Damage(Damage.TYPE_PHYSICAL, 5, 13, 4), 0, 0, 0, 0, new Resist(0, 0, 0, 0), 0, 18, 18, null, "", "A axe with blades on both sides." ));
            // Rare
            _items.Add(new Item( "Gallaths lost blade", "One Handed Axe", new Damage(Damage.TYPE_PHYSICAL, 1, 20, 100), 0, 0, 8, 0, new Resist(0, 0, 0, 0), 0, 20, 20, null, "", "Gallaths who is a dwarven knight." ));

            //Helmets
            //Rare
            _items.Add(new Item( "Auras Nissehue", "Hat", null, 4, 4, 4, 4, new Resist(4, 4, 4, 4), 4, 4, 4, null, "", "The magic nissehue of Aura")); //Kører en julesang imens den er på
        }

        public static Item GetItem(int itemId)
        {
            return _items[itemId];
        }

        public static List<Item> GetItemList()
        {
            return _items;
        }
    }
}
