using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WindZone : MonoBehaviour
    {
        [SerializeField] private GameObject _hero;
        public Vector2 _windSpeed;
        public Vector2 _flowSpeed;

        ShipMovementController _movementController;

        private void Start()
        {
            _movementController = _hero.GetComponent<ShipMovementController>();
        }

        public void OnTriggerStay2D(Collider2D collision)
        {
            WindZones();
            FlowZones();
        }

        private void WindZones()
        {
            _movementController._windSpeed = _windSpeed;
            _movementController.GetSpeedSpawnedByWind();
          
        }

        private void FlowZones()
        {
            _movementController._flowSpeed = _flowSpeed;
        }
    }
}