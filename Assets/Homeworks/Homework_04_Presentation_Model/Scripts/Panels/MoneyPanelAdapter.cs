using GameElements;
using Homework_Presentation_Model.Storage;
using UnityEngine;

namespace Homework_Presentation_Model.Panels
{
    public class MoneyPanelAdapter : MonoBehaviour,
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private MoneyStorage moneyStorage;
        private CurrencyPanel currencyPanel;

        void IGameInitElement.InitGame(IGameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
            this.currencyPanel = context.GetService<CurrencyPanel>();
            this.currencyPanel.SetValue(this.moneyStorage.Money.ToString());
        }

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
    }
}