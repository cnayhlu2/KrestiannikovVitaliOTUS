using Elementary;
using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorProgressAdapter : MonoBehaviour
    {
        [SerializeField] private ConveyorProgressView view;
        [SerializeField] private TimerBehaviour conveyorWorker;

        private void OnEnable()
        {
            view.SetVisible(false);
            this.conveyorWorker.OnStarted += OnStart;
            this.conveyorWorker.OnFinished += OnFinish;
        }

        private void OnDisable()
        {
            this.conveyorWorker.OnStarted -= OnStart;
            this.conveyorWorker.OnFinished -= OnFinish;
        }

        private void OnStart()
        {
            this.view.SetVisible(true);
            this.conveyorWorker.OnTimeChanged += OnTimeChange;
        }

        private void OnFinish()
        {
            this.view.SetVisible(false);
            this.conveyorWorker.OnTimeChanged -= OnTimeChange;
        }

        private void OnTimeChange()
        {
            this.view.SetProgress(this.conveyorWorker.Progress);
        }
    }
}