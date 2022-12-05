using System;
using System.Collections.Generic;
using UnityEngine;


namespace Homework_Presentation_Model.Popups
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private PopupHolder[] allPopups;
        
        private Dictionary<PopupType, Popup> popups = new();



        private void HidePopu(Popup popup)
        {
            
            
        }
        
    }

    [Serializable]
    public struct PopupHolder
    {
        public PopupType type;
        public Popup popup;
    }
}


