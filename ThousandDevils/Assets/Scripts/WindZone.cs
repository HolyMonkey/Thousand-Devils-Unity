using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WindZone : MonoBehaviour
    {
        public Vector2 _windSpeed;
        
        ShipMovementController _movementController;

        public void OnTriggerStay2D(Collider2D collision)
        {
            _movementController = collision.GetComponent<ShipMovementController>();
            WindZones(_movementController);
        }

        private void WindZones(ShipMovementController _movementController)
        {
            _movementController.WindSpeed = _windSpeed;
            _movementController.GetSpeedSpawnedByWind();
        }

    }
}