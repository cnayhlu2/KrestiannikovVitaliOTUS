using GameSystem;
using Homework_11_Chests.Components;
using Homework_Presentation_Model.Storage;
using UnityEngine;
using GameContext = GameElements.GameContext;

namespace Homework_11_Chests
{
    public class MoneyRewardCompleter : ITakeRewardCompletor, IGameConstructElement
    {
        private MoneyStorage moneyStorage;


        void ITakeRewardCompletor.TakeReward(Reward reward)
        {
            if (reward.TryGetComponent<IComponent_MoneyReward>(out IComponent_MoneyReward moneyReward))
            {
                this.moneyStorage.EarnMoney(moneyReward.Money);
            }
        }

        public void ConstructGame(IGameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}