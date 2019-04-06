using Assets.Scripts.Ship;
using UnityEngine;

public enum FlowType { Flow, Wind };
public class FlowEmitter : MonoBehaviour
{
    public FlowType flowType;
    public float flowPower = 10;

    private Vector2 impactVector => transform.up * flowPower;

    private void OnTriggerEnter2D(Collider2D collision) =>
        ApplyFlowToCollisionObjectWithMultiplier(collision);

    private void OnTriggerExit2D(Collider2D collision) =>
        ApplyFlowToCollisionObjectWithMultiplier(collision, -1);

    private void ApplyFlowToCollisionObjectWithMultiplier(Collider2D collision, int multiplier = 1)
    {
        ShipMovementController movementController = collision.gameObject?.GetComponent<ShipMovementController>();
        if (movementController == null) return;

        movementController.ApplyFlow(flowType, impactVector * multiplier);
    }

}
