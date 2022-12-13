using System;
using Homework_Presentation_Model.Storage;
using UnityEngine;


namespace Homework_Presentation_Model.Hero
{
    public class HeroPresentationModel : IHeroPresentationModel
    {
        public event Action<bool> OnBuyButtonStateChanged;

        private readonly HeroController heroController;
        private readonly MoneyStorage moneyStorage;
        
        public HeroPresentationModel(HeroController heroController, MoneyStorage moneyStorage)
        {
            this.heroController = heroController;
            this.moneyStorage = moneyStorage;
        }

        public void Start()
        {
            this.heroController.OnHeroChange += HeroChange;
            this.moneyStorage.OnMoneyChanged += MoneyChange;
        }

        public void Stop()
        {
            this.heroController.OnHeroChange -= HeroChange;
            this.moneyStorage.OnMoneyChanged -= MoneyChange;
        }

        public string GetName() => heroController.GetHero.Name;

        public string GetLevel() => heroController.GetHero.Level.ToString();

        public string GetDamage() => heroController.GetHero.Damage.ToString();

        public string GetUpgradeCost() => heroController.LevelCost.ToString();

        public bool CanUpgrade()
        {
            return moneyStorage.CanSpendMoney(heroController.LevelCost) && heroController.CanHeroUpgrade();
        }

        public void OnUpgradeClicked()
        {
            moneyStorage.SpendMoney(heroController.LevelCost);
            heroController.LevelUpHero();
        }
        
        private void HeroChange(Storage.Hero obj)
        {
            OnBuyButtonStateChanged?.Invoke(CanUpgrade());
        }
        
        private void MoneyChange(int obj)
        {
            OnBuyButtonStateChanged?.Invoke(CanUpgrade());
        }
        
    }

    public interface IHeroPresentationModel
    {
        event Action<bool> OnBuyButtonStateChanged;

        void Start();

        void Stop();

        string GetName();

        string GetLevel();
        string GetDamage();

        string GetUpgradeCost();

        bool CanUpgrade();

        void OnUpgradeClicked();
    }
}