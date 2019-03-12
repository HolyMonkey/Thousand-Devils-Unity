using Assets.Scripts;
using UnityEngine;

public class AffectedAreaController : MonoBehaviour
{
    [SerializeField] private float _distance;

    private readonly Vector2 _normal = Vector2.down;

    void Start()
    {
        _distance = 5;
    }

    void Update()
    {
        var startPosition = transform.position;

        var direction = transform.TransformDirection(_normal);

        var endPosition = transform.position + _distance * direction;

        var hit = Physics2D.Raycast(startPosition, direction, _distance);

        var areaColor = hit.collider && hit.collider.GetComponent<AffectableObject>() 
            ? Color.green 
            : Color.grey;

        Debug.DrawLine(startPosition, endPosition, areaColor);
    }
}