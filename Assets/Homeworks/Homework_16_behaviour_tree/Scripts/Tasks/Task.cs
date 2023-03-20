using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Tasks
{
    public abstract class Task: MonoBehaviour
    {
        [ShowInInspector,ReadOnly]private bool isPlaying;
        private ITaskCallback callback;

        [Button]
        public void Do(ITaskCallback callback)
        {
            if(this.isPlaying)
                return;

            this.isPlaying = true;
            this.callback = callback;
            this.Do();
        }

        [Button]
        public void Cansel()
        {
            if(!this.isPlaying)
                return;

            this.isPlaying = false;
            this.callback = null;
            this.OnCansel();
        }

        protected abstract void Do();

        protected abstract void OnCansel();

        protected void Complete(bool saccess)
        {
            this.isPlaying = false;
            var callback = this.callback;
            if(callback!=null)
                callback.OnComplete(this, saccess);
            this.callback = null;
        }
    }
}