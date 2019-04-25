using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ship
{
    public class HealthBar : MonoBehaviour
    {
        public ShipHealth Health;
        public Slider Slider;

        void Start()
        {
            Health.OnHealthChange.AddListener(HealthUpdate);
            Slider.maxValue = Health.Health;
            Slider.value = Health.Health;
        }

        public void HealthUpdate()
        {
            Slider.value = Health.Health;
        }
    }
}