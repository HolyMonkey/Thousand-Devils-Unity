using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField] private float _windSpeed;

    private Rigidbody2D _rb2D;
    
    void Start()
    {
        _rb2D= _hero.GetComponent<Rigidbody2D>(); 
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        WindZones();
    }

    private void WindZones()
    {
      _rb2D.AddForce(transform.right * _windSpeed);
    }
}
