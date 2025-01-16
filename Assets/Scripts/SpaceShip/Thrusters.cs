using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Thrusters : MonoBehaviour
{
    public BallGravity ballGravity;
    private SpaceShipInput spaceShipInput; //Input System

    private void Awake()
    {
        spaceShipInput = new SpaceShipInput();
    }

    private void OnEnable()
    {
        spaceShipInput.Gameplay.Enable();
        spaceShipInput.Gameplay.ShipThrust.started += ShipThrustStarted;
        spaceShipInput.Gameplay.ShipThrust.canceled += ShipThrustCanceled;
    }

    private void OnDisable()
    {
        spaceShipInput.Gameplay.Disable();
    }

    private void ShipThrustStarted(InputAction.CallbackContext obj)
    {
        Debug.Log("ThrustOnstarted");
        ballGravity.thrust.y = 50;
    }

    private void ShipThrustCanceled(InputAction.CallbackContext obj)
    {
        Debug.Log("ThrustOncanceled");
        ballGravity.thrust.y = 0;
    }
}
