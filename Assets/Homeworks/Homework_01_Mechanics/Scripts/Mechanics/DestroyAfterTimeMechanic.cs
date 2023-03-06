using Elementary;
using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class DestroyAfterTimeMechanic : MonoBehaviour
    {
        [SerializeField, Required] private MonoTimer timer;
        [SerializeField, Required] private MonoBoolVariable state;

        private void OnEnable()
        {
            timer.OnFinished += Destroy;
        }

        private void Start()
        {
            timer.Play();
        }
        
        private void OnDisable()
        {
            timer.OnFinished -= Destroy;
        }

        private void Destroy()
        {
            state.SetTrue();
        }
    }
}