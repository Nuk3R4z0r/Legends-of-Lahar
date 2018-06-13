using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    static class AI
    {
        public static int[] MakeChoice(Enemy ai, Player target)
        {
            Random rnd = new Random();
            List<Skill> temp = ai.GetSkills();
            int action = rnd.Next(0, 2); //currently just taking a random choice

            //Use skill
            if (action == 0 && temp != null && temp.Count != 0)
            {
                List<int> possibleSkills = new List<int>();

                foreach(Skill i in temp)
                {
                    if(SkillData.SkillList.ElementAt(i.ID).ManaCost <= ai.GetMana())
                    {
                        possibleSkills.Add(i.ID);
                    }
                }

                if(possibleSkills.Count != 0)
                return new int[] { 3, possibleSkills.ElementAt(rnd.Next(0, possibleSkills.Count)) };
            }
            else if(action == 1) //Block
            {
                return new int[] { 2, 0 }; 
            }

            return new int[] { 1, 0 }; //Basic attack
        }
    }
}
