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
        Component_EquipType component = new Component_EquipType();
        component.SetType(EquipType.HEAD);
        InventoryItem head = new InventoryItem("Head", InventoryItemFlags.Eqippable, null,component);

        Inventory eqipInventory = new();
        Inventory inventory = new();
        inventory.AddItem(head);
        
        EqipmentManager eqipmentManager = new EqipmentManager();
        eqipmentManager.Construct(eqipInventory,inventory);

        //ACT - одеваем на голову шлем
        eqipmentManager.EqipItem(head.Name);

        //ASSERT проверяем действие
        Assert.False(inventory.TryFindItem(InventoryItemFlags.Eqippable, out InventoryItem _));
        Assert.False(inventory.IsItemExists(head.Name));
    }


    [Test]
    public void TestEquipTwoHead()
    {
        //ARRANGE: началное состояние системы
        Component_EquipType component = new Component_EquipType();
        component.SetType(EquipType.HEAD);
        InventoryItem head1 = new InventoryItem("Head1", InventoryItemFlags.Eqippable,null, component);
        InventoryItem head2 = new InventoryItem("Head2", InventoryItemFlags.Eqippable,null, component);

        Inventory inventory = new();
        inventory.AddItem(head1);
        inventory.AddItem(head2);
        
        Inventory eqipInventory = new();
        
        EqipmentManager eqipmentManager = new EqipmentManager();
        eqipmentManager.Construct(eqipInventory,inventory);
        
        //ACT - одеваем на голову шлем
        eqipmentManager.EqipItem(head1.Name);
        eqipmentManager.EqipItem(head2.Name);

        //ASSERT проверяем действие
        Assert.False(inventory.IsItemExists(head2.Name));
        Assert.True(inventory.IsItemExists(head1.Name));
    }
    
    [Test]
    public void TestEquipFull()
    {
        //ARRANGE: началное состояние системы
        Component_EquipType component = new Component_EquipType();
        component.SetType(EquipType.HEAD);
        InventoryItem head = new InventoryItem("Head", InventoryItemFlags.Eqippable,null, component);
        component = new Component_EquipType();
        component.SetType(EquipType.BODY);
        InventoryItem armor = new InventoryItem("armor", InventoryItemFlags.Eqippable,null, component);
        component = new Component_EquipType();
        component.SetType(EquipType.LEGS);
        InventoryItem boots = new InventoryItem("boots", InventoryItemFlags.Eqippable,null, component);
        component = new Component_EquipType();
        component.SetType(EquipType.HANDS);
        InventoryItem gloves = new InventoryItem("gloves", InventoryItemFlags.Eqippable,null, component);

        Inventory inventory = new();
        inventory.AddItem(head);
        inventory.AddItem(armor);
        inventory.AddItem(boots);
        inventory.AddItem(gloves);
        
        Inventory eqipInventory = new();
        
        EqipmentManager eqipmentManager = new EqipmentManager();
        eqipmentManager.Construct(eqipInventory,inventory);
        
        //ACT - одеваем на голову шлем
        eqipmentManager.EqipItem(head.Name);
        eqipmentManager.EqipItem(armor.Name);
        eqipmentManager.EqipItem(boots.Name);
        eqipmentManager.EqipItem(gloves.Name);

        //ASSERT проверяем действие
        Assert.True(eqipInventory.CountItems()==4);
        Assert.True(inventory.CountItems()==0);
    }
}