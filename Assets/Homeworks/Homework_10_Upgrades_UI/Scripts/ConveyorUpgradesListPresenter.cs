using System.Collections.Generic;
using Homework_08_Interaction.GameContext;
using Homework_Presentation_Model.Storage;
using UnityEngine;

namespace Homeworks.Homework_10_Upgrades_UI.Scripts
{
    public class ConveyorUpgradesListPresenter
    {
        private string id;
        private MoneyStorage moneyStorage;
        private ConveyorUpgradesManager upgradesManager;
        private ConveyorUpgradeView upgradeView;
        private Transform viewRoot;

        private readonly List<ConveyorUpgradeView> activeViews = new();
        private readonly List<ConveyorUpgradePresenter> activePresenters = new();

        public void Construct(MoneyStorage moneyStorage, ConveyorUpgradesManager upgradesManager)
        {
            this.moneyStorage = moneyStorage;
            this.upgradesManager = upgradesManager;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        public void Show()
        {
            var upgrades = this.upgradesManager.GetUpgradesById(id);

            foreach (var upgrade in upgrades)
            {
                ConveyorUpgradeView view = GameObject.Instantiate(this.upgradeView, this.viewRoot);
                this.activeViews.Add(view);

                ConveyorUpgradePresenter presenter = new(upgrade, view);
                presenter.Construct(this.moneyStorage, this.upgradesManager);
                this.activePresenters.Add(presenter);
            }

            foreach (var presenter in this.activePresenters)
            {
                presenter.Show();
            }
        }


        public void Hide()
        {
            foreach (var presenter in this.activePresenters)
            {
                presenter.Hide();
            }

            this.activePresenters.Clear();

            foreach (var view in this.activeViews)
            {
                GameObject.Destroy(view.gameObject);
            }

            this.activeViews.Clear();
        }

        public void Init(ConveyorUpgradeView upgradeView, Transform viewRoot)
        {
            this.upgradeView = upgradeView;
            this.viewRoot = viewRoot;
        }
    }
}