using Homework_08_Interaction.ConveyorUpgrades;
using UnityEngine;

namespace Homework_08_Interaction.Configs
{
    [CreateAssetMenu(fileName = "TimeConveyorUpgradeConfig",menuName = "Homework/Upgrade/Time Upgrade")]
    public class TimeConveyorUpgradeConfig : ConveyorUpgradeConfig
    {

        [SerializeField] private float reduceTime = .3f;

        public float ReduceTime => reduceTime;
        
        public override ConveyorUpgrade instantiateUpgrade()
        {
            return new TimeConveyorUpgrade(this);
        }

    }
}