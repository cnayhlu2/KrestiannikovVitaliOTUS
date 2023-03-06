using System.Collections;
using System.Collections.Generic;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_15_AI.Agents
{
    public class MoveAgent : Agent
    {
        [ShowInInspector] private IEntity unit;
        [ShowInInspector] private float stoppingDistance;
        [ShowInInspector] private Vector3 targetPosition;

        private IComponent_GetPosition positionComponent;
        private IComponent_MoveInDirection moveComponent;

        private Coroutine patrolCoroutine;

        [Button]
        public void SetTargetPosition(Vector3 position)
        {
            this.targetPosition = position;
        }

        [Button]
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.stoppingDistance = stoppingDistance;
        }

        [Button]
        public void SetUnit(IEntity unit)
        {
            this.unit = unit;
            this.positionComponent = unit?.Get<IComponent_GetPosition>();
            this.moveComponent = unit?.Get<IComponent_MoveInDirection>();
        }

        protected override void OnPlay()
        {
            this.patrolCoroutine = this.StartCoroutine(this.DoRoutine());
        }

        protected override void OnStop()
        {
            if (this.moveComponent != null)
            {
                this.StopCoroutine(this.patrolCoroutine);
                this.patrolCoroutine = null;
            }
        }

        private IEnumerator DoRoutine()
        {
            while (true)
            {
                if (this.unit != null)
                {
                    this.DoMove();
                }
                yield return null;
            }
        }

        private void DoMove()
        {
            var myPosition = this.positionComponent.Position;
            var distanceVector = this.targetPosition - myPosition;

            var isReached = distanceVector.sqrMagnitude <= this.stoppingDistance * this.stoppingDistance;

            if (!isReached)
            {
                var moveDirection = distanceVector.normalized;
                this.moveComponent.Move(moveDirection);
            }
            else
            {
                this.Stop();
            }
        }
    }
}