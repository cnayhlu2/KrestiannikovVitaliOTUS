using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_05_Save_Load.Upgrades
{
    public class UpgradesController : MonoBehaviour
    {
        [ReadOnly, ShowInInspector] private List<Upgrade> upgrades = new();

        [ValueDropdown("GetUpgradeNames"), SerializeField]
        private string currentUpgrade = string.Empty;

        [Button]
        public void UpgradeCurrentUpgrade()
        {
            foreach (var upgrade in upgrades)
            {
                if (upgrade.Name == currentUpgrade)
                    upgrade.Level++;
            }
        }

        public List<string> GetUpgradeNames()
        {
            List<string> result = new();
            foreach (var upgrade in upgrades)
            {
                result.Add(upgrade.Name);
            }

            return result;
        }

        public void SetUpgrades(List<Upgrade> upgrades)
        {
            if (upgrades.Count > 0)
                currentUpgrade = upgrades[0].Name;
            this.upgrades = upgrades;
        }

        public List<Upgrade> GetUpgrades() => upgrades;
    }
}