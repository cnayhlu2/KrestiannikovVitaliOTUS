using System;
using System.Collections.Generic;
using Homework_11_Chests;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts.Chest
{
    [CreateAssetMenu(fileName = nameof(ChestCatalog),
        menuName = "Homework/Chests/New "+nameof(ChestCatalog))]
    public class ChestCatalog : ScriptableObject
    {
        [SerializeField] private List<ChestConfig> chests = new();

        public ChestConfig GetChestConfigByType(ChestType type)
        {
            for (int i=0;i<this.chests.Count;i++)
            {
                if (type == chests[i].ChestType)
                    return chests[i];
            }

            throw new Exception($"Do not find chest type {type}");
        }
        
    }
}