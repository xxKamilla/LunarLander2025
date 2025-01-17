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
    public float rotationTorque = 10;
    public Vector3 curretRot;
    public bool isRotation;
    


    public void Awake()
    {
        input = new SpaceShipInput();
    }

    public void Update()
    {
        // adding to the rotation each frame
        curretRot.x += pitch * Time.deltaTime;
        curretRot.y += roll * Time.deltaTime;
        curretRot.z += yaw * Time.deltaTime;

        // Rotates the transform 
        transform.Rotate(curretRot.x, curretRot.y, curretRot.z, Space.Self);
        //curretRot = Vector3.Lerp(curretRot, Vector3.zero, 0.01f);
    }
    public void LateUpdate()
    {
        curretRot = Vector3.Lerp(curretRot, Vector3.zero, 0.003f);
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
        // changes the rotation based on the input vector2 value. 
        yaw = obj.ReadValue<Vector2>().x;
        pitch = obj.ReadValue<Vector2>().y;
    }

    private void ShipRotationCanceled(InputAction.CallbackContext obj)
    {

    }
}
