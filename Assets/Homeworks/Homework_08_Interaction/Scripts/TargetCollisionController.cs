using Entities;
using GameElements;
using Homework_08_Interaction.Components;
using Homework_Game_Context.GameContext;
using UnityEngine;

namespace Homework_08_Interaction
{
    public class TargetCollisionController : MonoBehaviour, IGameReadyElement, IGameFinishElement, IGameInitElement
    {
        [SerializeField] private PlayerBattleController battleController;
        private IComponent_CollisionEvents collisionComponent;

        public void ReadyGame(IGameContext context)
        {
            this.collisionComponent.OnCollisionEntered += this.OnPlayerEntered;
            this.collisionComponent.OnCollisionExited += this.OnPlayerExited;
            this.collisionComponent.OnCollisionStaying += this.OnPlayerStaying;
        }

        public void FinishGame(IGameContext context)
        {
            this.collisionComponent.OnCollisionEntered -= this.OnPlayerEntered;
            this.collisionComponent.OnCollisionExited -= this.OnPlayerExited;
            this.collisionComponent.OnCollisionStaying -= this.OnPlayerStaying;
        }

        public void InitGame(IGameContext context)
        {
            IEntity hero = context.GetService<ICharacterService>().GetCharacter();
            this.collisionComponent = hero.Get<IComponent_CollisionEvents>();
        }

        private void OnPlayerEntered(Collision obj)
        {
            if (obj.collider.TryGetComponent(out IEntity entity) &&
                entity.Get<IComponent_GetObjectType>().ObjectType == ObjectType.ENEMY)
            {
                this.battleController.StartBattle(entity);
            }
        }

        private void OnPlayerExited(Collision obj)
        {
            if (obj.collider.TryGetComponent(out IEntity entity) &&
                entity.Get<IComponent_GetObjectType>().ObjectType == ObjectType.ENEMY && battleController.IsOnBattle)
            {
                this.battleController.CanselBattle();
            }
        }

        private void OnPlayerStaying(Collision obj)
        {
            if (obj.collider.TryGetComponent(out IEntity entity) &&
                entity.Get<IComponent_GetObjectType>().ObjectType == ObjectType.ENEMY)
            {
                // Debug.Log(nameof(OnPlayerStaying));
            }
        }
    }
}