using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShip
{
    
    public class CameraController : MonoBehaviour
    {
        //private float mouseX;
        //private float mouseY;
        public Transform cameraRotator;
        public Transform planet;
        private Vector3 targetRotation;
        private Vector3 currentRotation; 
        public SpaceShipInput input;
        public Transform spaceShip;
        public float followSpeed = 1.0f;
        private void Awake()
        {
            input = new SpaceShipInput();
        }
        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, spaceShip.position, followSpeed * Time.deltaTime); 

            Vector3 surfaceDirection = planet.position - transform.position;
            transform.forward = surfaceDirection;

            currentRotation = Vector3.Lerp(currentRotation, targetRotation , 0.1f * Time.deltaTime);
            cameraRotator.transform.localEulerAngles = currentRotation;
            
        }

        private void OnEnable()
        {
            input.Enable();
            input.Gameplay.Enable();
            input.Gameplay.CameraRotation.performed += CameraRotation;
        }
        private void CameraRotation(InputAction.CallbackContext MouseDelta)
        {
            targetRotation.y += MouseDelta.ReadValue<Vector2>().x;
            targetRotation.x += MouseDelta.ReadValue<Vector2>().y;
            
        }


    }
    




}