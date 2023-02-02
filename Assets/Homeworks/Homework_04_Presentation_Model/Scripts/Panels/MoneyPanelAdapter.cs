using GameSystem;
using Homework_Presentation_Model.Storage;
using UnityEngine;
using IGameContext = GameElements.IGameContext;
using IGameFinishElement = GameElements.IGameFinishElement;
using IGameInitElement = GameElements.IGameInitElement;
using IGameStartElement = GameElements.IGameStartElement;

namespace Homework_Presentation_Model.Panels
{
    public class MoneyPanelAdapter : MonoBehaviour,
        IGameConstructElement,
        IGameStartElement,
        IGameFinishElement
    {
        private MoneyStorage moneyStorage;
        private CurrencyPanel currencyPanel;

        void IGameStartElement.StartGame(IGameContext context)
        {
            this.moneyStorage.OnMoneyChanged += MoneyChanged;
        }

        private void MoneyChanged(int money)
        {
            this.currencyPanel.SetValue(money.ToString());
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            this.moneyStorage.OnMoneyChanged -= MoneyChanged;
        }

        void IGameConstructElement.ConstructGame(GameSystem.IGameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
            this.currencyPanel = context.GetService<CurrencyPanel>();
            this.currencyPanel.SetValue(this.moneyStorage.Money.ToString());
        }
    }
}