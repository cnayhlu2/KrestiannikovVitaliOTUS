using System;

namespace Homeworks.Homework_13_14_inventory
{
    [Flags]
    public enum InventoryItemFlags
    {
        None = 0,
        Stackable = 1,
        Unstackable = 2,
        Eqippable = 4,
        Effectible = 8,
    }
}