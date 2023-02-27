using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_13_14_inventory
{
    public class InventorySystemInstaller : MonoBehaviour, IGameConstructElement
    {
        private Inventory inventory = new();

        [ShowInInspector] private InventoryService inventoryService = new();


        [Button, BoxGroup("Debug")]
        private void AddItem(InventoryItemConfig config)
        {
            this.inventory.AddItem(config.Prototype.Clone());
        }

        [Button, BoxGroup("Debug")]
        private void RemoveItem(InventoryItemConfig config)
        {
            this.inventory.RemoveItemLast(config.Prototype.Name);
        }

        public void ConstructGame(IGameContext context)
        {
            this.inventoryService.Construct(inventory);
        }
    }
}