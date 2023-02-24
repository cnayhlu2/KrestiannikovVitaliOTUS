using System.Collections.Generic;
using GameSystem;
using Homework_05_Save_Load.Application;
using Homeworks.Homework_12_Real_Time.Scripts;
using Homeworks.Homework_12_Real_Time.Scripts.Chest;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_11_Chests
{
    public class ChestSystemInstaller : MonoBehaviour, IGameConstructElement, 
        IGameReadyElement, IGameFinishElement, IGameInitElement
    {
        [SerializeField] private TimeShifter shifter;
        [SerializeField] private ChestCatalog catalog;
        [ShowInInspector] private ChestManager chestManager;
        private ChestSynchronizer synchronizer = new();
        private ChestMediator chestMediator = new();
        private ChestsRepository repository = new();

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.chestManager = new ChestManager();
            RewardManager rewardManager = context.GetService<RewardManager>();
            this.chestManager.Construct(rewardManager);
            this.synchronizer.Construct(this.chestManager);
            this.chestMediator.Construct(this.repository, this.chestManager,this.catalog,this);
        }

        void IGameReadyElement.ReadyGame()
        {
            Debug.Log("ReadyGame");
            this.chestManager.StartChests();
            this.shifter.AddSynchronizer(this.synchronizer);
        }

        void IGameFinishElement.FinishGame()
        {
            Debug.Log("FinishGame");
            this.shifter.RemoveSynchronizer(this.synchronizer);
            this.chestMediator.SaveChests();
        }

        void IGameInitElement.InitGame()
        {
            Debug.Log("InitGame");
            this.chestMediator.LoadChests();
        }

    }
}