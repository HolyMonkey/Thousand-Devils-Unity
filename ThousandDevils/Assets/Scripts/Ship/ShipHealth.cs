using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Ship
{
    public class ShipHealth : MonoBehaviour
    {
        [SerializeField] private int _health;
        
        public int Health => _health;

        public UnityEvent OnHealthChange;

        void Awake()
        {
            _health = 200;
        }

        public void DecreaseHealth(uint healthToDecrease)
        {
            var remainingHealth = Health - (int) healthToDecrease;

            _health = remainingHealth <= 0 ? 0 : remainingHealth;
            if (OnHealthChange != null)
                OnHealthChange.Invoke();
        }
    }
}