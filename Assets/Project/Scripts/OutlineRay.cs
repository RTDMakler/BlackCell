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
        foreach(var treasure in GameObject.FindGameObjectsWithTag("treasure"))
        {
            treasure.AddComponent<Outline>();
            treasure.GetComponent<Outline>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] tr = GameObject.FindGameObjectsWithTag("treasure");
        foreach(var t in tr)
        {
            if ((t.gameObject.transform.position - this.transform.position).magnitude < 3)
            {
                t.GetComponent<Outline>().enabled = true;
            }
            else 
            {
                t.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
