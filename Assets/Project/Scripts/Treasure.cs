using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private Camera camRotObj;
    [SerializeField] private string _name;
    public string Name { get 
        { return this._name; } }  

    [SerializeField] private float cost;
    public float Cost { get 
        { return this.cost; } }

    [SerializeField] private float weight;
    public float Weight { get 
        { return this.weight; } }

    private void Start()
    {
        if (Cost == 0)
        cost =Random.Range(10, 1000);
        if (Weight == 0)
        weight = Random.Range(5, 100);
        camRotObj = GameObject.Find("CameraRotObj").GetComponent<Camera>();
    }
    private void OnMouseDrag()
    {
        if (ObjObserve.isObseveItem)
        {
            var camX = Input.mousePosition.x;
            var camY = Input.mousePosition.y;

            var camZ = camRotObj.WorldToScreenPoint(transform.position).z;
            var mouseInp = camRotObj.ScreenToWorldPoint(new Vector3(camX, camY, camZ));
            var playerInp = transform.position;
            transform.Rotate(new Vector3(playerInp.z - mouseInp.z, playerInp.x - mouseInp.x, playerInp.y - mouseInp.y));
            Debug.Log((playerInp.z - mouseInp.z) + " " + (playerInp.x - mouseInp.x) + " " + (playerInp.y - mouseInp.y));
        }
    }
}
