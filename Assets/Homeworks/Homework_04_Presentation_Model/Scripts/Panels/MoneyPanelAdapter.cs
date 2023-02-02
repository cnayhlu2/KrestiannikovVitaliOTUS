using GameSystem;
using Homework_Presentation_Model.Storage;
using UnityEngine;

namespace Homework_Presentation_Model.Panels
{
    public class MoneyPanelAdapter : MonoBehaviour,
        IGameConstructElement
    {
        private MoneyStorage moneyStorage;
        private CurrencyPanel currencyPanel;


        private void OnDestroy()
        {
            this.moneyStorage.OnMoneyChanged -= MoneyChanged;
        }

        private void MoneyChanged(int money)
        {
            this.currencyPanel.SetValue(money.ToString());
        }

        void IGameConstructElement.ConstructGame(GameSystem.IGameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
            this.currencyPanel = context.GetService<CurrencyPanel>();
            this.currencyPanel.SetValue(this.moneyStorage.Money.ToString());
            this.moneyStorage.OnMoneyChanged += MoneyChanged;
        }
    }
}