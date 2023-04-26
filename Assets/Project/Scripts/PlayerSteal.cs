using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteal : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float rayDist;
    void Start()
    {
        rayDist = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            var camPos = cam.transform.position;
            var playerPos = gameObject.transform.Find("CameraPoint").position;
            RaycastHit [] hits;
            Ray ray = new Ray(playerPos + (-camPos + playerPos) * 0.2f, (-camPos + playerPos));
            Debug.DrawRay(playerPos + (-camPos + playerPos) * 0.2f, (-camPos + playerPos) , Color.green, 100f);

            //Debug.DrawLine(playerPos + (-camPos + playerPos) * 0.2f, (-camPos + playerPos) * 1f + playerPos, Color.green, 100f);
            hits = Physics.RaycastAll(ray, rayDist);
            foreach (var hit in hits)
            {
                if(hit.transform.gameObject.CompareTag("treasure"))
                {
                    Debug.Log("Tr");
                    Destroy(hit.transform.gameObject);
                    break;
                }
            }
        }
    }
}
