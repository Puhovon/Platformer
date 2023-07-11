using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private Healt health;

        private void Start()
        {
            health = GetComponent<Healt>();
        }

        private void Update()
        {
            slider.value = health.CurrentHealth;
        }
    }
}