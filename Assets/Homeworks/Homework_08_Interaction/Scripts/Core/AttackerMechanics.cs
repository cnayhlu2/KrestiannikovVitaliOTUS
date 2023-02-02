using System;
using Elementary;
using Homework_08_Interaction.Components;
using Homework_Components.Components;
using UnityEngine;

namespace Homework_08_Interaction
{
    public class AttackerMechanics : MonoBehaviour

    {
        [SerializeField] private BattleMechanics battle;
        [SerializeField] private TimerBehaviour timer;
        [SerializeField] private BoolBehaviour isAttacking;

        private BattleOperation operation;

        private void OnEnable()
        {
            this.battle.OnStarted += this.OnBattleStarted;
            this.battle.OnFinished += this.OnBattleFinished;
            this.timer.OnFinished += this.OnAttackComplete;
        }

        private void OnDisable()
        {
            this.battle.OnStarted -= this.OnBattleStarted;
            this.battle.OnFinished -= this.OnBattleFinished;
            this.timer.OnFinished -= this.OnAttackComplete;
        }

        private void OnBattleStarted(BattleOperation obj)
        {
            this.operation = obj;
            StartAttack();
        }

        private void StartAttack()
        {
            this.timer.ResetTime();
            this.timer.Play();
            this.isAttacking.AssignTrue();
        }
        

        private void OnBattleFinished(BattleOperation obj)
        {
            this.timer.Stop();
            this.isAttacking.AssignFalse();
        }

        private void OnAttackComplete()
        {
            this.operation.Enemy.Get<ITakeDamageComponent>().TakeDamage(1);
            
            if (this.operation.Enemy.Get<IComponen_IsDeath>().IsDeath)
            {
                this.battle.CurrentOperation.isCompleted = true;
                this.battle.StopBattle();
                return;
            }
            StartAttack();
        }
    }
}