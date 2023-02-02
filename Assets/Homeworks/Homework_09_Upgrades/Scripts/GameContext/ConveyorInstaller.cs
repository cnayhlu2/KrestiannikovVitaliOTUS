using System.Collections.Generic;
using GameSystem;
using Homework_08_Interaction.Configs;
using Homework_Presentation_Model.Storage;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_08_Interaction.GameContext
{
    public class ConveyorInstaller : MonoBehaviour, IGameConstructElement, IGameServiceGroup
    {
        [SerializeField] private ConveyorUpgradeCatalog catalog;

        [ShowInInspector] private ConveyorUpgradesStorage conveyorUpgradesStorage = new();
        [ShowInInspector] private ConveyorUpgradesManager manager = new();


        public void ConstructGame(IGameContext context)
        {
            var moneyStorage = context.GetService<MoneyStorage>();
            var conveyorService = context.GetService<IConveyorService>();
            this.conveyorUpgradesStorage.Constract(conveyorService, catalog);
            this.manager.Construct(conveyorUpgradesStorage, moneyStorage);
        }

        public IEnumerable<object> GetServices()
        {
            yield return this.manager;
        }
    }
}