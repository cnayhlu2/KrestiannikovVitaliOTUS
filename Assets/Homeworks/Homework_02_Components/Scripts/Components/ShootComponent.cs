using Elementary;
using Homework_Components.Components;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Assets.Homeworks.Homework_Components.Scripts.Components
{
    public class ShootComponent : MonoBehaviour, IShootComponent
    {
        [SerializeField, Required] private EventReceiver shootReceiver;

        public void Shoot()
        {
            this.shootReceiver.Call();
        }
    }
}