using System.Collections.Generic;
using Elementary;
using Homework_06_Conveyor.Core;
using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorMechanic : MonoBehaviour
    {
        [SerializeField] private List<ResourceType> inputResources = new();
        [SerializeField] private List<ResourceType> outputResources = new();

        [SerializeField] private ResourceStorage resourceStorage;
        [SerializeField] private TimerBehaviour worker;

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
            foreach (var inputResource in inputResources)
            {
                resourceStorage.Unload(inputResource, 1);
            }

            worker.ResetTime();
            worker.Play();
        }


        private bool CanWork()
        {
            foreach (var inputResource in inputResources)
                if (!resourceStorage.CanUnload(inputResource))
                    return false;
            foreach (var outputResource in outputResources)
                if (!resourceStorage.CanLoad(outputResource))
                    return false;
            if (worker.IsPlaying)
                return false;

            return true;
        }

        private void OnWorkFinish()
        {
            foreach (var outputResource in outputResources)
                resourceStorage.TryLoad(outputResource, 1);
        }
    }
}