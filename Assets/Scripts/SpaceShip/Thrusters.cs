using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Ship thrusters and input.
/// </summary>

public class Thrusters : MonoBehaviour
{
    public BallGravity ballGravity;
    public FuelTank fuelTank;
    public Vector3 upDirection;

    private void Awake()
    {
        ballGravity = GetComponent<BallGravity>();
        fuelTank = GetComponent<FuelTank>();
    }

    private void Update()
    {
        ballGravity.thrust = transform.up;

        if (Input.GetKey(KeyCode.Space))
        {
            ThrusterOn();
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ThrusterOff();
        }
    }

    private void ThrusterOn()
    {
        Debug.Log("ThrusterOn");
        ballGravity.thrust = transform.up * 20;
    }

    private void ThrusterOff()
    {
        Debug.Log("ThrusterOff");
        ballGravity.thrust = transform.up;
    }




}
