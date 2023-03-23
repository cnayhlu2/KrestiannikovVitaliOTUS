using Sirenix.OdinInspector;
using UnityEngine;

namespace AI.BTree
{
    public abstract class UnityBehaviourNode : MonoBehaviour, IBehaviourNode
    {
        [ShowInInspector, ReadOnly]
        public bool IsRunning { get; protected set; }

        private IBehaviourCallback callback;

        [Button]
        public void Run(IBehaviourCallback callback)
        {
            if (this.IsRunning)
            {
                return;
            }

            this.callback = callback;
            this.IsRunning = true;
            this.Run();
        }

        [Button]
        public void Abort()
        {
            Debug.Log($"Try abort is running {this.IsRunning}");
            
            if (!this.IsRunning)
            {
                return;
            }

            Debug.Log($"Abort");
            
            this.OnAbort();
            this.IsRunning = false;
            this.callback = null;
            this.OnEnd();
        }

        protected abstract void Run();

        protected void Return(bool success)
        {
            if (!this.IsRunning)
            {
                return;
            }

            this.IsRunning = false;
            this.OnReturn(success);
            this.OnEnd();
            this.InvokeCallback(success);
        }

        #region Callbacks

        protected virtual void OnReturn(bool success)
        {
        }

        protected virtual void OnAbort()
        {
        }

        protected virtual void OnEnd()
        {
        }

        #endregion

        private void InvokeCallback(bool success)
        {
            if (this.callback == null)
            {
                return;
            }

            var callback = this.callback;
            this.callback = null;
            callback.Invoke(this, success);
        }
    }
}