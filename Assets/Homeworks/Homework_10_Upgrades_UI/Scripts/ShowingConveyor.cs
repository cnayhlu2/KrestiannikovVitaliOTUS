using GameSystem;
using Homework_08_Interaction.GameContext;
using Homework_Presentation_Model.Popups;
using Homework_Presentation_Model.Storage;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_10_Upgrades_UI.Scripts
{
    public class ShowingConveyor : MonoBehaviour, IGameConstructElement
    {
        

        private PopupManager popupManager;
        private MoneyStorage moneyStorage;
        private ConveyorUpgradesManager upgradesManager;


        private ConveyorUpgradesListPresenter presenter = new();

        [Button]
        public void ShowPopup(string id)
        {
            presenter.SetId(id);
            popupManager.ShowPopup(PopupType.ConveyorUpgrades, presenter);
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
            this.popupManager = context.GetService<PopupManager>();
            this.upgradesManager = context.GetService<ConveyorUpgradesManager>();

            this.presenter.Construct(this.moneyStorage, this.upgradesManager);
        }
    }
}