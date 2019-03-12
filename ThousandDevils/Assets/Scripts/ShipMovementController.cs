using UnityEngine;

namespace Assets.Scripts
{
    public class ShipMovementController : MonoBehaviour
    {
        [SerializeField] private float _shipAngularSpeed;
        [SerializeField] private float _shipSpeedMagnitude;

        [System.NonSerialized] public Vector2 _windSpeed;
        [System.NonSerialized] public Vector2 _flowSpeed;

        [SerializeField] private bool _isSailRaised;

        private readonly Vector2 _normal = Vector2.up;

        private Rigidbody2D _rb;

        private Vector2 ShipDirection => Quaternion.Euler(0, 0, _rb.rotation) * _normal;     

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();

            _isSailRaised = true;

            _shipAngularSpeed = 2000;
            _shipSpeedMagnitude = 50;

            //_windSpeed = new Vector2(0, 0);
            //_flowSpeed = new Vector2(0, 0);
        }

        void Update()
        {
            var speedSpawnedByWind = GetSpeedSpawnedByWind();

            _rb.velocity = (_shipSpeedMagnitude * ShipDirection + speedSpawnedByWind + _flowSpeed) * Time.deltaTime;

            _rb.angularVelocity = -_shipAngularSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        }

      public Vector2 GetSpeedSpawnedByWind()
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
    }
}
