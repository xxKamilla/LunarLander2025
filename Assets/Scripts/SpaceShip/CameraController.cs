using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShip
{
    
    public class CameraController : MonoBehaviour
    {
        //private float mouseX;
        //private float mouseY;
        public bool cameraFocus;
        public Transform cameraRotator;
        public Transform planet;
        private Vector3 targetRotation;
        private Vector3 currentRotation; 
        public SpaceShipInput input;
        public Transform spaceShip;
        public float followSpeed = 1.0f;
        public float mouseSensitivity = 1;

        private void Awake()
        {
            input = new SpaceShipInput();

            #if !UNITY_EDITOR
            Cursor.lockState = CursorLockMode.Confined;
            #endif
        }
        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, spaceShip.position, followSpeed * Time.deltaTime); 
            if (cameraFocus == true)
            {
                Vector3 surfaceDirection = planet.position - transform.position;
                transform.forward = surfaceDirection;
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 1 * Time.deltaTime);
            }

            currentRotation = Vector3.Lerp(currentRotation, targetRotation * mouseSensitivity , 10f * Time.deltaTime);
            cameraRotator.transform.localEulerAngles = currentRotation;
            Debug.Log(targetRotation);
        }

        private void OnEnable()
        {
            input.Enable();
            input.Gameplay.Enable();
            input.Gameplay.CameraRotation.performed += CameraRotation;
            input.Gameplay.CameraRotation.canceled += CancelCameraRotation;
        }

        private void CancelCameraRotation(InputAction.CallbackContext obj)
        {
            Mouse.current.WarpCursorPosition(new Vector2(Screen.width / 2, Screen.height / 2));
        }

        private void CameraRotation(InputAction.CallbackContext mouseDelta)
        {
            
            targetRotation.y += mouseDelta.ReadValue<Vector2>().x;
            targetRotation.x += mouseDelta.ReadValue<Vector2>().y;
        }
    }
    




}