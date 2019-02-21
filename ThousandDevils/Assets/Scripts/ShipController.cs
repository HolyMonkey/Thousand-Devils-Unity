using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _shipAngularSpeed;
    [SerializeField] private float _shipSpeed;

    [SerializeField] private Vector2 _windSpeed;
    [SerializeField] private Vector2 _flowSpeed;

    [SerializeField] private bool _isSailRaised;

    private Vector2 normal = Vector2.up;

    private Rigidbody2D _rb;

    public Vector2 ShipDirection => Quaternion.Euler(0, 0, _rb.rotation) * normal;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _isSailRaised = true;

        _shipAngularSpeed = 800;
        _shipSpeed = 0;

        _windSpeed = new Vector2(50, 0);
        _flowSpeed = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var speedSpawnedByWind = GetSpeedSpawnedByWind();

        _rb.velocity = (_shipSpeed * ShipDirection + speedSpawnedByWind + _flowSpeed) * Time.deltaTime;

        _rb.angularVelocity = -_shipAngularSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
    }

    private Vector2 GetSpeedSpawnedByWind()
    {
        if (_isSailRaised == false)
            return new Vector2(0, 0);

        return Project(_windSpeed, ShipDirection);
    }

    private Vector2 Project(Vector2 vector, Vector2 onNormal)
    {
        var num = Vector2.Dot(onNormal, onNormal);

        if (num < Mathf.Epsilon)
            return Vector2.zero;

        return onNormal * Vector2.Dot(vector, onNormal) / num;
    }
}
