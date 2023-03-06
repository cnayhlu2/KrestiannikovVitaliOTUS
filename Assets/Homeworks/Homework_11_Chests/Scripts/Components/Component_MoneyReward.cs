using UnityEngine;

namespace Homework_11_Chests.Components
{
    public class Component_MoneyReward : IComponent_MoneyReward
    {
        [SerializeField] private int money;

        public int Money => this.money;
    }
}