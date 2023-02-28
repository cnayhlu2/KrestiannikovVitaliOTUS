using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Homeworks.Homework_13_14_inventory
{
    //не должен знать о стуктуре inventory item
    public sealed class Inventory
    {
        public event Action<InventoryItem> OnTimeAdded;
        public event Action<InventoryItem> OnItemRemoved;

        [ShowInInspector] private readonly List<InventoryItem> items = new();

        public void InitItems(List<InventoryItem> items)
        {
            this.items.Clear();
            this.items.AddRange(items);
        }

        public void AddItem(InventoryItem item)
        {
            this.items.Add(item);
            this.OnTimeAdded?.Invoke(item);
        }

        public bool RemoveItem(InventoryItem item)
        {
            if (!this.items.Remove(item)) return false;
            this.OnItemRemoved?.Invoke(item);
            return true;
        }

        public bool RemoveItemLast(string itemName)
        {
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                if (items[i].Name == itemName)
                {
                    return this.RemoveItem(items[i]);
                }
            }

            return false;
        }

        public bool IsItemExists(InventoryItem item)
        {
            return this.items.Contains(item);
        }

        public bool IsItemExists(string name)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public List<InventoryItem> GetAllItems()
        {
            return this.items;
        }

        //по идее должно быть больше разных вариантов поиска

        public bool TryFindItem(InventoryItemFlags flags, out InventoryItem item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (items[i].FlagsExists(flags))
                {
                    item = this.items[i];
                    return true;
                }
            }

            item = default;
            return false;
        }

        public List<InventoryItem> FindItems(InventoryItemFlags flags)
        {
            List<InventoryItem> result = new();

            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].FlagsExists(flags))
                {
                    result.Add(this.items[i]);
                }
            }

            return result;
        }

        public int CountItems(InventoryItemFlags flags)
        {
            int result = 0;

            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].FlagsExists(flags))
                {
                    result++;
                }
            }

            return result;
        }

        public int CountItems(string name)
        {
            int result = 0;

            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].Name == name)
                {
                    result++;
                }
            }

            return result;
        }
    }
}