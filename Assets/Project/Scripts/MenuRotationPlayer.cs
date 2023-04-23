using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotationPlayer : MonoBehaviour
{
    Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    private void OnMouseDrag()
    {

        var camX = Input.mousePosition.x;
        var camY = Input.mousePosition.y;
        var camZ = -cam.transform.position.z + transform.position.z;
        var mouseInput = (cam.ScreenToWorldPoint(new Vector3(camX, camY, camZ))).x;
        var playerInput = transform.position.x;
        transform.Rotate(new Vector3(0, ( playerInput- mouseInput), 0));
    }
}
