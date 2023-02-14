using System.Collections.Generic;
using GameSystem;
using UnityEngine;

namespace Homework_11_Chests
{
    public class RewardManager : MonoBehaviour, IGameConstructElement
    {
        [SerializeReference] private List<ITakeRewardCompletor> completors = new();

        public void TakeReward(Reward reward)
        {
            foreach (var completor in completors)
            {
                completor.TakeReward(reward);
            }
        }

        public void ConstructGame(IGameContext context)
        {
            foreach (var completor in completors)
            {
                if (completor is IGameConstructElement constructElement)
                {
                    constructElement.ConstructGame(context);
                }
            }
        }
    }
}