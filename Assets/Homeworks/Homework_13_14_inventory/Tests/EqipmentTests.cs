using System;
using Homeworks.Homework_13_14_inventory;
using Homeworks.Homework_13_14_inventory.Eqip;
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

    [Test]
    public void TestEquipHead()
    {
        //ARRANGE: началное состояние системы
        object[] components = new object[1];
        Component_EquipType component = new Component_EquipType();
        component.SetType(EquipType.HEAD);
        InventoryItem head = new InventoryItem("Head", InventoryItemFlags.Eqippable, null);

        Inventory inventory = new();
        inventory.AddItem(head);

        //ACT - одеваем на голову шлем
        HeadEqipper headEqipper = new HeadEqipper();
        headEqipper.EqipItem(inventory, head.Name);

        //ASSERT проверяем действие
        Assert.False(inventory.TryFindItem(InventoryItemFlags.Eqippable, out InventoryItem _));
        Assert.False(inventory.IsItemExists(head.Name));
    }


    [Test]
    public void TestEquipTwoHead()
    {
        //ARRANGE: началное состояние системы
        object[] components = new object[1];
        Component_EquipType component = new Component_EquipType();
        component.SetType(EquipType.HEAD);
        InventoryItem head1 = new InventoryItem("Head1", InventoryItemFlags.Eqippable, null);
        InventoryItem head2 = new InventoryItem("Head1", InventoryItemFlags.Eqippable, null);

        Inventory inventory = new();
        inventory.AddItem(head1);
        inventory.AddItem(head2);

        //ACT - одеваем на голову шлем
        HeadEqipper headEqipper = new HeadEqipper();
        headEqipper.EqipItem(inventory, head1.Name);
        headEqipper.EqipItem(inventory, head2.Name);

        //ASSERT проверяем действие
        Assert.False(inventory.IsItemExists(head2.Name));
        Assert.True(inventory.IsItemExists(head1.Name));
    }
}