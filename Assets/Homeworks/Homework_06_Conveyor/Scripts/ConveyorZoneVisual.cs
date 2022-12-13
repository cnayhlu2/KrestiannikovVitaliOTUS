using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorZoneVisual : MonoBehaviour
    {
        [SerializeField] private List<GameObject> items = new();

        public void Set(int count)
        {
            float current = Math.Min(count, items.Count);

            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetActive(i < current);
            }
        }
    }
}