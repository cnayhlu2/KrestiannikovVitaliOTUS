using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Homework_11_Chests
{
    public class ChestManager
    {
        [ShowInInspector] private List<Chest> chests = new();

        private RewardManager rewardManager;

        public void Construct(RewardManager rewardManager, List<Chest> chests)
        {
            this.rewardManager = rewardManager;
            this.chests = chests;
            Start();
        }

        private void Start()
        {
            for (int i = 0; i < this.chests.Count; i++)
            {
                this.chests[i].Start();
            }
        }

        [Button]
        public void TakeRewardByType(ChestType type)
        {
            Chest chest = chests.Find(item => item.Type == type);
            if (chest == null)
            {
                throw new Exception($"Do not find chest {type}");
            }

            if (chest.IsCompleted)
            {
                chest.Reset();
                this.rewardManager.TakeReward(chest.GetRandomReward());
                chest.Start();
            }
        }
    }
}