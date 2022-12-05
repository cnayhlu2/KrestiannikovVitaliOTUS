using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;


namespace Homework_Presentation_Model.Storage
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private float damagePerLevel = 10;
        [SerializeField] private string heroStartName = "Shiko";
        [SerializeField] private int heroStartLevel = 1;
        [SerializeField] private int maxLevel = 10;

        [SerializeField] private int levelCost = 100;

        [SerializeField] private Hero hero;


        public Hero GetHero => hero;
        public Action<Hero> OnHeroChange;
        public int LevelCost => levelCost;

        private void Awake()
        {
            hero = Hero.Construct(heroStartName, heroStartLevel, heroStartLevel * damagePerLevel);
        }

        public bool CanHeroUpgrade()
        {
            return hero.Level < maxLevel;
        }

        public void LevelUpHero()
        {
            hero.SetLevel(hero.Level + 1);
            hero.SetDamage(hero.Level * damagePerLevel);
            OnHeroChange?.Invoke(hero);
        }
    }


    [Serializable]
    public class Hero
    {
        [SerializeField] private string name;
        [SerializeField] private int level;
        [SerializeField] private float damage;

        public string Name => name;
        public int Level => level;
        public float Damage => this.damage;

        public static Hero Construct(string heroName, int heroLevel, float heroDamage)
        {
            return new()
            {
                name = heroName,
                level = heroLevel,
                damage = heroDamage
            };
        }

        public void SetLevel(int newLevel)
        {
            this.level = newLevel;
        }

        public void SetDamage(float newDamage)
        {
            this.damage = newDamage;
        }
    }
}