using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Homework_Presentation_Model.Popups
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private List<PopupHolder> allPopups = new();

        private Dictionary<PopupType, Popup> activePopups = new();

        private void Awake()
        {
            allPopups.ForEach(popupHolder => popupHolder.popup.gameObject.SetActive(false));
        }

        [Button]
        public void ShowPopup(PopupType popupType, object args = null)
        {
            if (IsPopupActive(popupType))
                return;

            Popup popup = FindPopup(popupType);
            popup.Show(args, HidePopup);
            popup.gameObject.SetActive(true);
            activePopups.Add(popupType, popup);
        }

        private bool IsPopupActive(PopupType type) => this.activePopups.ContainsKey(type);

        private PopupType FindPopupType(Popup popup)
        {
            foreach (var popupHolder in allPopups)
            {
                if (ReferenceEquals(popupHolder.popup, popup))
                {
                    return popupHolder.type;
                }
            }

            throw new Exception($"popup name {popup.name} is not found in all Popups");
        }

        private Popup FindPopup(PopupType type)
        {
            foreach (var holder in allPopups)
            {
                if (holder.type == type)
                {
                    return holder.popup;
                }
            }

            throw new Exception($" popup type {type} is not found in all Popups");
        }


        private void HidePopup(Popup popup)
        {
            PopupType popupType = FindPopupType(popup);

            if (!IsPopupActive(popupType))
                return;

            popup.Hide();
            popup.gameObject.SetActive(false);
            activePopups.Remove(popupType);
        }
    }

    [Serializable]
    public struct PopupHolder
    {
        public PopupType type;
        public Popup popup;
    }
}