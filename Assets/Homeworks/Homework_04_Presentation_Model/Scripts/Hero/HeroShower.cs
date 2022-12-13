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
        private MoneyStorage moneyStorage;

        [Button]
        public void ShowPopup()
        {
            HeroPresentationModel heroPresentationModel = new HeroPresentationModel(heroController, moneyStorage);
            popupManager.ShowPopup(PopupType.HeroUpgrade, heroPresentationModel);
        }

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.popupManager = context.GetService<PopupManager>();
            this.heroController = context.GetService<HeroController>();
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}