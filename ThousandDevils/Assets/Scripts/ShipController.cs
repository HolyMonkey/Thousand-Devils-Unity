using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Vector2 shipSpeed;

    [SerializeField] private float shipAngularSpeed;

    [SerializeField] private Vector2 windSpeed;

    [SerializeField] private Vector2 flowSpeed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        shipSpeed = new Vector2(0, 100f);
        shipAngularSpeed = 800f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = shipSpeed * Time.deltaTime;

        rb.angularVelocity = -shipAngularSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
    }
}
