using System;
using UnityEngine;

namespace Homework_08_Interaction.Components
{
    public class Component_Battle : MonoBehaviour, IComponent_Battle
    {
        public event Action<BattleOperation> OnStarted
        {
            add { this.battleMechanics.OnStarted += value; }
            remove { this.battleMechanics.OnStarted -= value; }
        }

        public event Action<BattleOperation> OnFinished
        {
            add { this.battleMechanics.OnFinished += value; }
            remove { this.battleMechanics.OnFinished -= value; }
        }

        public bool IsOnBattle => this.battleMechanics.IsOnBattle;

        [SerializeField] private BattleMechanics battleMechanics;

        public bool CanStartBattle(BattleOperation operation) => this.battleMechanics.CanStartBattle(operation);

        public void StartBattle(BattleOperation operation)
        {
            this.battleMechanics.StartBattle(operation);
        }

        public void StopBattle()
        {
            this.battleMechanics.StopBattle();
        }
    }
}