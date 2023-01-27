using Homework_08_Interaction.ConveyorUpgrades;
using UnityEngine;

namespace Homework_08_Interaction.Configs
{
    [CreateAssetMenu(fileName = "LoadZoneConveyorUpgradeConfig",menuName = "Homework/Upgrade/Load Zone Upgrade")]
    public class LoadZoneConveyorUpgradeConfig : ConveyorUpgradeConfig
    {

        [SerializeField] private int addSize = 1;

        public int AddSize => addSize;
        
        public override ConveyorUpgrade instantiateUpgrade()
        {
            return new LoadZoneConveyorUpgrade(this);
        }

    }
}