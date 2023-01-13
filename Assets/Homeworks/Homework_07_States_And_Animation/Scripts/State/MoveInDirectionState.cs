using System.Collections;
using Elementary;
using Homework_Mechanics.Engines;
using UnityEngine;
using MoveEngine = Homework_States.Core.MoveEngine;

namespace Homework_States.State
{
    public sealed class MoveInDirectionState : StateCoroutine
    {
        [SerializeField] private MoveEngine moveEngine;
        [SerializeField] private TransformEngine transformEngine;

        [SerializeField] private FloatAdapter speed;

        protected override IEnumerator Do()
        {
            WaitForFixedUpdate delay = new WaitForFixedUpdate();
            while (true)
            {
                yield return delay;
                this.Move();
            }
        }

        private void Move()
        {
            Vector3 velocity = moveEngine.Direction * speed.Value * Time.fixedDeltaTime;
            this.transformEngine.Position += velocity;
        }
    }
}