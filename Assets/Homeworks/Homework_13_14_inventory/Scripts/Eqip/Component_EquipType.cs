using System;
using UnityEngine;

namespace Homeworks.Homework_13_14_inventory.Eqip
{
    [Serializable]
    public sealed class Component_EquipType : IComponent_GetEqupType
    {
        public EquipType Type
        {
            get { return this.type; }
        }

        [SerializeField]
        private EquipType type;
    }
}