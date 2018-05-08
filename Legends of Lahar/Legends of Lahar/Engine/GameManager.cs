using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Legends_Of_Lahar
{
    class GameManager
    {
        private List<object> _actions;
        private bool _isRunning;
        public Player CurrentPlayer;
        public Enemy CurrentEnemy;
        public BattleSystem CurrentBattleSystem;
        public readonly string WorkingDirectory;
        public Event CurrentEvent;
        Thread t_GM;

        public static GameManager CurrentGameManager;

        public GameManager()
        {
            _actions = new List<object>();
            CurrentGameManager = this;
            WorkingDirectory = Directory.GetCurrentDirectory();
        }

        public void Start()
        {
            if(File.Exists(WorkingDirectory + "\\Data\\Player.sav"))
                IOstreamer.LoadPlayer(WorkingDirectory);
            else
            {
                ConfirmCharacterName ccn = new ConfirmCharacterName();
                ccn.ShowDialog();
            }

            if (CurrentPlayer != null)
            {
                t_GM = new Thread(StartWatching);
                t_GM.Start();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        

        private void StartWatching()
        {
            _isRunning = true;
            int count = 0;
            string[] stats = new string[6];

            while (_isRunning && CurrentPlayer.GetState() != 0)
            {
                IOstreamer.SavePlayer(WorkingDirectory);

                if (CurrentBattleSystem != null)
                {
                    if (CurrentBattleSystem.GetBattleStatus())
                    {
                        //For lbl name enemy
                        stats[0] = "Anticipated LVL: ";
                        stats[1] = "Anticipated Status: ";
                        stats[2] = "Distance: ";
                        stats[5] = CurrentBattleSystem.GetEnemyName();

                        //Following checks are the info on enemy labels
                        stats[0] += CurrentBattleSystem.GetEnemyLVL().ToString(); //Level

                        // 0 = dead, 1 = Severely hurt, 2 = Damaged, 3 - A few scratches, 4 - Untouched
                        switch (CurrentBattleSystem.GetEnemyState())
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

                        switch (CurrentBattleSystem.GetDistance())
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
                            MainForm.CurrentMainForm.UpdatelblEnemy(stats);
                        }

                    }
                    else
                    {
                        CurrentEnemy = null;
                        CurrentBattleSystem = null;
                    }
                }
                else if(CurrentEvent != null)
                { }
                else
                { 
                    if (count == 15)
                    {
                        CheckEffects(CurrentPlayer, null);

                        count = 0;
                    }
                    count++;
                }

                //For lbl names
                stats[0] = "LVL: ";//Level 
                stats[1] = "Health: "; //health 
                stats[2] = "Mana: ";//mana
                stats[3] = "Physical damage bonus: "; //physical bonus
                stats[4] = "Magic damage bonus: ";//magic bonus

                //Update labels to player
                stats[0] += CurrentPlayer.GetLevel().ToString(); //Level 
                stats[1] += CurrentPlayer.GetHealth().ToString(); //health 
                stats[2] += CurrentPlayer.GetMana().ToString();  //mana
                stats[3] += CurrentPlayer.GetpBonus().ToString(); //physical bonus
                stats[4] += CurrentPlayer.GetmBonus().ToString(); //magic bonus

                MainForm.CurrentMainForm.UpdatelblPlayer(stats);

                Thread.Sleep(200);
            }
            if(CurrentBattleSystem != null)
            {
                CurrentBattleSystem.SetBattleStatus(false);
            }
            IOstreamer.DeletePlayer(WorkingDirectory);
            MainForm.CurrentMainForm.ClearPlayer();
        }

        //runs the scripts on an entity
        public void CheckEffects(Entity origin, Entity target)
        {
            List<Effect> temp = origin.GetEffects();

            if (temp != null)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    Effect e = temp.ElementAt(i);
                    
                    if (e.Ticks > 0)
                    {
                        e.Ticks += -1;
                        EffectData.RunScript(e.ID, e.Ticks, origin, target);
                        if (e.Ticks == 0)
                        {
                            temp.Remove(e);
                            MainForm.CurrentMainForm.SendToBox(e.Name + " fades from " + origin.GetName());
                        }
                    }
                    else
                        EffectData.RunScript(e.ID, e.Ticks, origin, target);
                }
            }

            origin.UpdateEffects(temp);
        }

        //checks whether dead or alive, tells mainform
        public bool CheckEntities()
        {
            if (CurrentEnemy.GetHealth() <= 0)
            {
                CurrentBattleSystem.SetBattleStatus(false);
                MainForm.CurrentMainForm.SendToBox(CurrentEnemy.GetName() + " died");

                return false;
            }
            else if (CurrentPlayer.GetHealth() <= 0)
            {
                CurrentBattleSystem.SetBattleStatus(false);
                MainForm.CurrentMainForm.SendToBox(CurrentPlayer.GetName() + " died");
            }

            return true;
        }

        public void StopWatching()
        {
            t_GM.Abort();
        }
    }
}
