using System.Collections.Generic;
using Assets.Scripts.Cannonball;
using Assets.Scripts.ObjectPoolingManager;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipShootController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        public List<GameObject> Cannons;

        public void Shoot()
        {
            var charger = gameObject.GetComponent<Charger>();

            if (charger.IsReadyToShoot() == false)
                return;

            foreach (var cannon in Cannons)
            {
                var cannonBall = PoolManager.GetInstance().PlacePooledObject("CannonBall", cannon.transform.position, cannon.transform.rotation);
                cannonBall.GetComponent<CannonballMovementController>().Speed = _speed;
            }

            charger.StartCharge();
        }
    }
}
