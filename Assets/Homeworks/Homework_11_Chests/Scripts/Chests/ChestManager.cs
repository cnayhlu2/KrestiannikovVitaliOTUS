using System;
using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework_11_Chests
{
    public class ChestManager : MonoBehaviour, IGameConstructElement
    {
        [SerializeField, HideInPlayMode] private List<ChestConfig> chestConfigs = new();

        [ShowInInspector, HideInEditorMode] private List<Chest> chests = new();

        private RewardManager rewardManager;

        public void ConstructGame(IGameContext context)
        {
            this.rewardManager = context.GetService<RewardManager>();
            InitChests();
        }


        [Button]
        public void StartChestByType(ChestType type)
        {
            Chest chest = chests.Find(item => item.Type == type);
            if (chest == null)
            {
                throw new Exception($"Do not find chest {type}");
            }

            if (chest.IsActive || chest.IsCompleted)
            {
                throw new Exception($"Can't starting chest: {type}");
            }

            chest.Start();
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
                var rndIndex = Random.Range(0, chest.Rewards.Count);
                Debug.Log($"rndIndex {rndIndex}");
                var rewardConfig = chest.Rewards[rndIndex];
                this.rewardManager.TakeReward(rewardConfig.Reward);
            }
        }

        private void InitChests()
        {
            foreach (var chestConfig in chestConfigs)
            {
                this.chests.Add(chestConfig.instatiateChest(this));
            }
        }
    }
}