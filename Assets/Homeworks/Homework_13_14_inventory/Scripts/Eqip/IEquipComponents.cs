using System;

namespace Homeworks.Homework_13_14_inventory.Eqip
{
    public interface IComponent_Equip
    {
        void Equip();
    }

    public interface IComponent_OnEquipped
    {
        event Action OnEquipped;
    }
    
    public interface IComponent_GetEqupType
    {
        EquipType Type { get; }
    }
}