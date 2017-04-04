using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    class GameManager
    {
        private List<object> _actions;
        private bool _isRunning;
        private MainForm _currentForm;
        public Player _currentPlayer;
        public Enemy _currentEnemy;
        Thread t_GM;

        public static GameManager _GM;

        public GameManager(MainForm currentForm)
        {
            _currentForm = currentForm;
            _actions = new List<object>();
            _GM = this;

            t_GM = new Thread(StartWatching);
            t_GM.Start();
        }

        public void PushToForm(string s)
        {
            _currentForm.SendToBox(s);
        }

        public void AddEffect(Effect e, Entity target)
        {
            target.AddEffect(e);
        }

        public void StartWatching()
        {
            _isRunning = true;
            int count = 0;
            string[] stats = new string[6];


            while (_isRunning && _currentPlayer.GetState() != 0)
            {
                //For lbl names
                stats[0] = "LVL: ";//Level // skal måske refaktors
                stats[1] = "Health: "; //health 
                stats[2] = "Mana: ";//mana
                stats[3] = "Physical damage bonus: "; //physical bonus
                stats[4] = "Magic damage bonus: ";//magic bonus

                //Opdaterer labels til player
                stats[0] += _currentPlayer.GetLevel().ToString(); //Level // skal måske refaktors
                stats[1] += _currentPlayer.GetHealth().ToString(); //health 
                stats[2] += _currentPlayer.GetMana().ToString();  //mana
                stats[3] += _currentPlayer.GetpBonus().ToString(); //physical bonus
                stats[4] += _currentPlayer.GetmBonus().ToString(); //magic bonus

                _currentForm.UpdatelblPlayer(stats);

                if (_currentForm.bs != null)
                {
                    if (_currentForm.bs.GetBattleStatus())
                    {
                        //For lbl name enemy
                        stats[0] = "Anticipated LVL: ";
                        stats[1] = "Anticipated Status: ";
                        stats[2] = "Distance: ";
                        stats[5] = _currentForm.bs.GetEnemyName();

                        //Opdaterer labels til enemy
                        stats[0] += _currentForm.bs.GetEnemyLVL().ToString(); //Level

                        // 0 = dead, 1 = Severely hurt, 2 = Damaged, 3 - A few scratches, 4 - Untouched
                        switch (_currentForm.bs.GetEnemyState())
                        {
                            case 0:
                                stats[1] += "Dead";
                                break;
                            case 1:
                                stats[1] += "Severely hurt";
                                break;
                            case 2:
                                stats[1] += "Damaged";
                                break;
                            case 3:
                                stats[1] += "A few scratches";
                                break;
                            case 4:
                                stats[1] += "Untouched";
                                break;
                        }

                        switch (_currentForm.bs.GetDistance())
                        {
                            case 0:
                                stats[2] += "Close combat";
                                break;
                            case 1:
                                stats[2] += "A few feet away";
                                break;
                            case 2:
                                stats[2] += "Ranged";
                                break;
                        }


                        if(CheckEntities())
                        {
                            _currentForm.UpdatelblEnemy(stats);
                        }

                    }
                    else
                    {
                        _currentForm.bs = null;
                    }
                }
                else
                { // skal foran mainform opdatering
                    if (count == 15)
                    {
                        CheckEffects(_currentPlayer, null);

                        count = 0;
                    }
                    count++;
                }

                Thread.Sleep(200);
            }

            _currentForm.ClearPlayer();
        }

        public void CheckEffects(Entity origin, Entity target)
        {
            List<Effect> temp = origin.GetEffects();

            if (temp != null)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    Effect e = temp.ElementAt(i);
                    EffectData.RunScript(e.ID, origin, target);
                    if (e.Ticks > 0)
                    {
                        e.Ticks += -1;
                        if (e.Ticks == 0)
                        {
                            temp.Remove(e);
                        }
                    }
                }
            }
        }

        public bool CheckEntities()
        {
            if (_currentEnemy.GetHealth() <= 0)
            {
                _currentForm.bs.SetBattleStatus(false);
                _currentForm.SendToBox(_currentEnemy.GetName() + " died");
                return false;
            }
            else if (_currentPlayer.GetHealth() <= 0)
            {
                _currentForm.bs.SetBattleStatus(false);
                _currentForm.SendToBox(_currentPlayer.GetName() + " died");
            }

            return true;
        }

        public void StopWatching()
        {
            t_GM.Abort();
        }
    }
}
