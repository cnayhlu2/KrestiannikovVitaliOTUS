using System;
using Homework_Presentation_Model.Hero;
using Homework_Presentation_Model.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homework_Presentation_Model.Popups
{
    public class HeroPopup : Popup
    {
        [SerializeField] private TextMeshProUGUI heroName;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI damage;

        [SerializeField] private BuyButton upgradeButton;

        private IHomework_Presentation_Model presentationModel;

        protected override void OnShow(object args)
        {
            if (args is not IHomework_Presentation_Model presentationModel)
            {
                throw new Exception("wrong args");
            }

            this.presentationModel = presentationModel;
            this.presentationModel.OnBuyButtonStateChanged += ButtonStateChanged;
            this.presentationModel.Start();
            this.upgradeButton.SetPrice(presentationModel.GetUpgradeCost());
            this.upgradeButton.AddListener(OnUpgradeClick);
            UpdateViewData();
        }


        protected override void OnHide()
        {
            this.upgradeButton.RemoveListener(OnUpgradeClick);
            this.presentationModel.OnBuyButtonStateChanged += ButtonStateChanged;
            this.presentationModel.Stop();
        }


        private void UpdateViewData()
        {
            this.heroName.text = this.presentationModel.GetName();
            this.level.text = this.presentationModel.GetLevel();
            this.damage.text = this.presentationModel.GetDamage();

            ButtonStateChanged(this.presentationModel.CanUpgrade());
        }

        private void ButtonStateChanged(bool state)
        {
            this.upgradeButton.SetAvailable(state);
        }

        private void OnUpgradeClick()
        {
            this.presentationModel.OnUpgradeClicked();
            UpdateViewData();
        }
    }
}