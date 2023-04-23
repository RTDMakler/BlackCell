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
        //Debug.DrawRay(cam.transform.position, cam.transform.forward * rayDist, Color.green);
        //RaycastHit hit = new RaycastHit();
        //Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //RaycastHit[] hits;
        //{
        //    hits = Physics.RaycastAll(ray, rayDist);
        //}
        //foreach (var h in hits)
        //{
        //    if (h.transform.gameObject.CompareTag("treasure"))
        //    {
        //        hit = h;
        //        break;
        //    }
        //    hit = h;
        //}

        //    if (hit.transform.gameObject.CompareTag("treasure"))
        //    {
        //        if (lastOutline != null)
        //        {
        //            lastOutline.enabled = false;
        //        }
        //        lastOutline = hit.transform.gameObject.GetComponent<Outline>();
        //        lastOutline.enabled = true;
        //        Debug.Log(cam.transform.position.x);
        //    }
        //    else if (lastOutline!=null)
        //    {
        //        lastOutline.enabled = false;
        //        lastOutline = null;
        //    }
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
