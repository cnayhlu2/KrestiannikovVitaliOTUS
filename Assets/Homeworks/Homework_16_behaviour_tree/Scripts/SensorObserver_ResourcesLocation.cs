using AI.Blackboards;
using Elementary;
using Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks.Homework_16_behaviour_tree
{
    public class SensorObserver_ResourcesLocation : CollidersSensorController
    {
        [Space]
        [SerializeField]
        private UnityBlackboard blackboard;

        [FormerlySerializedAs("movePositionKey")]
        [FormerlySerializedAs("resourcePosition")]
        [BlackboardKey]
        [SerializeField]
        private string resourceLocationKey;
        
        private IEntity resource;
        
        protected override void OnCollidersUpdated(Collider[] buffer, int size)
        {
            if (this.resource == null)
            {
                if (this.FindTarget(buffer, size, out this.resource))
                {
                    Debug.Log("Detect resource");
                    this.blackboard.AddVariable(this.resourceLocationKey, this.resource);
                }
            }
            else
            {
                if (!this.IsTargetExists(buffer, size, this.resource))
                {
                    Debug.Log("Undetect resource");
                    this.blackboard.RemoveVariable(this.resourceLocationKey);
                    this.resource = null;
                }
            }
        }
        
        private bool FindTarget(Collider[] buffer, int size, out IEntity target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                target = collder.GetComponent<IEntity>();
                return true;
            }
            target = default;
            return false;
        }
        
        private bool IsTargetExists(Collider[] buffer, int size, IEntity target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                if (collder.GetComponent<IEntity>() == target)
                    return true;
            }

            return false;
        }
    }
}