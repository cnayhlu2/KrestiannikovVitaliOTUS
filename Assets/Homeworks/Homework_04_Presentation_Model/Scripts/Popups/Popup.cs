using System;
using UnityEngine;


namespace Homework_Presentation_Model.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        private Action<Popup> OnClose;

        public void Show(object args = null, Action<Popup> OnClose = null)
        {
            this.OnClose = OnClose;
            this.OnShow(args);
        }

        public void Hide()
        {
            this.OnHide();
        }

        public void RequestClose()
        {
            Debug.Log(nameof(RequestClose));
            OnClose?.Invoke(this);
        }

        protected virtual void OnShow(object args)
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}