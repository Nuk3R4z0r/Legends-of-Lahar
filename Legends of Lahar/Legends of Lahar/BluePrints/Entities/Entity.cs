﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Legends_Of_Lahar
{
    public class Entity
    {
        private string _name;
        private int _level;
        private int _health;
        private int _mana;
        private int _maxHealth;
        private int _maxMana;
        private int _physicalDamage;
        private int _magicalDamage;
        private int _critChance;
        private Resist _res; //0 = physical, 1 = fire, 2 = cold, 3 = void
        private int _dodge;
        private int _blockBonus; // skal sættes igennem items
        private bool _isBlocking;
        private int _shield; //Health buffer givet via spells
        private List<Effect> _effects;
        private List<int> _knownSkills;
        private int _state; // 0 = dead, 1 = Severely hurt, 2 = Damaged, 3 - A few scratches, 4 - Untouched
        private int _turnsFrozen;

        private string _pic;

        //skal bruge et array af data for at oprette en entity, kaldet data
        //0 er navn, 1 er level, 2 er health, 3 er mana, 4 er pdamage, 5 er mdamage, 6 er resist
        public Entity(string name, int lvl, int health, int mana, int pDamage, int mDamage, Resist res, int dodge, int[] skills, string pic)
        {
            _name = name;
            _level = lvl;

            _maxHealth = health;
            _maxMana = mana;
            _health = _maxHealth;
            _mana = _maxMana;

            _physicalDamage = pDamage;
            _magicalDamage = mDamage;
            _critChance = 0; //placeholder
            _res = res;
            _dodge = dodge;

            _knownSkills = skills.ToList();
            _isBlocking = false;
            _effects = new List<Effect>();

            _state = 4;
            _turnsFrozen = 0;

            _pic = pic;
        }

        public Entity(Entity blueprint)
        {
            _name = blueprint.GetName();
            _level = blueprint.GetLevel();
            _health = blueprint.GetMaxHealth();
            _maxHealth = blueprint.GetMaxHealth();
            _mana = blueprint.GetMaxMana();
            _maxMana = blueprint.GetMaxMana();
            _physicalDamage = blueprint.GetpBonus();
            _magicalDamage = blueprint.GetmBonus();
            _critChance = blueprint.GetCriticalChance();
            _res = blueprint.GetResistances();
            _dodge = blueprint.GetDodge();
            _isBlocking = false;
            _knownSkills = blueprint._knownSkills;
            _pic = blueprint.GetPic();
            _state = 4;

            _effects = new List<Effect>();
        }

        // Når der bliver dealt skade ud - både til NPC og playeren
        public int DamageToHealth(Damage dmg)
        {
            double amount = dmg.Random();
            amount = amount - (((Math.Pow(_res.GetResistance(dmg.DamageType), 0.05) * amount) - amount) / 3 ); 
            _health = _health - (int)amount;

            SetState();

            return (int)amount;
        }

        //til at heale liv
        public int HealHealth(int amount, string src)
        {
            _health = _health + amount;
            if (_health > _maxHealth)
                _health = _maxHealth;

            SetState();
            return _health;
        }

        //damager mana, Eks. En spell som drainer npc/playerens mana
        public int DamageMana(int amount, string src)
        {
            _mana = _health - amount;
            if (_health > _maxHealth)
                _health = _maxHealth;
            if (_health < 0)
                _health = 0;
            
            return _mana;
        }

        // En spell som giver mana til npc/playeren
        public int HealMana(int amount, string src)
        {
            _mana = _mana + amount;
            if (_mana > _maxMana)
                _mana = _maxMana;
            if (_mana < 0)
                _mana = 0;
            
            return _mana;
        }

        private void SetState()
        {
            float percentage = ((float)_health / (float)_maxHealth) * 100.0f;

            if (percentage <= 0)
                _state = 0;
            if (percentage > 0 && percentage < 33)
                _state = 1;
            if (percentage >= 33 && percentage < 66)
                _state = 2;
            if (percentage >= 66 && percentage <= 99)
                _state = 3;
            if (percentage == 100)
                _state = 4;
        }

        public bool RollDodge()
        {
            Random rnd = new Random();
            if(rnd.Next(0, 100) < _dodge)
            {
                return true;
            }

            return false;
        }

        //Henter Name
        public string GetName()
        {
            return _name;
        }

        //Henter level
        public int GetLevel()
        {
            return _level;
        }

        //tilføjer level, brugt kun i Player
        public void AddLevel()
        {
            _level++;
        }

        //henter health
        public int GetHealth()
        {
            return _health;
        }

        //henter health
        public int GetMaxHealth()
        {
            return _maxHealth;
        }

        public Resist GetResistances()
        {
            return _res;
        }

        public int GetDodge()
        {
            return _dodge;
        }

        //henter mana
        public int GetMana()
        {
            return _mana;
        }

        //henter mana
        public int GetMaxMana()
        {
            return _maxMana;
        }

        public int GetpBonus()
        {
            return _physicalDamage;
        }

        public int GetmBonus()
        {
            return _magicalDamage;
        }

        public int GetCriticalChance()
        {
            return _critChance;
        }

        public int GetBlockBonus()
        {
            return _blockBonus;
        }

        public bool GetIsBlocking()
        {
            return _isBlocking;
        }

        public void ToggleBlocking()
        {
            _isBlocking = !_isBlocking;
        }

        //Henter om en entity er død eller levende
        public int GetState()
        {
            return _state;
        }

        public string GetPic()
        {
            return _pic;
        }

        public void LearnSkill(int skillId)
        {
            _knownSkills.Add(skillId);
        }

        public List<int> GetSkills()
        {
            return _knownSkills;
        }

        public void AddEffect(Effect e)
        {
            _effects.Add(e);
        }

        public List<Effect> GetEffects()
        {
            return _effects;
        }

        public void UpdateEffects(List<Effect> le)
        {
            _effects = le;
        }
    }
}