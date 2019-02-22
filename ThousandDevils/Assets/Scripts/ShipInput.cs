using Assets.Scripts;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    [SerializeField] private GameObject _sheep;

    void Update()
    {
        var shipMovementController = _sheep.GetComponent<ShipMovementController>();

        if (Input.GetKeyDown(KeyCode.E))
            shipMovementController.ToggleSailRaised();

        shipMovementController.SetTurnDirection(Input.GetAxis("Horizontal"));
    }
}
