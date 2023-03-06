using System;
using System.Collections.Generic;
using Homeworks.Homework_13_14_inventory.Eqip;

namespace Homeworks.Homework_13_14_inventory
{
    public sealed class EqipmentManager
    {
        private Inventory eqipInventory;
        private Inventory inventory;

        public void Construct(Inventory eqipInventory,Inventory inventory)
        {
            this.eqipInventory = eqipInventory;
            this.inventory = inventory;
        }

        public void EqipItem(string itemName)
        {
            if (inventory.TryFindItem(itemName, out InventoryItem item) &&
                item.FlagsExists(InventoryItemFlags.Eqippable))
            {
                var eqipComponent = item.GetComponent<IComponent_GetEqupType>();

                List<InventoryItem> eqippableItems = this.eqipInventory.FindItems(InventoryItemFlags.Eqippable);

                for (int i=0;i<eqippableItems.Count;i++)
                {
                    var component = eqippableItems[i].GetComponent<IComponent_GetEqupType>();

                    if (component.Type == eqipComponent.Type)
                    {
                        this.inventory.AddItem(eqippableItems[i]);
                        this.eqipInventory.RemoveItem(eqippableItems[i]);
                        break;
                    }
                }
                this.eqipInventory.AddItem(item);
                this.inventory.RemoveItem(item);
            }
        }

    }
}