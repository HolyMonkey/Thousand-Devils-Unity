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
            Slider.maxValue = Health.Health;
            Slider.value = Health.Health;
        }

        public void HealthUpdate()
        {
            Slider.value = Health.Health;
        }
    }
}