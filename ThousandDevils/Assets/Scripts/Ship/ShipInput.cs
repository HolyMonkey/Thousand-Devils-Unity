using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipInput : MonoBehaviour
    {
        [SerializeField] private GameObject _ship;

        void Update()
        {
            var shipMovementController = _ship.GetComponent<ShipMovementController>();
            var shipShootController = _ship.GetComponent<ShipShootController>();
            
            if (Input.GetKey(KeyCode.Space))
            {
                shipShootController.IncreaseShootingAccuracy();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                shipShootController.Shoot();
                shipShootController.ResetShootingAccuracy();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                shipMovementController.ToggleSailRaised();
            }

            shipMovementController.SetTurnDirection(Input.GetAxis("Horizontal"));
        }
    }
}