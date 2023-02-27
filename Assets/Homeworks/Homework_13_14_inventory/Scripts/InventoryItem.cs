using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Homeworks.Homework_13_14_inventory
{
    public sealed class InventoryItem
    {
        [SerializeField] private readonly string name;
        [SerializeField] private readonly InventoryItemFlags flags;
        [SerializeField] private readonly InventoryItemMetadata metadata;

        public string Name => this.name;
        public InventoryItemFlags Flags => this.flags;
        public InventoryItemMetadata Metadata => this.metadata;

        [SerializeReference] private readonly object[] components;

        public InventoryItem(string name, InventoryItemFlags flags, InventoryItemMetadata metadata,params object[] components)
        {
            this.name = name;
            this.flags = flags;
            this.metadata = metadata;
            this.components = components;
        }

        public T GetComponent<T>()
        {
            for (int i = 0; i < this.components.Length; i++)
            {
                if (this.components[i] is T result)
                {
                    return result;
                }
            }

            throw new Exception($"{typeof(T)} is not found");
        }
    }
}