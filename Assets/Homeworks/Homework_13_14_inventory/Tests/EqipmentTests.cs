using Homeworks.Homework_13_14_inventory;
using NUnit.Framework;

public class EqipmentTests
{
    [Test]
    public void CheckAddItem()
    {
        //ARRANGE: началное состояние системы
        InventoryItem boots = new InventoryItem("Boots", InventoryItemFlags.Eqippable, null);
        Inventory inventory = new();

        //ACT логика котору нужно проверить
        inventory.AddItem(boots);

        //ASSERT проверяем действие

        Assert.True(inventory.TryFindItem(InventoryItemFlags.Eqippable, out InventoryItem _));
        Assert.True(inventory.IsItemExists(boots.Name));
        Assert.True(inventory.CountItems(InventoryItemFlags.Eqippable) == 1);
        Assert.True(inventory.CountItems(boots.Name) == 1);
    }
}