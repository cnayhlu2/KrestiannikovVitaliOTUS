using System;
using AI.Blackboards;
using Entities;
using Game.GameEngine.GameResources;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks.Homework_16_behaviour_tree
{
    public class SensorObserver_Resource : MonoBehaviour
    {
        [SerializeField] private UnityBlackboard blackboard;
        [Space, SerializeField, BlackboardKey] private string resourceKey;
        [SerializeField, BlackboardKey] private string resourceTypeKey;
        [SerializeField, BlackboardKey] private string unitKey;


        private IComponent_ResourceSource resourceComponent;
        private void Start()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                throw new Exception("do not found unit");
            }
            resourceComponent = unit.Get<IComponent_ResourceSource>();
            resourceComponent.OnResourcesChanged += OnResourcesChanged;
        }

        private void OnDestroy()
        {
            if (this.resourceComponent != null)
            {
                this.resourceComponent.OnResourcesChanged -= OnResourcesChanged;
            }
        }

        private void OnResourcesChanged(ResourceType resourceType, int count)
        {
            Debug.Log($"on resource changeds: {resourceType} count : {count}");
            
            if (this.blackboard.HasVariable(this.resourceTypeKey))
            {
                if(this.blackboard.GetVariable<ResourceType>(this.resourceTypeKey)!=resourceType)
                    return;
            }
            else
            {
                this.blackboard.AddVariable(this.resourceTypeKey, resourceType);
            }

            if (this.blackboard.HasVariable(this.resourceKey))
            {
                this.blackboard.ChangeVariable(this.resourceKey,count);
            }
            else
            {
                this.blackboard.AddVariable(this.resourceKey,count);
            }
            
        }
    }
}