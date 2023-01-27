using System.Collections.Generic;
using UnityEngine;

namespace Homework_08_Interaction.Configs
{
    [CreateAssetMenu(fileName = "ConveyorUpgradeCatalog",
        menuName = "Homework/Upgrade/New Conveyor Upgrade catalog")]
    public class ConveyorUpgradeCatalog : ScriptableObject
    {
        [SerializeField] private List<ConveyorUpgradeConfig> configs;
        public List<ConveyorUpgradeConfig> GetAllConfigs() => configs;

    }
}