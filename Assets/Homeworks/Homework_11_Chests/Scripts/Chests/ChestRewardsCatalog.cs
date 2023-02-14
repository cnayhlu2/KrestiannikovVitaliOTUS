using System.Collections.Generic;
using Homework_06_Conveyor;
using UnityEngine;

namespace Homework_11_Chests
{
    
    [CreateAssetMenu(fileName = "Chest Reward Catalog",
        menuName = "Homework/Chests/New Chest Rewards Catalog")]
    public class ChestRewardsCatalog : ScriptableObject
    {
        [SerializeField] private ChestRewardsDictionary catalog = new ChestRewardsDictionary();

        public List<RewardConfig> GetRewardsByType(ChestType type)
        {
            List<RewardConfig> result = new();
            if (catalog.ContainsKey(type))
                result.AddRange(catalog[type]);
            return result;
        }
    }

    [System.Serializable]
    public class ChestRewardsDictionary : UnitySerializedDictionary<ChestType, List<RewardConfig>>
    {
    }
}