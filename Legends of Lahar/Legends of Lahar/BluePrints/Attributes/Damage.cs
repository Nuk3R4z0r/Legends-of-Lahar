using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Damage
    {
        public const int TYPE_PHYSICAL = 0;
        public const int TYPE_FIRE = 0;
        public const int TYPE_COLD = 0;
        public const int TYPE_VOID = 0;

        public int DamageType { get; }
        public int Minimum { get; }
        public int Maximum { get; }
        public int CriticalChance { get; }

        public Damage(int dmgType, int minDmg, int maxDmg, int critChance)
        {
            DamageType = dmgType;
            if (minDmg < 0)
            {
                minDmg = 0;
            }
            Minimum = minDmg;
            if (minDmg < 0)
            {
                minDmg = 0;
            }
            Maximum = maxDmg;
            CriticalChance = critChance;
        }

        public Damage(int dmgType, int dmg, int critChance)
        {
            DamageType = dmgType;
            if(dmg < 0)
            {
                dmg = 0;
            }
            Minimum = dmg;
            Maximum = dmg;
            CriticalChance = critChance;
        }

        public int Random()
        {
            int dmg;
            if (Minimum != Maximum)
            {
                Random rnd = new Random();

                dmg = rnd.Next(Minimum, Maximum);

                if (rnd.Next(0, 100) < CriticalChance)
                    dmg = (int)(dmg * 1.5);

            }
            else
                dmg = Minimum;

            return dmg;
        }
    }
}
