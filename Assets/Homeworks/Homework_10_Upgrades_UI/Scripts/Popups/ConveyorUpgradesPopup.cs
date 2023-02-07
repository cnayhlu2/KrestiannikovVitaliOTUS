using Homework_Presentation_Model.Popups;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_10_Upgrades_UI.Scripts.Popups
{
    public class ConveyorUpgradesPopup : Popup
    {
        [SerializeField] private ConveyorUpgradeView upgradeView;
        [SerializeField] private Transform viewRoot;
        
        [ShowInInspector] private ConveyorUpgradesListPresenter presenter;
        
        
        protected override void OnShow(object args)
        {
            base.OnShow(args);
            this.presenter = args as ConveyorUpgradesListPresenter;
            this.presenter?.Init(this.upgradeView,this.viewRoot);
            this.presenter?.Show();
        }

        protected override void OnHide()
        {
            base.OnHide();
            this.presenter?.Hide();
        }
    }
}