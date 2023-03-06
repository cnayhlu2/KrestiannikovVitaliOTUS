namespace Homeworks.Homework_13_14_inventory
{
    public static class InventoryExtensions
    {
        public static bool FlagsExists(this InventoryItem item, InventoryItemFlags flags)
        {
            return (item.Flags & flags) == flags;
        }
        
    }
}