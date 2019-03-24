using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class Ship : MonoBehaviour
    {
        void Update()
        {
            if(gameObject.GetComponent<ShipHealth>().Health <= 0)
                Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var cannonball = other.gameObject.GetComponent<Cannonball.Cannonball>();

            if (cannonball != null)
            {
                gameObject.GetComponent<ShipHealth>().DecreaseHealth(cannonball.Damage);
                cannonball.ReturnToPool();
            }
        }
    }
}