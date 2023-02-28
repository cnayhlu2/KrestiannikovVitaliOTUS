using System;
using System.Collections.Generic;
using Homeworks.Homework_13_14_inventory.Eqip;

namespace Homeworks.Homework_13_14_inventory
{
    public sealed class EqipmentManager
    {
        private Inventory eqipInventory = new();


        public void EqipItem(Inventory inventory, string itemName)
        {
            if (inventory.TryFindItem(itemName, out InventoryItem item) &&
                item.FlagsExists(InventoryItemFlags.Eqippable))
            {
                var equpComponent = item.GetComponent<IComponent_GetEqupType>();
                
                inventory.RemoveItem(item);
            }
        }
    }
}