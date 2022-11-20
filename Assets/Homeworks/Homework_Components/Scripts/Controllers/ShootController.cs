using Entities;
using Homework_Components.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Components
{
    public sealed class ShootController : MonoBehaviour
    {
        [SerializeField, Required] private UnityEntity attacker;
        [SerializeField, Required] private MouseInput mouseInput;

        private IShootComponent shootComponent;

        private void Awake()
        {
            shootComponent = attacker.Get<IShootComponent>();
        }

        private void OnEnable()
        {
            mouseInput.OnMousePress += MousePress;
        }

        private void OnDisable()
        {
            mouseInput.OnMousePress -= MousePress;
        }

        private void MousePress(Vector3 position)
        {
            Shoot();
        }


        private void Shoot()
        {
            shootComponent.Shoot();
        }

    }
}