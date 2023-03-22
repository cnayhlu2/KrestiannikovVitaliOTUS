using AI.Blackboards;
using Elementary;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks.Homework_16_behaviour_tree
{
    public class SensorObserver_Resources : CollidersSensorController
    {
        [Space]
        [SerializeField]
        private UnityBlackboard blackboard;

        [FormerlySerializedAs("movePositionKey")]
        [FormerlySerializedAs("resourcePosition")]
        [BlackboardKey]
        [SerializeField]
        private string resourceLocationKey;
        
        private Transform resource;
        
        protected override void OnCollidersUpdated(Collider[] buffer, int size)
        {
            if (this.resource == null)
            {
                if (this.FindTarget(buffer, size, out this.resource))
                {
                    Debug.Log("Detect Enemy");
                    this.blackboard.AddVariable(this.resourceLocationKey, this.resource);
                }
            }
            else
            {
                if (!this.IsTargetExists(buffer, size, this.resource))
                {
                    Debug.Log("Undetect Enemy");
                    this.blackboard.RemoveVariable(this.resourceLocationKey);
                    this.resource = null;
                }
            }
        }
        
        private bool FindTarget(Collider[] buffer, int size, out Transform target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                target = collder.transform;
                return true;
            }
            target = default;
            return false;
        }
        
        private bool IsTargetExists(Collider[] buffer, int size, Transform target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                if (collder.transform == target)
                    return true;
            }

            return false;
        }
    }
}