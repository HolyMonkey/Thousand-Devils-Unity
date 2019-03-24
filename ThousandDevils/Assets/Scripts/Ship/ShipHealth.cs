using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipHealth : MonoBehaviour
    {
        [SerializeField] private int _health;
        
        public int Health => _health;

        void Start()
        {
            _health = 200;
        }

        public void DecreaseHealth(uint healthToDecrease)
        {
            var remainingHealth = Health - (int) healthToDecrease;

            _health = remainingHealth <= 0 ? 0 : remainingHealth;
        }
    }
}