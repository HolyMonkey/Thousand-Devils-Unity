using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FlowZone : MonoBehaviour
    {
        [SerializeField] private Vector2 _flowSpeed;

        private Vector2 _startFlowSpeed = new Vector2(0, 0);

        ShipMovementController _movementController;

        private void OnTriggerStay2D(Collider2D collision)
        {
            _movementController = collision.GetComponent<ShipMovementController>();
            FlowZones(_movementController);
        }
        private void FlowZones(ShipMovementController _movementController)
        {
            _movementController.FlowSpeed = _flowSpeed;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _movementController.FlowSpeed = _startFlowSpeed;
        }
    }
}