using System;
using System.Collections.Generic;
using GameSystem;
using Homework_06_Conveyor;
using Homework_08_Interaction.Components;
using Homework_08_Interaction.Configs;
using Homework_08_Interaction.ConveyorUpgrades;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework_08_Interaction.GameContext
{
    public class ConveyorUpgradesStorage
    {
        [ShowInInspector] private ConveyorUpgradesDictionary conveyorsUpgrades = new();

        private IConveyorService service;
        private ConveyorUpgradeCatalog catalog;

        public void Constract(IConveyorService service, ConveyorUpgradeCatalog catalog)
        {
            this.service = service;
            this.catalog = catalog;
            CreateUpgrades();
        }

        public List<IGameElement> GetElements()
        {
            Debug.Log("GetElements");
            List<IGameElement> result = new();

            foreach (var conveyorsUpgrade in conveyorsUpgrades)
            {
                foreach (var upgrade in conveyorsUpgrade.Value)
                {
                    if (upgrade is IGameElement element)
                    {
                        result.Add(element);
                    }
                }
            }

            return result;
        }

        public ConveyorUpgrade GetConveyorUpgradeById(string id, int index)
        {
            if (!conveyorsUpgrades.ContainsKey(id))
                throw new Exception($"storage do not have id {id}");

            if (index < 0 || index > conveyorsUpgrades[id].Count)
                throw new Exception($"storage do not have id {id} by index {index}");

            return conveyorsUpgrades[id][index];
        }


        private void CreateUpgrades()
        {
            var conveyors = service.GetAllConveyors();

            foreach (var conveyor in conveyors)
            {
                List<ConveyorUpgrade> upgrades = new();
                string id = conveyor.Get<IIDComponent>().GetId();
                foreach (var config in catalog.GetAllConfigs())
                {
                    var upgrade = config.instantiateUpgrade();
                    upgrade.SetLevel(Random.Range(0, config.MaxLevel + 1));
                    upgrade.SetupConveyor(conveyor);
                    upgrades.Add(upgrade);
                }

                conveyorsUpgrades.Add(conveyor.Get<IIDComponent>().GetId(), upgrades);
            }
        }
    }


    [System.Serializable]
    public class ConveyorUpgradesDictionary : UnitySerializedDictionary<string, List<ConveyorUpgrade>>
    {
    }
}