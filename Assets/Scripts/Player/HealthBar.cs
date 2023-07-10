using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        private Healt health;

        private void Awake()
        {
            health = GetComponent<Healt>();
        }

        private void Update()
        {
            slider.value = health.CurrentHealth;
        }
    }
}