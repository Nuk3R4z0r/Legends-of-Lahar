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
        private MainForm _currentForm;
        private bool _effectsChecked;

        // når en battle oprettes skal den bruge et område kode for at bestemme modstander, på areaCode
        public BattleSystem(Area currentArea, MainForm currentform)
        {
            _currentForm = currentform;
            //henter en liste af monstre man kan møde i det område man er i, på areaCode

            //opretter monsteret
            _enemy = new Enemy(currentArea.GetFirstEntity());
            currentform.RenderEnemy(_enemy.GetPic());

            _player = GameManager._GM._currentPlayer;
            GameManager._GM._currentEnemy = _enemy;

            _actionId = new int[2];

            Thread tBattle = new Thread(RunBattle);
            tBattle.Start();
        }

        private void RunBattle()
        {
            _battleRunning = true;
            _playerTurn = true;
            _currentForm.SendToBox("You got attacked by " + _enemy.GetName());

            while (_battleRunning)
            {

                if (_playerTurn)
                {
                    if (!_effectsChecked)
                    {
                        GameManager._GM.CheckEffects(_enemy, _player);
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
                    GameManager._GM.CheckEffects(_enemy, _player);
                    _actionId = AI.MakeChoice(_enemy, _player);
                    Fight(_enemy, _player);

                    _actionId[0] = 0;
                    _playerTurn = true;
                }
            }

            _currentForm.ClearEnemy();
        }

        private void Fight(Entity currentEntity, Entity enemy)
        {
            int dmg = 0;
            bool enemyDodged = enemy.RollDodge();
            switch (_actionId[0])
            {
                case 1:
                    //Basic Attack
                    dmg = currentEntity.GetpBonus(); // + WEAPON DAMAGE IN FUTURE // REFACTOR SÅ DAMAGE MODDED AF RESIST ER GLOBAL
                    _currentForm.SendToBox(currentEntity.GetName() + " uses basic attack!");
                    break;
                case 2:
                    //Block
                    currentEntity.ToggleBlocking();// CHANGE ME TO SHIELD BLOCKING PARAMETER
                    _currentForm.SendToBox(currentEntity.GetName() + " gets ready to block!"); //1 er placeholder indtil items med ordentlig block er implementeret
                    break;
                case 3:
                    //Use SKill
                    _currentForm.SendToBox(currentEntity.GetName() + " uses " + SkillData.SkillList[_actionId[1]].Name + "!");

                    if(!enemyDodged)
                        dmg = SkillData.UseSkill(_actionId[1], currentEntity, enemy);
                        
                    break;
                case 4:
                    //flee
                    if (_distance >= 1)
                    {
                        _currentForm.SendToBox(currentEntity.GetName() + " flees from the battle!");
                        _battleRunning = false;
                    }
                    break;
            }

            if (enemy.GetIsBlocking())
            {
                if (dmg != 0 && !enemyDodged)
                {
                    int blockedDmg = (dmg / 2) + enemy.GetBlockBonus(); 
                    _currentForm.SendToBox(enemy.GetName() + " blocked " + blockedDmg + " damage!");
                    dmg -= blockedDmg;
                }

                enemy.ToggleBlocking();
            }

            if (dmg != 0)
            { 
                if (!enemyDodged)
                {
                    _currentForm.SendToBox(currentEntity.GetName() + " deals " + enemy.DamageToHealth(new Damage(SkillData.TYPE_PHYSICAL, dmg, currentEntity.GetCriticalChance())) + " damage to " + enemy.GetName() + "!");
                }
                else
                {
                    _currentForm.SendToBox(enemy.GetName() + " dodges!");
                }
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
