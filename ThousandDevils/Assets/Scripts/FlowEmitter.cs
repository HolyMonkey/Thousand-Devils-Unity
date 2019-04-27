using Assets.Scripts.Ship;
using UnityEngine;

public enum FlowType { Flow, Wind };
public class FlowEmitter : MonoBehaviour
{
    [SerializeField] private FlowType _flowType;
    [SerializeField] private float _flowPower = 10;

    private Vector2 impactVector => transform.up * _flowPower;

    //private void OnTriggerEnter2D(Collider2D collision) =>
    //    ApplyFlowToCollisionObjectWithMultiplier(collision);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.tag == "Enemy")
        {
            ApplyFlowToCollisionObjectWithMultiplier(collision);
        }  
    }


    //private void OnTriggerExit2D(Collider2D collision) =>
    //    ApplyFlowToCollisionObjectWithMultiplier(collision, -1);
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.tag == "Enemy")
        {
            ApplyFlowToCollisionObjectWithMultiplier(collision, -1);
        } 
    }

    private void ApplyFlowToCollisionObjectWithMultiplier(Collider2D collision, int multiplier = 1)
    {
        ShipMovementController movementController = collision.gameObject.GetComponent<ShipMovementController>();
        movementController.ApplyFlow(_flowType, impactVector * multiplier);
    }

}
