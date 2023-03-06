using System;
using UnityEngine;

namespace Homeworks.Homework_13_14_inventory
{
    [Serializable]
    public sealed class InventoryItem
    {
        [SerializeField] private string name;
        [SerializeField] private InventoryItemFlags flags;
        [SerializeField] private InventoryItemMetadata metadata;
        [SerializeReference] private object[] components;

        public string Name => this.name;
        public InventoryItemFlags Flags => this.flags;
        public InventoryItemMetadata Metadata => this.metadata;

        public InventoryItem(string name, InventoryItemFlags flags, InventoryItemMetadata metadata,
            params object[] components)
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

        public InventoryItem Clone()
        {
            return new InventoryItem(this.name,
                this.flags,
                this.metadata,
                this.CloneComponents());
        }

        private object[] CloneComponents()
        {
            var count = this.components.Length;
            var result = new object[count];
            for (int i = 0; i < result.Length; i++)
            {
                var component = this.components[i];
                if (component is ICloneable cloneable)
                {
                    component = cloneable.Clone();
                }

                result[i] = this.components[i];
            }

            return result;
        }
    }
}