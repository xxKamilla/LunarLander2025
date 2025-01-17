using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// In charge of Ship rotation.
/// </summary>
public class LanderController : MonoBehaviour
{
   
    public SpaceShipInput input;
    public float yaw;
    public float pitch;
    public float roll;


    public void Awake()
    {
        input = new SpaceShipInput();
    }

    public void Update()
    {
        transform.Rotate(pitch, roll, yaw, Space.Self);
    }
    private void OnEnable()
    {
        input.Enable();
        input.Gameplay.Enable();
        input.Gameplay.ShipRotation.performed += ShipRotationStarted;

    }
    private void OnDisable()
    {
        input.Gameplay.Disable();
    }

    private void ShipRotationStarted(InputAction.CallbackContext obj)
    {
        yaw = obj.ReadValue<Vector2>().y;
        pitch = obj.ReadValue<Vector2>().x;
    }

    private void ShipRotationCanceled(InputAction.CallbackContext obj)
    {

    }
}
