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


        [Button]
        public void ShowPopup()
        {
            Debug.Log($"{this.upgradesManager == null}");
            popupManager.ShowPopup(PopupType.ConveyorUpgrades, null);
        }


        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            Debug.Log(context.GetService<PopupManager>() == null);

            this.moneyStorage = context.GetService<MoneyStorage>();
            this.popupManager = context.GetService<PopupManager>();
            this.upgradesManager = context.GetService<ConveyorUpgradesManager>();
        }
    }
}