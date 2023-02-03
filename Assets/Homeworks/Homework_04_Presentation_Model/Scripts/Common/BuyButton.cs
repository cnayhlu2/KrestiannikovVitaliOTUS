using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Homework_Presentation_Model.UI
{
    public sealed class BuyButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        [Space] [SerializeField] private Image buttonBackground;

        [SerializeField] private Sprite availableButtonSprite;

        [SerializeField] private Sprite lockedButtonSprite;

        [Space] [SerializeField] private TextMeshProUGUI priceText;

        [SerializeField] private Image priceIcon;

        [Space] [SerializeField] private State state;

        public void AddListener(UnityAction action)
        {
            this.button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            this.button.onClick.RemoveListener(action);
        }

        public void SetPrice(string price)
        {
            this.priceText.text = price;
        }

        public void SetIcon(Sprite icon)
        {
            this.priceIcon.sprite = icon;
        }

        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable ? State.AVAILABLE : State.LOCKED;
            this.SetState(state);
        }

        public void SetState(State state)
        {
            this.state = state;

            switch (this.state)
            {
                case State.MAXED:
                    this.button.interactable = false;
                    this.buttonBackground.sprite = this.availableButtonSprite;
                    this.priceIcon.gameObject.SetActive(false);
                    break;
                case State.LOCKED:
                    this.button.interactable = false;
                    this.buttonBackground.sprite = this.lockedButtonSprite;
                    this.priceIcon.gameObject.SetActive(true);
                    break;
                case State.AVAILABLE:
                    this.button.interactable = true;
                    this.buttonBackground.sprite = this.availableButtonSprite;
                    this.priceIcon.gameObject.SetActive(true);
                    break;
                default:
                    throw new Exception($"Undefined button state {state}!");
            }
        }

        public enum State
        {
            AVAILABLE,
            LOCKED,
            MAXED
        }
    }
}