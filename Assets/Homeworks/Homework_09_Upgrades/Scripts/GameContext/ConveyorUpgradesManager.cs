using System;
using System.Collections.Generic;
using Homework_08_Interaction.ConveyorUpgrades;
using Homework_Presentation_Model.Storage;
using Sirenix.OdinInspector;

namespace Homework_08_Interaction.GameContext
{
    public class ConveyorUpgradesManager
    {
        private ConveyorUpgradesStorage storage;
        private MoneyStorage moneyStorage;

        public void Construct(ConveyorUpgradesStorage conveyorUpgradesStorage, MoneyStorage moneyStorage)
        {
            this.storage = conveyorUpgradesStorage;
            this.moneyStorage = moneyStorage;
        }

        public List<ConveyorUpgrade> GetUpgradesById(string id)
        {
            return this.storage.GetConveyorUpgradesById(id);
        }

        public bool CanUpgrade(ConveyorUpgrade upgrade)
        {
            if (upgrade.IsMaxLevel)
                return false;
            return this.moneyStorage.CanSpendMoney(upgrade.GetPrice);
        }

        public void Upgrade(ConveyorUpgrade upgrade)
        {
            if (!CanUpgrade(upgrade))
            {
                throw new Exception($"Can not upgrade {upgrade.GetId} name {nameof(upgrade)}");
            }

            this.moneyStorage.SpendMoney(upgrade.GetPrice);
            upgrade.Upgrade();
        }

        [Button]
        public bool CanUpgrade(string id, int index)
        {
            var upgrade = this.storage.GetConveyorUpgradeById(id, index);
            return this.CanUpgrade(upgrade);
        }

        [Button]
        public void Upgrade(string id, int index)
        {
            var upgrade = this.storage.GetConveyorUpgradeById(id, index);
            this.Upgrade(upgrade);
        }
    }
}