using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Transform Waypoint => _patrolPath[_currentWaypointIndex];

    [SerializeField] private float _waypointCheckDistance = 1;
    [SerializeField] private PatrolPath _patrolPath;
    private void Start()
    {
        _currentWaypointIndex = _patrolPath.GetClosestWaypointIndex(transform);
    }

    private void Update()
    {
        if (Vector2.Distance(Waypoint.position, transform.position) < _waypointCheckDistance)
        {
            UpdateWaypoint();
        }
        
    }

    private void UpdateWaypoint()
    {
        if (++_currentWaypointIndex >= _patrolPath.GetWaypointsCount())
            _currentWaypointIndex = 0;
    }

    private int _currentWaypointIndex;
}
