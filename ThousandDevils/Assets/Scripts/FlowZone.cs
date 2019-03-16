using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FlowZone : MonoBehaviour
    {
        public Vector2 _flowSpeed;

        ShipMovementController _movementController;

        public void OnTriggerStay2D(Collider2D collision)
        {
            _movementController = collision.GetComponent<ShipMovementController>();
            FlowZones(_movementController);
        }

        private void FlowZones(ShipMovementController _movementController)
        {
            _movementController.FlowSpeed = _flowSpeed;
        }
    }
}