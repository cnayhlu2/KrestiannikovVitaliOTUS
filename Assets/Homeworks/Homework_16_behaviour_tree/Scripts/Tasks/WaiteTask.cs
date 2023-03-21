using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Tasks
{
    public class WaiteTask : Task
    {
        [SerializeField] private float waiteTime;

        private Coroutine coroutine;
        
        [Button]
        public void SetDuration(float time)
        {
            this.waiteTime = time;
        }
        
        protected override void Do()
        {
            this.coroutine = StartCoroutine(WaiteCoroutine());
        }

        protected override void OnCansel()
        {
            if(this.coroutine!=null)
                StopCoroutine(this.coroutine);
            this.coroutine = null;
        }

        private IEnumerator WaiteCoroutine()
        {
            yield return new WaitForSeconds(this.waiteTime);
            this.coroutine = null;
            this.Complete(true);
        }
    }
}