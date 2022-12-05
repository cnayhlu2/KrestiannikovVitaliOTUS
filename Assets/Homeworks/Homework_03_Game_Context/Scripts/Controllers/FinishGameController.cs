using GameElements;
using Homework_Components.Components;
using Homework_Game_Context.GameContext;
using UnityEngine;


namespace Homework_Game_Context.Controllers
{
    public class FinishGameController : MonoBehaviour,
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private IGameContext gameContext;
        private IOnDeathComponent deathComponent;

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.gameContext = context;
        }

        void IGameStartElement.StartGame(IGameContext context)
        {
            this.deathComponent = gameContext.GetService<ICharacterService>().GetCharacter().Get<IOnDeathComponent>();
            deathComponent.OnDeath += OnDeath;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            deathComponent.OnDeath -= OnDeath;
        }

        private void OnDeath()
        {
            if (this.gameContext.State != GameState.FINISH)
            {
                Debug.Log("Game end!");
                this.gameContext.FinishGame();
            }
        }
    }
}

