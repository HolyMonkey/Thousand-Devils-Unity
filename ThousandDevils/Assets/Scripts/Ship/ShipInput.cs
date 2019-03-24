using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipInput : MonoBehaviour
    {
        [SerializeField] private GameObject _sheep;

        void Update()
        {
            var shipMovementController = _sheep.GetComponent<ShipMovementController>();
            var shipShootController = _sheep.GetComponent<ShipShootController>();

            if (Input.GetKeyDown(KeyCode.Space))
                shipShootController.Shoot();

            if (Input.GetKeyDown(KeyCode.E))
            {
                shipMovementController.ToggleSailRaised();
            }

            shipMovementController.SetTurnDirection(Input.GetAxis("Horizontal"));
        }
    }
}
