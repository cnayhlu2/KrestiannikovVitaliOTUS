using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Homeworks.Homework_05_Save_Load.Upgrades
{
    public class UpgradesRepository : MonoBehaviour
    {
        private const string PreffKey = "Homework_05_Save_Load/Upgrades";
        private const string Color = "blue";

        public void LoadUpgrades(out UpgradesData data)
        {
            if (PlayerPrefs.HasKey(PreffKey))
            {
                string json = PlayerPrefs.GetString(PreffKey);
                data = JsonUtility.FromJson<UpgradesData>(json);
                Debug.Log($"<color={Color}>Load upgrades data {json} </color>");
            }
            else
            {
                data = GetDefault();
                Debug.Log($"<color={Color}>Load default data {JsonUtility.ToJson(data)} </color>");
            }
        }

        public void SaveUpgrades(UpgradesData data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(PreffKey, json);

            Debug.Log($"<color={Color}>Save upgrades data {json}</color>");
        }


        private UpgradesData GetDefault()
        {
            UpgradesData data = new()
            {
                upgrades = new List<UpgradeData>()
                {
                    new() {Name = "Damage", Level = 0},
                    new() {Name = "Armor", Level = 0},
                    new() {Name = "Speed", Level = 0}
                }
            };
            return data;
        }


#if UNITY_EDITOR
        [UnityEditor.MenuItem("Homework/Homework_05_Save_Load/ClearUpgrades")]
        public static void ClearUpgradesPrefs()
        {
            PlayerPrefs.DeleteKey(PreffKey);
        }
#endif
    }
}