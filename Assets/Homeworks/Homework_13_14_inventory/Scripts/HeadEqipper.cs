namespace Homeworks.Homework_13_14_inventory
{
    public sealed class HeadEqipper
    {
        public void EqipItem(Inventory inventory,string itemName)
        {
            if (inventory.TryFindItem(itemName, out InventoryItem item))
            {
                if (item.FlagsExists(InventoryItemFlags.Eqippable))
                {
                    inventory.RemoveItem(item);
                }
            }
        }
        
        
    }
}