using UnityEngine;

namespace Homeworks.Homework_13_14_inventory
{
    [CreateAssetMenu(menuName = nameof(InventoryItemConfig),
        fileName = "Homework/inventory/Create" + nameof(InventoryItemConfig))]
    public class InventoryItemConfig : ScriptableObject
    {
        public InventoryItem Prototype;
    }
}