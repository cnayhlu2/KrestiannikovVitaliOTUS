using UnityEngine;

namespace Homework_11_Chests.Components
{
    public class Component_RandomMoneyReward : IComponent_MoneyReward
    {
        [SerializeField] private int minMoney;
        [SerializeField] private int maxMoney;

        public int Money => Random.Range(minMoney, maxMoney);
    }
}