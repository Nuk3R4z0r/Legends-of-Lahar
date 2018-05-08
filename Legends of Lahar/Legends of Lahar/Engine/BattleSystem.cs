using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Legends_Of_Lahar
{
    public class BattleSystem
    {
        private Player _player;
        private Enemy _enemy;
        private Random _rnd;
        private int _distance; // 3 states, 0 close-combat, 1 a couple of feet away, 2 - Ranged
        private bool _playerTurn;
        private int[] _actionId;
        private bool _battleRunning;
        private bool _effectsChecked;

        //Battle is decided by areaCode from currentArea, gets a monster from there
        public BattleSystem(Area currentArea)
        {
            _enemy = new Enemy(currentArea.GetFirstEntity());
            MainForm.CurrentMainForm.RenderEnemy(_enemy.GetPic());

            _player = GameManager.CurrentGameManager.CurrentPlayer;
            GameManager.CurrentGameManager.CurrentEnemy = _enemy;

            _actionId = new int[2];

            Thread tBattle = new Thread(RunBattle);
            tBattle.Start();
        }

        private void RunBattle()
        {
            _battleRunning = true;
            _playerTurn = true;
            MainForm.CurrentMainForm.SendToBox("You got attacked by " + _enemy.GetName());

            while (_battleRunning)
            {

                if (_playerTurn)
                {
                    if (!_effectsChecked)
                    {
                        GameManager.CurrentGameManager.CheckEffects(_player, _enemy);
                        _effectsChecked = true;
                    }

                    if (_actionId[0] != 0)
                    {
                        Fight(_player, _enemy);
                        _playerTurn = false;
                        _actionId[0] = 0;
                        _effectsChecked = false;
                    }

                    Thread.Sleep(250);
                }
                else
                {
                    GameManager.CurrentGameManager.CheckEffects(_enemy, _player);
                    _actionId = AI.MakeChoice(_enemy, _player);
                    Fight(_enemy, _player);

                    _actionId[0] = 0;
                    _playerTurn = true;
                }
            }
            MainForm.CurrentMainForm.ClearEnemy();
            Thread.Sleep(10);
        }

        private void Fight(Entity currentEntity, Entity enemy)
        {
            switch (_actionId[0])
            {
                case 1:
                    //Basic Attack
                    MainForm.CurrentMainForm.SendToBox(currentEntity.GetName() + " uses basic attack!");
                    // + WEAPON DAMAGE IN FUTURE // REFACTOR SO THAT DAMAGE IS MODDED BY RESIST GLOBALLY
                    enemy.DamageToHealth(new Damage(SkillData.TYPE_PHYSICAL, currentEntity.GetpBonus(), currentEntity.GetCriticalChance()), currentEntity.GetName(),
                        false, false, false, false);
                    break;
                case 2:
                    //Block
                    currentEntity.ToggleBlocking();// CHANGE ME TO SHIELD BLOCKING PARAMETER
                    MainForm.CurrentMainForm.SendToBox(currentEntity.GetName() + " gets ready to block!"); //PLACEHOLDER, 1 until block from items is implemented
                    break;
                case 3:
                    //Use SKill
                    MainForm.CurrentMainForm.SendToBox(currentEntity.GetName() + " uses " + SkillData.SkillList[_actionId[1]].Name + "!");
                    currentEntity.DamageMana(SkillData.SkillList[_actionId[1]].ManaCost, SkillData.SkillList[_actionId[1]].Name);

                    SkillData.UseSkill(_actionId[1], currentEntity, enemy);
                    break;
                case 4:
                    //flee
                    if (_distance >= 1)
                    {
                        MainForm.CurrentMainForm.SendToBox(currentEntity.GetName() + " flees from the battle!");
                        _battleRunning = false;
                    }
                    break;
            }
        }

        public bool GetBattleStatus()
        {
            return _battleRunning;
        }

        public void SetBattleStatus(bool val)
        {
            _battleRunning = val;
        }

        public string GetEnemyName()
        {
            return _enemy.GetName();
        }

        public int GetEnemyLVL()
        {
            return _enemy.GetLevel();
        }

        public int GetEnemyState()
        {
            return _enemy.GetState();
        }

        public int GetDistance()
        {
            return _distance;
        }

        public void SetAction(int actionId, int skillId)
        {
            _actionId[0] = actionId;
            _actionId[1] = skillId;
        }
    }
}
