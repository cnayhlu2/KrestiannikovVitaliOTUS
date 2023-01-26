using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Homework_08_Interaction
{
    public class BattleMechanics : MonoBehaviour
    {
        public event Action<BattleOperation> OnStarted;

        public event Action<BattleOperation> OnFinished;

        public bool IsOnBattle => this.operation != null;
        public BattleOperation CurrentOperation => this.operation;

        private BattleOperation operation;

        public bool CanStartBattle(BattleOperation operation)
        {
            if (IsOnBattle)
                return false;
            return true;
        }

        public void StartBattle(BattleOperation operation)
        {
            if (!CanStartBattle(operation))
                return;
            this.operation = operation;
            this.OnStarted?.Invoke(operation);
        }

        public void StopBattle()
        {
            if (!IsOnBattle)
                return;
            BattleOperation finishOperation = this.operation;
            this.operation = null;
            this.OnFinished?.Invoke(finishOperation);
        }
    }
}