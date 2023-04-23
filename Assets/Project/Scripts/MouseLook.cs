using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace x2

{
    public class MouseLook : MonoBehaviour
    {

        public float mouseXSensitivity = 100f;

        public Transform playerBody;

        void LateUpdate()
        {
            float playerVerticalIpnput = Input.GetAxis("Vertical");
            float playerHorizontalInput = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.W) )    
            {
                

                Vector3 forward = this.transform.forward;
                
                Vector3 right = this.transform.right;
                forward.y = 0;
                right.y = 0;

                forward = forward.normalized;
                right = right.normalized;

                Vector3 forwardRelativeVerticalInput = forward* playerVerticalIpnput;
                Vector3 rightRelativeVerticalInput = right* playerHorizontalInput;

                Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;


                Quaternion targetRotation = Quaternion.LookRotation(cameraRelativeMovement);

                playerBody.gameObject.transform.rotation = Quaternion.RotateTowards(playerBody.gameObject.transform.rotation, targetRotation, 250*Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {


                Vector3 forward = this.transform.forward;

                Vector3 right = this.transform.right;
                forward.y = 0;
                right.y = 0;

                forward = forward.normalized;
                right = right.normalized;

                Vector3 forwardRelativeVerticalInput = forward * playerVerticalIpnput;
                Vector3 rightRelativeVerticalInput = right * playerHorizontalInput;

                Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

                Quaternion targetRotation = Quaternion.LookRotation(-cameraRelativeMovement);

                playerBody.gameObject.transform.rotation = Quaternion.RotateTowards(playerBody.gameObject.transform.rotation, targetRotation, 250 * Time.deltaTime);
            }
        }
    }
}