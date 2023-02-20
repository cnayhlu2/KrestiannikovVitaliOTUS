using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_11_Chests
{
    public class ChestSystemInstaller : MonoBehaviour, IGameConstructElement
    {
        [SerializeField] private List<ChestConfig> chestConfigs = new();
        [ShowInInspector] private ChestManager chestManager;

        public void ConstructGame(IGameContext context)
        {
            this.chestManager = new ChestManager();
            List<Chest> chests = this.InitChests();
            RewardManager rewardManager = context.GetService<RewardManager>();
            this.chestManager.Construct(rewardManager, chests);
        }

        private List<Chest> InitChests()
        {
            List<Chest> chests = new();
            foreach (var chestConfig in chestConfigs)
            {
                chests.Add(chestConfig.InstatiateChest(this));
            }

            return chests;
        }
    }
}