using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PatrolPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;

    public int GetClosestWaypointIndex(Transform transform) => _waypoints.IndexOf(GetClosestWaypoint(transform));

    public int GetWaypointsCount() => _waypoints?.Count ?? -1;

    public Transform this[int index]
    {
        get
        {
            if (index < 0 || index >= _waypoints.Count)
                throw new System.IndexOutOfRangeException();

            return _waypoints[index];
        }
    }

    private WaypointWithDistance SelectWaypointWithDistance(Transform waypoint) =>
        new WaypointWithDistance(waypoint, transform.position);

    private Transform GetClosestWaypoint(Transform ownerTransform) =>
            _waypoints.Select(SelectWaypointWithDistance).Min().Waypoint;

    private void OnDrawGizmosSelected()
    {
        List<Vector3> filledWaypoints = _waypoints?.Where(_waypoint => _waypoint != null).Select(waypoint => waypoint.position).ToList() ?? null;
        if (filledWaypoints == null || filledWaypoints.Count < 2) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < filledWaypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(filledWaypoints[i], filledWaypoints[i + 1]);
        }

        Gizmos.DrawLine(filledWaypoints.Last(), filledWaypoints.First());
    }

    private class WaypointWithDistance : IComparable<WaypointWithDistance>
    {
        public Transform Waypoint { get; set; }
        public float Distance { get; set; }

        public WaypointWithDistance(Transform waypoint, Vector2 originPosition)
        {
            Waypoint = waypoint;
            Distance = Vector2.Distance(originPosition, waypoint.position);
        }

        public int CompareTo(WaypointWithDistance other)
        { 
            return Distance > other.Distance ? 1 : Distance == other.Distance ? 0 : -1;
        }
    }
}