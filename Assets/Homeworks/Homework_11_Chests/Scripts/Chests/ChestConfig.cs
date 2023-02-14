using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_11_Chests
{
    [CreateAssetMenu(fileName = "Chest",
        menuName = "Homework/Chests/New Chest Config")]
    public class ChestConfig : ScriptableObject
    {
        [SerializeField, PreviewField] private Sprite icon;
        [SerializeField] private ChestType type;
        [SerializeField] private List<RewardConfig> rewardses = new();
        [SerializeField] private float duration;

        public Sprite GetIcon => this.icon;
        public ChestType ChestType => this.type;
        public List<RewardConfig> Rewards => this.rewardses;
        public float Duration => duration;

        public Chest instatiateChest(MonoBehaviour behaviour)
        {
            Chest chest = new(this, behaviour);
            return chest;
        }
    }
}