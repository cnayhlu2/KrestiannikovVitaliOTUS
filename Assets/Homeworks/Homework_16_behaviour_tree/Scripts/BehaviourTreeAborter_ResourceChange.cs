using System;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree
{
    public class BehaviourTreeAborter_ResourceChange : MonoBehaviour
    {
        [SerializeField] private UnityBehaviourTree behaviourTree;
        [SerializeField] private UnityBlackboard blackboard;
        
        [Space] [BlackboardKey] [SerializeField]
        private string resourceLocationKey;

        private void OnEnable()
        {
            this.blackboard.OnVariableAdded += this.OnVariableChanged;
            this.blackboard.OnVariableChanged += this.OnVariableChanged;
            this.blackboard.OnVariableRemoved += this.OnVariableChanged;
        }

        private void OnDisable()
        {
            this.blackboard.OnVariableAdded -= this.OnVariableChanged;
            this.blackboard.OnVariableChanged -= this.OnVariableChanged;
            this.blackboard.OnVariableRemoved -= this.OnVariableChanged;
        }

        private void OnVariableChanged(string key, object value)
        {
            Debug.Log($"key change : {key} my key {this.resourceLocationKey}");
            Debug.Log($"is equals {(this.resourceLocationKey == key)}");
            if (this.resourceLocationKey == key)
            {
                this.behaviourTree.Abort();
            }
        }
    }
}