using Entities;
using GameElements;
using Homework_Components.Components;
using Homework_Game_Context.GameContext;
using UnityEngine;

namespace Homework_Components
{
    public sealed class ShootController : MonoBehaviour, 
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private MouseInput mouseInput;

        private IShootComponent shootComponent;

        private void MousePress(Vector3 position)
        {
            Shoot();
        }

        private void Shoot()
        {
            shootComponent.Shoot();
        }

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.mouseInput = context.GetService<MouseInput>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            shootComponent = context.GetService<ICharacterService>().GetCharacter().Get<IShootComponent>();
            mouseInput.OnMousePress += MousePress;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            mouseInput.OnMousePress -= MousePress;
        }
    }
}