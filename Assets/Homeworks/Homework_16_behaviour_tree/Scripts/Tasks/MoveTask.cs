
using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Tasks
{
    public class MoveTask : Task
    {
        [ShowInInspector,ReadOnly] private IEntity entity;
        [ShowInInspector,ReadOnly] private Vector3 movePosition;
        [ShowInInspector,ReadOnly] private float stoppingDistance;
        
        private Coroutine moveCoroutine;

        [Button]
        public void SetEntity(IEntity entity)
        {
            this.entity = entity;
        }

        [Button]
        public void SetMovePosition(Vector3 movePosition)
        {
            this.movePosition = movePosition;
        }
        
        [Button]
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.stoppingDistance = stoppingDistance;
        }
        
        protected override void Do()
        {
            this.moveCoroutine = StartCoroutine(this.MoveRoutine());
        }

        protected override void OnCansel()
        {
            if (this.moveCoroutine != null)
                StopCoroutine(this.moveCoroutine);
            this.moveCoroutine = null;
        }
        
        private IEnumerator MoveRoutine()
        {
            var positonComponent = this.entity.Get<IComponent_GetPosition>();
            var moveComponent = this.entity.Get<IComponent_MoveInDirection>();
            // var period = new WaitForFixedUpdate();

            while (true)
            {
                var distanceVector = this.movePosition - positonComponent.Position;
                var distance = distanceVector.magnitude;
                if (distance <= this.stoppingDistance)
                {
                    yield return null;
                    break;
                }

                var direction = distanceVector.normalized;
                moveComponent.Move(direction);

                yield return null;
            }
            
            this.moveCoroutine = null;
            this.Complete(true);
        }
    }
}