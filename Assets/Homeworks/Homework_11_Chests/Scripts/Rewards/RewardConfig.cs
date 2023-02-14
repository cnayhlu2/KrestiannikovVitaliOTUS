using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Homework_11_Chests
{
    
    [CreateAssetMenu(fileName = "Reward",
        menuName = "Homework/Chests/New Reward Config")]
    public class RewardConfig : SerializedScriptableObject
    {
        public string Id => this.reward.Id;

        public Reward Reward => this.reward;

        [OdinSerialize] private Reward reward = new();
    }
}