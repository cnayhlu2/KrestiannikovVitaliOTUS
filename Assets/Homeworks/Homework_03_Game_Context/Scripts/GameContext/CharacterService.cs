using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Game_Context.GameContext
{
    public class CharacterService : MonoBehaviour,
        ICharacterService
    {
        [SerializeField, Required] private UnityEntity entity;

        public IEntity GetCharacter() => this.entity;
    }
}