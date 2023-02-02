using Entities;
using GameElements;
using Homework_08_Interaction.Components;
using Homework_Game_Context.GameContext;
using UnityEngine;

namespace Homework_08_Interaction
{
    public class PlayerBattleController : MonoBehaviour, IGameReadyElement, IGameFinishElement, IGameInitElement
    {
        public bool IsOnBattle => this.playerBattle.IsOnBattle;
        private IComponent_Battle playerBattle;

        public void StartBattle(IEntity enemy)
        {
            if (!this.CanStartBattle(enemy, out BattleOperation operation))
            {
                Debug.Log("Can not start battle");
                return;
            }
            Debug.Log("Start Battle");
            this.playerBattle.StartBattle(operation);
        }

        public void CanselBattle()
        {
            if (this.IsOnBattle)
            {
                this.playerBattle.StopBattle();
                Debug.Log("Cansel Battle");
            }
        }

        private bool CanStartBattle(IEntity enemy, out BattleOperation operation)
        {
            operation = null;

            if (this.IsOnBattle)
                return false;

            if (enemy.Get<IComponen_IsDeath>().IsDeath)
                return false;

            operation = new BattleOperation(enemy);
            if (!this.playerBattle.CanStartBattle(operation))
                return false;
            return true;
        }


        private void OnBattleFinish(BattleOperation obj)
        {
            //что будем делать когда убьем цель
        }

        void IGameInitElement.InitGame(IGameContext context)
        {
            IEntity player = context.GetService<ICharacterService>().GetCharacter();
            this.playerBattle = player.Get<IComponent_Battle>();
        }

        void IGameReadyElement.ReadyGame(IGameContext context)
        {
            this.playerBattle.OnFinished += OnBattleFinish;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            this.playerBattle.OnFinished -= OnBattleFinish;
        }
    }
}