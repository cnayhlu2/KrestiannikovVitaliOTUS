using Homework_08_Interaction.ConveyorUpgrades;
using UnityEngine;

namespace Homework_08_Interaction.Configs
{
    public abstract class ConveyorUpgradeConfig : ScriptableObject
    {
        [SerializeField] private int maxLevel = 2;
        [SerializeField] private int cost = 100;
        public int MaxLevel => maxLevel;
        public int Price => cost;

        public abstract ConveyorUpgrade instantiateUpgrade();

    }
}