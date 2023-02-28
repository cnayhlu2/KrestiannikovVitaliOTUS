using Sirenix.OdinInspector;

namespace Homeworks.Homework_13_14_inventory
{
    public sealed class InventoryService
    {
        [ShowInInspector] private Inventory inventory;
        [ShowInInspector] private Inventory eqipInventory;
        private EqipmentManager manager;

        public Inventory GetInventory => this.inventory;
        public Inventory GetEqippment => this.eqipInventory;

        public EqipmentManager GetEqippmentManager => this.manager;
        
        public void Construct(Inventory inventory,Inventory eqipInventory, EqipmentManager manager)
        {
            this.inventory = inventory;
            this.eqipInventory = eqipInventory;
            this.manager = manager;
        }

    }
}