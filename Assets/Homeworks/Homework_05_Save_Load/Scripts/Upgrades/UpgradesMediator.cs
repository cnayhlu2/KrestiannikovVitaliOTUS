using System.Collections.Generic;
using GameElements;
using Homework_05_Save_Load.Application;
using Services;
using UnityEngine;

namespace Homeworks.Homework_05_Save_Load.Upgrades
{
    public class UpgradesMediator : MonoBehaviour, IGameDataLoader, IGameDataSaver
    {
        private UpgradesRepository repository;

        [Inject]
        public void Construct(UpgradesRepository repository)
        {
            this.repository = repository;
        }

        void IGameDataLoader.LoadData(IGameContext context)
        {
            UpgradesController upgradesController = context.GetService<UpgradesController>();
            repository.LoadUpgrades(out UpgradesData upgradesData);
            List<Upgrade> upgrades = new();

            foreach (var upgradeData in upgradesData.upgrades)
            {
                upgrades.Add(new Upgrade()
                {
                    Level = upgradeData.Level,
                    Name = upgradeData.Name
                });
            }

            upgradesController.SetUpgrades(upgrades);
        }

        void IGameDataSaver.Save(IGameContext context)
        {
            UpgradesController upgradesController = context.GetService<UpgradesController>();
            List<Upgrade> upgrades = upgradesController.GetUpgrades();
            UpgradesData data = new UpgradesData();
            data.upgrades = new List<UpgradeData>();
            foreach (var upgrade in upgrades)
            {
                data.upgrades.Add(new UpgradeData()
                {
                    Name = upgrade.Name,
                    Level = upgrade.Level
                });
            }
            repository.SaveUpgrades(data);
        }
    }
}