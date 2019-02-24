using Assets.Scripts.ObjectPoolingManager;
using UnityEngine;

namespace Assets.Scripts.Cannonball
{
    public class CannonballMovementController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maximumFlightRange;

        private Rigidbody2D _rb;
        private Vector3 _lastPosition;

        void Awake()
        {
            _speed = 3;
            _maximumFlightRange = 5;
        }

        void Update()
        {
            var distance = Vector2.Distance(transform.position, _lastPosition);

            if (distance >= _maximumFlightRange)
                gameObject.GetComponent<PoolObject>().ReturnToPool();
        }

        void OnEnable()
        {
            _lastPosition = transform.position;
            _rb = transform.GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;
        }
    }
}