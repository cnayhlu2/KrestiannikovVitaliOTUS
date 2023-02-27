using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_13_14_inventory
{
    /// <summary>
    /// data for ui
    /// </summary>
    public sealed class InventoryItemMetadata
    {
        [SerializeField]
        public string Title;

        [SerializeField]
        [TextArea]
        private string description;

        [SerializeField]
        [PreviewField]
        private Sprite icon;
    }
}