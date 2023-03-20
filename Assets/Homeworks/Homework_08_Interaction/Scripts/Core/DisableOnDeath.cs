using System.Collections.Generic;
using Elementary;
using UnityEngine;

namespace Homework_08_Interaction
{
    public class DisableOnDeath : MonoBehaviour
    {
        [SerializeField] private List<GameObject> targets;
        [SerializeField] private MonoBoolVariable isDeath;


        private void OnEnable()
        {
            this.isDeath.OnValueChanged += OnStateChange;
        }

        private void OnDisable()
        {
            this.isDeath.OnValueChanged -= OnStateChange;
        }

        private void OnStateChange(bool obj)
        {
            if (obj)
            {
                foreach (var target in targets)
                {
                    target.SetActive(false);
                }
            }
        }
    }
}