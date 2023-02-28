using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_13_14_inventory
{
    public class InventorySystemInstaller : MonoBehaviour, IGameConstructElement
    {
        private Inventory inventory = new();
        private Inventory eqipInventory = new();

        private EqipmentManager manager = new();
        
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

        [Button, BoxGroup("Debug")]
        private void EqipItem(string name)
        {
            this.manager.EqipItem(name);
        }
        

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.manager.Construct(this.eqipInventory, this.inventory);
            this.inventoryService.Construct(this.inventory, this.eqipInventory, this.manager);
        }
    }
}