using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _shipAngularSpeed;

    [SerializeField] private Vector2 _shipSpeed;
    [SerializeField] private Vector2 _windSpeed;
    [SerializeField] private Vector2 _flowSpeed;

    [SerializeField] private bool _isSailRaised;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _isSailRaised = true;

        _shipAngularSpeed = 800f;

        _shipSpeed = new Vector2(0, 100f);
        _flowSpeed = new Vector2(50f, -50f);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = (_shipSpeed + _flowSpeed) * Time.deltaTime;

        _rb.angularVelocity = -_shipAngularSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
    }
}
