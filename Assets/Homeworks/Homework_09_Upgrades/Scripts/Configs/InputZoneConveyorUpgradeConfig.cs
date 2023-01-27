using Homework_08_Interaction.ConveyorUpgrades;
using UnityEngine;

namespace Homework_08_Interaction.Configs
{
    [CreateAssetMenu(fileName = "InputZoneConveyorUpgradeConfig", menuName = "Homework/Upgrade/Input Zone Upgrade")]
    public class InputZoneConveyorUpgradeConfig : ConveyorUpgradeConfig
    {
        [SerializeField] private int addSize = 1;

        public int AddSize => addSize;

        public override ConveyorUpgrade instantiateUpgrade()
        {
            return new InputZoneConveyorUpgrade(this);
        }
    }
}