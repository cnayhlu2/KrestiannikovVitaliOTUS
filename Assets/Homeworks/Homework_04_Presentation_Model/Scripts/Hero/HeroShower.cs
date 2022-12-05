using GameElements;
using Homework_Presentation_Model.Popups;
using Homework_Presentation_Model.Storage;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Homework_Presentation_Model.Hero
{
    public class HeroShower : MonoBehaviour, IGameInitElement
    {
        private PopupManager popupManager;
        private HeroController heroController;

        [Button]
        public void ShowPopup()
        {
            Storage.Hero hero = heroController.GetHero;
            popupManager.ShowPopup(PopupType.HeroUpgrade, hero);
        }

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.popupManager = context.GetService<PopupManager>();
            this.heroController = context.GetService<HeroController>();
        }
    }
}