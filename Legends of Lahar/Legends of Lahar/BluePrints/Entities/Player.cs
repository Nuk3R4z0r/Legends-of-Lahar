using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Legends_Of_Lahar
{
    //Nedarver fra Entity
    public class Player : Entity
    {
        private int _gold;
        private int _experiencePoints;

        //skal bruge et array af data for at oprette en entity, kaldet player
        //når en player bliver oprettet sendes playerens data også til entity via base()
        public Player(string name, int lvl, int health, int mana, int pdamage, int mdamage, Resist res, int dodge, int[] skills, int gold, int exp, string pic) 
            : base(name, lvl, health, mana, pdamage, mdamage, res, dodge, skills, pic)
        {
            _experiencePoints = exp;
            _gold = gold;
        }

        //Tilføjer xp til playeren og lvler op hvis den har nok
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
