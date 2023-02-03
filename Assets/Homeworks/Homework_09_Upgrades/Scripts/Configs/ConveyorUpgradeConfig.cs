using Homework_08_Interaction.ConveyorUpgrades;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_08_Interaction.Configs
{
    public abstract class ConveyorUpgradeConfig : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField, PreviewField] private Sprite sprite;
        [SerializeField] private int maxLevel = 2;
        [SerializeField] private int cost = 100;
        public int MaxLevel => maxLevel;
        public int Price => cost;
        public Sprite GetIcon => sprite;
        public string GetName => name;

        public abstract ConveyorUpgrade instantiateUpgrade();
    }
}