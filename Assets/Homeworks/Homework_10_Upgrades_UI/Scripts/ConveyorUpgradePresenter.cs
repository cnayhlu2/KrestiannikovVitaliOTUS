using Homework_08_Interaction.ConveyorUpgrades;
using Homework_08_Interaction.GameContext;
using Homework_Presentation_Model.Storage;
using Homework_Presentation_Model.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Homeworks.Homework_10_Upgrades_UI.Scripts
{
    public class ConveyorUpgradePresenter
    {
        private ConveyorUpgrade upgrade;
        private ConveyorUpgradeView view;

        private MoneyStorage moneyStorage;
        private ConveyorUpgradesManager upgradesManager;

        public ConveyorUpgradePresenter(ConveyorUpgrade upgrade, ConveyorUpgradeView view)
        {
            this.upgrade = upgrade;
            this.view = view;
        }

        public void Construct(MoneyStorage moneyStorage, ConveyorUpgradesManager upgradesManager)
        {
            this.moneyStorage = moneyStorage;
            this.upgradesManager = upgradesManager;
        }

        public void Show()
        {
            this.moneyStorage.OnMoneyChanged += OnMoneyChanged;
            this.upgrade.OnUpgrade += OnUpgraded;
            this.view.Button.AddListener(OnButtonClicked);

            this.view.SetName(this.upgrade.GetName);
            this.view.SetIcon(this.upgrade.GetIcon);

            this.UpdateStats();
            this.UpdateLevel();
            this.UpdatePrice();
            this.UpdateButtonState();
        }

        public void Hide()
        {
            this.upgrade.OnUpgrade -= OnUpgraded;
            this.moneyStorage.OnMoneyChanged -= OnMoneyChanged;
            this.view.Button.RemoveListener(OnButtonClicked);
        }

        private void OnUpgraded(int obj)
        {
            this.UpdateStats();
            this.UpdateLevel();
            this.UpdatePrice();
            this.UpdateButtonState();
        }

        private void OnMoneyChanged(int value)
        {
            this.UpdatePrice();
            this.UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            if (this.upgrade.IsMaxLevel)
            {
                this.view.Button.SetState(BuyButton.State.MAXED);
                return;
            }

            if (this.moneyStorage.Money >= this.upgrade.GetPrice)
            {
                this.view.Button.SetState(BuyButton.State.AVAILABLE);
                return;
            }

            this.view.Button.SetState(BuyButton.State.LOCKED);
        }

        private void UpdatePrice()
        {
            this.view.Button.SetPrice(this.upgrade.IsMaxLevel ? "MAX" : this.upgrade.GetPrice.ToString());
        }

        private void UpdateLevel()
        {
            this.view.SetLevel(upgrade.Level.ToString());
        }

        private void UpdateStats()
        {
            string stats = this.upgrade.GetStats();
            this.view.SetStats(stats);
        }

        private void OnButtonClicked()
        {
            if (this.upgradesManager.CanUpgrade(this.upgrade))
            {
                this.upgradesManager.Upgrade(this.upgrade);
            }
        }
    }
}