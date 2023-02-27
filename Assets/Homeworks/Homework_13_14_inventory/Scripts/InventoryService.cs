using Sirenix.OdinInspector;

namespace Homeworks.Homework_13_14_inventory
{
    public sealed class InventoryService
    {
        [ShowInInspector] private Inventory inventory;

        public Inventory GetInventory => this.inventory;
        
        public void Construct(Inventory inventory)
        {
            this.inventory = inventory;
        }

    }
}