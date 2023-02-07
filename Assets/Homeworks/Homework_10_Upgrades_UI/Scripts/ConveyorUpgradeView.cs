using Homework_Presentation_Model.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homeworks.Homework_10_Upgrades_UI.Scripts
{
    public class ConveyorUpgradeView : MonoBehaviour
    {
        public BuyButton Button
        {
            get { return this.button; }
        }

        [SerializeField] private BuyButton button;
        [SerializeField] private Image icon;

        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI stats;


        public void SetIcon(Sprite sprite)
        {
            this.icon.sprite = sprite;
        }
        
        public void SetName(string name)
        {
            this.name.text = name;
        }
        
        public void SetLevel(string level)
        {
            this.level.text = level;
        }

        public void SetStats(string stats)
        {
            this.stats.text = stats;
        }
    }
}