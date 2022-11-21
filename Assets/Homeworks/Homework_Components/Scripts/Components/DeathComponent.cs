using Elementary;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Homework_Components.Components
{
    public class DeathComponent : MonoBehaviour, IOnDeathComponent
    {
        public event Action OnDeath
        {
            add { this.eventReceiver.OnEvent += value; }
            remove { this.eventReceiver.OnEvent -= value; }
        }

        [SerializeField, Required] private EventReceiver eventReceiver;

    }
}