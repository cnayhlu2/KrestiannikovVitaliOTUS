using TMPro;
using UnityEngine;

namespace Homework_Presentation_Model.Panels
{
    public class CurrencyPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currencyLabel;

        public void SetValue(string value)
        {
            this.currencyLabel.text = value;
        }
    }
}