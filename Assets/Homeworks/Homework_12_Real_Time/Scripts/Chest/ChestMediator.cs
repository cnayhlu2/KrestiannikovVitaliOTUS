using System.Collections.Generic;
using Homework_11_Chests;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts.Chest
{
    public class ChestMediator
    {
        private MonoBehaviour behaviour;
        private ChestsRepository repository;
        private ChestManager manager;
        private ChestCatalog catalog;

        public void Construct(ChestsRepository repository, ChestManager manager, ChestCatalog catalog,
            MonoBehaviour behaviour)
        {
            this.repository = repository;
            this.manager = manager;
            this.catalog = catalog;
            this.behaviour = behaviour;
        }

        public void SaveChests()
        {
            ChestsData data = new ChestsData();
            data.chests = new();

            foreach (var chest in this.manager.GetChests)
            {
                ChestData chestData = new ChestData()
                {
                    Type = chest.Type,
                    RemainingSeconds = chest.RemainingSeconds
                };

                data.chests.Add(chestData);
            }

            this.repository.Save(data);
        }

        public void LoadChests()
        {
            this.repository.LoadChestsData(out ChestsData data);

            List<Homework_11_Chests.Chest> chests = new List<Homework_11_Chests.Chest>();

            for (int i = 0; i < data.chests.Count; i++)
            {
                var chestData = data.chests[i];
                ChestConfig config = this.catalog.GetChestConfigByType(chestData.Type);
                Homework_11_Chests.Chest chest = config.InstatiateChest(behaviour);
                chest.RemainingSeconds = chestData.RemainingSeconds;
                chests.Add(chest);
            }

            this.manager.SetChests(chests);
        }
    }
}