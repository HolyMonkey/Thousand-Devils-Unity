using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WindZone : MonoBehaviour
    {
      [SerializeField] private Vector2 _windSpeed;
        private Vector2 _startWindSpead = new Vector2(0,0);
        
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

        private void OnTriggerExit2D(Collider2D collision)
        {
            _movementController.WindSpeed = _startWindSpead;
        }
    }
}