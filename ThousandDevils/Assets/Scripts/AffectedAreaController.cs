using UnityEngine;

public class AffectedAreaController : MonoBehaviour
{
    private readonly Color _greenColor = new Color32(150, 255, 185, 250);
    private readonly Color _greyColor = new Color32(125, 125, 125, 100);

    void Start()
    {
        SetAffectedAreaColor(_greyColor);
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            SetAffectedAreaColor(_greenColor);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            SetAffectedAreaColor(_greyColor);
    }

    private void SetAffectedAreaColor(Color color)
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }
}
