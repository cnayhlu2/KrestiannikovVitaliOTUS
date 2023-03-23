using System.Collections.Generic;
using AI.Blackboards;
using AI.Iterators;
using AI.Waypoints;
using Entities;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree
{
    public class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField] private UnityBlackboard blackboard;

        [Space]
        [BlackboardKey] 
        [SerializeField]
        private string unitKey;
        [SerializeField] private UnityEntity unit;
        
        [Space]
        [BlackboardKey]
        [SerializeField]
        private string stoppingDistanceKey;

        [SerializeField]
        private float stoppingDistance;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string waypointsKey;

        [SerializeField]
        private WaypointsPath waypoints;
        
        [Space]
        [SerializeField]
        [BlackboardKey]
        private string patrolDelayKey;
        
        [SerializeField]
        private float patrolDelay = 1.0f;


        [SerializeField,Space, BlackboardKey] private string shopPositionKey;
        [SerializeField] private Transform shopPosition;
        
        private void Awake()
        {
            this.blackboard.AddVariable(this.unitKey, this.unit);
            this.blackboard.AddVariable(this.stoppingDistanceKey, this.stoppingDistance);
            this.blackboard.AddVariable(this.waypointsKey, this.CreateWaypointsIterator());
            this.blackboard.AddVariable(this.patrolDelayKey, this.patrolDelay);
            this.blackboard.AddVariable(this.shopPositionKey, this.shopPosition.position);
        }

        private IEnumerator<Vector3> CreateWaypointsIterator()
        {
            IEnumerator<Vector3> iterator;
            Vector3[] waypoints = this.waypoints.GetPositionPoints().ToArray();
            iterator = IteratorFactory.CreateIterator(IteratorMode.CIRCLE, waypoints);
            return iterator;
        }
        
        
    }
}