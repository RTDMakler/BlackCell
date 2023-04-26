using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteal : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float rayDist;
    private int capacity;
    private int currentWeight;


    int bag;
    bool picklock;

    void Start()
    {
        rayDist = 3f;
        bag = PlayerPrefs.GetInt("bag");
        picklock = PlayerPrefs.GetInt("picklock") == 1 ? true : false ;
        capacity = (bag + 1) * 200;
        currentWeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjObserve.isObseveItem)
        {
            if (Input.GetKey(KeyCode.F))
            {
                var camPos = cam.transform.position;
                var playerPos = gameObject.transform.Find("CameraPoint").position;
                Ray ray = new Ray(playerPos + (-camPos + playerPos) * 0.2f, (-camPos + playerPos));
                RaycastHit[] hits = Physics.RaycastAll(ray, rayDist);
                GetTreasure(hits);
            }
        }
        else if(Input.GetKey(KeyCode.Escape))
        {
            EndObjRotate();
        }
    }
    void GetTreasure(RaycastHit[] hits)
    {
        foreach (var hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("treasure"))
            {
                Debug.Log("Tr");
                var treasure = hit.transform.gameObject.GetComponent<Treasure>();
                if(treasure.Weight + capacity > currentWeight)
                {

                    StartObjRotate();

                    //net
                }
                else 
                {
                    //add object
                    
                }
                hit.transform.gameObject.SetActive(false);
                break;
            }
        }
    }
    void StartObjRotate()
    {
        ObjObserve.isObseveItem = true;
        FindObjectOfType<Cinemachine.CinemachineFreeLook>().enabled = false ;
    }
    void EndObjRotate()
    {
        ObjObserve.isObseveItem = false;
        FindObjectOfType<Cinemachine.CinemachineFreeLook>().enabled = true;
    }

}
