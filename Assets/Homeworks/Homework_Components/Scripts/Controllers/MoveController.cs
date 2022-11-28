using GameElements;
using Homework_Components.Components;
using Homework_Game_Context.GameContext;
using UnityEngine;

namespace Homework_Components
{
    public sealed class MoveController : MonoBehaviour,
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private MoveInput moveInput;

        private IMoveComponent moveComponent;

        private void Move(Vector3 direction)
        {
            moveComponent.Move(direction);
        }

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.moveInput = context.GetService<MoveInput>();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            this.moveComponent = context.GetService<ICharacterService>().GetCharacter().Get<IMoveComponent>();
            moveInput.OnMove += Move;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            moveInput.OnMove -= Move;
        }
    }
}