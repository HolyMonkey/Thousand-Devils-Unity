using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private float _angularSpeed = 180;
    [SerializeField] private float _speed = 50;
    
    private Vector2 ShipDirection => Quaternion.Euler(0, 0, _rigidBody.rotation) * Vector2.down;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _patroller = GetComponent<Patroller>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(_patroller.Waypoint.position - transform.position, Vector3.forward);
        Quaternion targetRotation = Quaternion.RotateTowards(transform.rotation, rotation, _angularSpeed * Time.deltaTime);
        transform.rotation = new Quaternion(0, 0, targetRotation.z, targetRotation.w);

        _rigidBody.velocity = transform.up * -1 * _speed * Time.deltaTime;
    }

    private Rigidbody2D _rigidBody;
    private Patroller _patroller;

}
