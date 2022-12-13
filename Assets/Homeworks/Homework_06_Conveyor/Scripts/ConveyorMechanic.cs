using Elementary;
using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorMechanic : MonoBehaviour
    {
        [SerializeField] private LimitedIntBehavior firstStorage;
        [SerializeField] private LimitedIntBehavior secondStorage;
        [SerializeField] private TimerBehaviour worker;

        [SerializeField] private LimitedIntBehavior outputStorage;

        private void OnEnable()
        {
            this.worker.OnFinished += OnWorkFinish;
        }

        private void OnDisable()
        {
            this.worker.OnFinished -= OnWorkFinish;
        }

        private void Update()
        {
            if (CanWork())
            {
                StartWork();
            }
        }

        private void StartWork()
        {
            this.firstStorage.Value--;
            this.secondStorage.Value--;
            worker.ResetTime();
            worker.Play();
        }


        private bool CanWork()
        {
            if (firstStorage.Value == 0)
                return false;
            if (secondStorage.Value == 0)
                return false;
            if (outputStorage.IsLimit)
                return false;
            if (worker.IsPlaying)
                return false;

            return true;
        }

        private void OnWorkFinish()
        {
            this.outputStorage.Value++;
        }
    }
}