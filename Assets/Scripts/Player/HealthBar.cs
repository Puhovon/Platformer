using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        private Healt playerHealth;

        private void Awake()
        {
            playerHealth = GetComponent<Healt>();
        }

        private void Update()
        {
            slider.value = playerHealth.CurrentHealth;
        }
    }
}