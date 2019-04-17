using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipMovementController : MonoBehaviour
    {
        [SerializeField] private float _shipAngularSpeed;
        [SerializeField] private float _shipSpeedMagnitude;

        [SerializeField] private Vector2 _windSpeed;
        [SerializeField] private Vector2 _flowSpeed;

        [SerializeField] private bool _isSailRaised;

        [SerializeField] private float _turnDirection;

        private Vector2 _normal = Vector2.down;

        private Rigidbody2D _rb;

        private Vector2 ShipDirection => Quaternion.Euler(0, 0, _rb.rotation) * _normal;

        void Start()
        {
            _turnDirection = 0;
            _rb = GetComponent<Rigidbody2D>();

            _isSailRaised = true;
            
            _shipSpeedMagnitude = 50;

            _windSpeed = new Vector2(0, 0);
            _flowSpeed = new Vector2(0, 0);
        }

        void Update()
        {
            var speedSpawnedByWind = GetSpeedSpawnedByWind();

            _rb.velocity = (_shipSpeedMagnitude * ShipDirection + speedSpawnedByWind + _flowSpeed) * Time.deltaTime;

            _rb.angularVelocity = -_shipAngularSpeed * Time.deltaTime * _turnDirection;
        }

        private Vector2 GetSpeedSpawnedByWind()
        {
            if (_isSailRaised == false)
                return new Vector2(0, 0);

            return Project(_windSpeed, ShipDirection);
        }

        private Vector2 Project(Vector2 vector, Vector2 onNormal)
        {
            var product = Vector2.Dot(onNormal, onNormal);

            if (product < Mathf.Epsilon)
                return Vector2.zero;

            return onNormal * Vector2.Dot(vector, onNormal) / product;
        }

        public void ToggleSailRaised()
        {
            _isSailRaised = !_isSailRaised;
        }

        public void SetTurnDirection(float turnDirection)
        {
            _turnDirection = turnDirection;
        }
    }
}
