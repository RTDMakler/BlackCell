using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace x2

{
    public class MouseLook : MonoBehaviour
    {

        public float mouseXSensitivity = 100f;

        private float k;
        [SerializeField] CinemachineFreeLook cinemachineFreeLook;
        public Transform playerBody;

        private void Start()
        {
            k = 250 * 4 * Time.deltaTime;
            cinemachineFreeLook.m_CommonLens = true;
            
            
        }
        void LateUpdate()
        {
            
            GetZoom();
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

                playerBody.gameObject.transform.rotation = Quaternion.RotateTowards(playerBody.gameObject.transform.rotation, targetRotation, k);
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

                playerBody.gameObject.transform.rotation = Quaternion.RotateTowards(playerBody.gameObject.transform.rotation, targetRotation, k);
            }
        }
        void GetZoom()
        {
            var startDir = transform.position;
            var playerPos = playerBody.transform.Find("CameraPoint").position;
            var finDir =  playerPos - transform.position;
            Ray ray = new Ray(startDir, finDir);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);
            Debug.DrawRay(startDir, finDir, Color.red);
            if (hits.Length > 2)
            {
                Debug.Log(hits.Length + " " + hits[0].transform.gameObject.name);
                //if (cinemachineFreeLook.m_Lens.FieldOfView > 15)
                //    cinemachineFreeLook.m_Lens.FieldOfView -= 0.1f;
                //cinemachineFreeLook.m_XAxis.Value -= 0.1f;
                //cinemachineFreeLook.m_YAxis.Value -= 0.1f;
            }
            else
            {
                //if (cinemachineFreeLook.m_Lens.FieldOfView < 40)
                //    cinemachineFreeLook.m_Lens.FieldOfView += 0.1f;
            }
        }
    }
}