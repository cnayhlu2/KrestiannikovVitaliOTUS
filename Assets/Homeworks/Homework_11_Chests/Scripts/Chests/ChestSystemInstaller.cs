using System.Collections.Generic;
using GameSystem;
using Homeworks.Homework_12_Real_Time.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_11_Chests
{
    public class ChestSystemInstaller : MonoBehaviour, IGameConstructElement, IGameReadyElement, IGameFinishElement
    {
        [SerializeField] private List<ChestConfig> chestConfigs = new();
        [SerializeField] private TimeShifter shifter;
        [ShowInInspector] private ChestManager chestManager;
        private ChestSynchronizer synchronizer = new();

        public void ConstructGame(IGameContext context)
        {
            this.chestManager = new ChestManager();
            List<Chest> chests = this.InitChests();
            RewardManager rewardManager = context.GetService<RewardManager>();
            this.chestManager.Construct(rewardManager, chests);
            this.synchronizer.Construct(this.chestManager);
        }

        public void ReadyGame()
        {
            this.shifter.AddSynchronizer(this.synchronizer);
        }

        public void FinishGame()
        {
            this.shifter.RemoveSynchronizer(this.synchronizer);
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