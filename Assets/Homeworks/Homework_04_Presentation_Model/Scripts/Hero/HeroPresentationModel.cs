using System;
using Homework_Presentation_Model.Storage;
using UnityEngine;


namespace Homework_Presentation_Model.Hero
{
    public class HeroPresentationModel : IHomework_Presentation_Model
    {
        public event Action<bool> OnBuyButtonStateChanged;

        public HeroPresentationModel(HeroController heroController, MoneyStorage moneyStorage)
        {
            this.heroController = heroController;
            this.moneyStorage = moneyStorage;
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public string GetName() => heroController.GetHero.Name;

        public string GetLevel() => heroController.GetHero.Level.ToString();

        public string GetDamage() => heroController.GetHero.Damage.ToString();

        public string GetUpgradeCost() => heroController.LevelCost.ToString();

        public bool CanUpgrade()
        {
            return moneyStorage.CanSpendMoney(heroController.LevelCost) && heroController.CanHeroUpgrade();
        }

        public void OnBuyClicked()
        {
            moneyStorage.SpendMoney(heroController.LevelCost);
            heroController.LevelUpHero();
        }

        private HeroController heroController;
        private MoneyStorage moneyStorage;
        private IHomework_Presentation_Model homeworkImplementation;
        private IHomework_Presentation_Model homeworkImplementation1;
    }

    public interface IHomework_Presentation_Model
    {
        event Action<bool> OnBuyButtonStateChanged;

        void Start();

        void Stop();

        string GetName();

        string GetLevel();
        string GetDamage();

        string GetUpgradeCost();

        bool CanUpgrade();

        void OnBuyClicked();
    }
}