using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move In Direction Mechanics")]
    public sealed class UMoveInDirectionMechanics : MonoBehaviour
    {
        [SerializeField] private WalkableSurfaceHolder surfaceHolder;

        [SerializeField] private UMoveInDirectionEngine moveEngine;

        [SerializeField] private UTransformEngine transformEngine;

        [SerializeField] private FloatAdapter moveSpeed;

        private void FixedUpdate()
        {
            if (this.moveEngine.IsMoving)
            {
                this.MoveTransform(this.moveEngine.Direction);
            }
        }

        private void MoveTransform(Vector3 direction)
        {
            var velocity = direction * (this.moveSpeed.Value * Time.fixedDeltaTime);
            if (this.surfaceHolder.IsSurfaceExists)
            {
                this.MoveBySurface(velocity);
            }
            else
            {
                Debug.Log($"MoveTransform {direction}");
                this.transformEngine.MovePosition(velocity);
            }

            this.transformEngine.LookInDirection(direction);
        }

        private void MoveBySurface(Vector3 velocity)
        {
            var nextPosition = this.transformEngine.WorldPosition + velocity;
            var surface = this.surfaceHolder.Surface;
            if (surface.IsAvailablePosition(nextPosition))
            {
                this.transformEngine.SetPosiiton(nextPosition);
            }
            else if (surface.FindAvailablePosition(nextPosition, out var clampedPosition))
            {
                this.transformEngine.SetPosiiton(clampedPosition);
            }
        }
    }
}