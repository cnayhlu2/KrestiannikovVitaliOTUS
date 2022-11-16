using Elementary;
using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class ProjectileMovingMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField, Required] private TimerBehaviour timer;
        [SerializeField, Required] private BoolBehaviour state;
        [SerializeField] private float speed = 1f;

        private void Start()
        {
            timer.Play();
        }

        private void FixedUpdate()
        {
            positionEngine.Value += positionEngine.GetCurrentTransform.forward * speed*Time.deltaTime;
            if (positionEngine.IsOnGround)
                Destroy();
        }

        private void OnEnable()
        {
            timer.OnFinished += Destroy;
        }
        private void OnDisable()
        {
            timer.OnFinished -= Destroy;
        }

        private void Destroy()
        {
            state.AssignTrue();
        }
    }
}