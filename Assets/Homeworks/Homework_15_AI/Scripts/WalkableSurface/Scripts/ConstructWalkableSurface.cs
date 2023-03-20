using System.Collections.Generic;
using GameSystem;
using Homework_Game_Context.GameContext;
using Polygons;
using UnityEngine;

namespace Game.GameEngine.WalkableSurfaces
{
    public sealed class ConstructWalkableSurface : MonoBehaviour, IGameConstructElement
    {
        public void ConstructGame(IGameContext context)
        {
            var walkablePoligons = GameObject.FindObjectsOfType<WalkablePolygon>();

            Dictionary<WalkableType, WalkableSurface> surfaces = new();

            for (int i = 0; i < walkablePoligons.Length; i++)
            {
                if (!surfaces.ContainsKey(walkablePoligons[i].PolygonType))
                {
                    surfaces.Add(walkablePoligons[i].PolygonType, new WalkableSurface());
                }

                surfaces[walkablePoligons[i].PolygonType].RegisterPolygon(walkablePoligons[i]);
            }

            var hero = context.GetService<CharacterService>().GetCharacter();
            hero.Get<Component_SetWalkableSurface>().SetSurface(surfaces[WalkableType.Ground]);
        }
    }
}