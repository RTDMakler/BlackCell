using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineRay : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float rayDist = 4f;
    private Outline lastOutline;
    void Start()
    {
        foreach (var treasure in GameObject.FindGameObjectsWithTag("treasure"))
        {
            treasure.AddComponent<Outline>();
            treasure.GetComponent<Outline>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjObserve.isObseveItem)
        {
            GameObject[] treasures = GameObject.FindGameObjectsWithTag("treasure");
            foreach (var treasure in treasures)
            {
                if ((treasure.gameObject.transform.position - this.transform.position).magnitude < 3)
                {
                    treasure.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    treasure.GetComponent<Outline>().enabled = false;
                }
            }
        }
        else
        {
            GameObject[] treasures = GameObject.FindGameObjectsWithTag("treasure");
            foreach (var treasure in treasures)
            {
                treasure.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
