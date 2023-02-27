using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_13_14_inventory
{
    /// <summary>
    /// data for ui
    /// </summary>
    [Serializable]
    public sealed class InventoryItemMetadata
    {
        [SerializeField] private string title;

        [SerializeField] [TextArea] private string description;

        [SerializeField] [PreviewField] private Sprite icon;
    }
}