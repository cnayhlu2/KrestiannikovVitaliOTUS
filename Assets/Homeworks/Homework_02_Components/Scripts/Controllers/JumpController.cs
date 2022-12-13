using Entities;
using GameElements;
using Homework_Components.Components;
using Homework_Game_Context.GameContext;
using UnityEngine;
using IGameInitElement = GameElements.IGameInitElement;

namespace Homework_Components
{
    public sealed class JumpController : MonoBehaviour,
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private MoveInput keyboardInput;
        private IJumpComponent jumpComponent;


        void IGameInitElement.InitGame(IGameContext context)
        {
            this.keyboardInput = context.GetService<MoveInput>();
        }

        private void Jump()
        {
            jumpComponent.Jump();
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            this.jumpComponent = context.GetService<ICharacterService>().GetCharacter().Get<IJumpComponent>();
            keyboardInput.OnJump += Jump;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            keyboardInput.OnJump -= Jump;
        }
    }
}