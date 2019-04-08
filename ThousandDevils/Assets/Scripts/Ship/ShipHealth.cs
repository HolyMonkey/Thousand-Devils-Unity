using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ship
{
    public class ShipHealth : MonoBehaviour
    {
        [SerializeField] private int _health;
        private Slider _healthBar;
        
        public int Health => _health;

        void Start()
        {
            _health = 200;
            _healthBar = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider>();
            _healthBar.maxValue = _health;
            _healthBar.value = _health;
        }

        public void DecreaseHealth(uint healthToDecrease)
        {
            var remainingHealth = Health - (int) healthToDecrease;

            _health = remainingHealth <= 0 ? 0 : remainingHealth;
            _healthBar.value = _health;
        }
    }
}