using Assets.Scripts.Ship;
using UnityEngine;

namespace Assets.Scripts
{
    public class AffectedArea : MonoBehaviour
    {
        [SerializeField] private float _distance;

        private readonly Vector2 _normal = Vector2.down;

        private LineRenderer _lineRenderer;

        private void Start()
        {
            _distance = 5;

            _lineRenderer = gameObject.GetComponent<LineRenderer>();
            _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

            SetLineRendererColor(Color.grey);
        }

        private void Update()
        {
            var startPosition = transform.position;

            var direction = transform.TransformDirection(_normal);

            var endPosition = transform.position + _distance * direction;

            var hit = Physics2D.Raycast(startPosition, direction, _distance);

            var areaColor = hit.collider && hit.collider.GetComponent<ShipHealth>() 
                ? Color.green 
                : Color.grey;

            DrawLineRenderer(startPosition, endPosition, areaColor);

            Debug.DrawLine(startPosition, endPosition, areaColor);
        }

        private void DrawLineRenderer(Vector3 startPosition, Vector3 endPosition, Color color)
        {
            _lineRenderer.SetPosition(0, startPosition);
            _lineRenderer.SetPosition(1, endPosition);

            SetLineRendererColor(color);
        }

        private void SetLineRendererColor(Color color)
        {
            _lineRenderer.startColor = color;
            _lineRenderer.endColor = color;
        }
    }
}