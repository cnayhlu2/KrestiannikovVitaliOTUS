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

        private IHeroPresentationModel presentationModel;

        protected override void OnShow(object args)
        {
            if (args is not IHeroPresentationModel heroPresentationModel)
            {
                throw new Exception("wrong args");
            }

            this.presentationModel = heroPresentationModel;
            this.presentationModel.OnBuyButtonStateChanged += ButtonStateChanged;
            this.presentationModel.Start();
            this.upgradeButton.SetPrice(heroPresentationModel.GetUpgradeCost());
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