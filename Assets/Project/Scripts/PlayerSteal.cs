using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerSteal : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float rayDist;
    private int capacity;
    private int currentWeight;
    private Treasure curTreasure;
    [SerializeField] private Camera camRotObj;

    [SerializeField] Renderer skin;

    private Treasure curHideObj;
    [SerializeField] private GameObject image;


    int bag ;
    bool picklock;


    void Start()
    {
        skin = transform.Find("Man_Half_ Body_Mesh").GetComponent<Renderer>();
        picklock = PlayerPrefs.GetInt("picklock") == 1 ? true : false;
        rayDist = 3f;
        currentWeight = 0;
        bag = PlayerPrefs.GetInt("bag");
        capacity = (bag + 1) * 200;
        //skin.SetColor("Man_Body", new Color(0, 0, 0, 0));
    }
    RaycastHit[] GetHits()
    {
        var camPos = cam.transform.position;
        var playerPos = gameObject.transform.Find("CameraPoint").position;
        Ray ray = new Ray(playerPos + (-camPos + playerPos) * 0.2f, (-camPos + playerPos));
        return Physics.RaycastAll(ray, rayDist);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjObserve.isObseveItem)
        {
            if (Input.GetKey(KeyCode.F))
            {

                RaycastHit[] hits = GetHits();
                GetTreasure(hits);
            }
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            EndObjRotate();
            curHideObj.transform.gameObject.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            if (curHideObj.Weight + currentWeight <= capacity)
            {
                var trInfo = GameObject.Find("Canvas").GetComponent<UIGame>();
                trInfo.cost.text = (Convert.ToInt32(trInfo.cost.text) + curHideObj.Cost).ToString();
                trInfo.weight.text = (Convert.ToInt32(trInfo.weight.text) + curHideObj.Weight).ToString();
                EndObjRotate();
                if(skin.material.color.r!=0f)
                {
                    skin.material.color = new Color(skin.material.color.r - 0.1f, skin.material.color.g - 0.1f, skin.material.color.b - 0.1f, 1f);
                }
            }
        }
    }
    void GetTreasure(RaycastHit[] hits)
    {
        foreach (var hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("treasure"))
            {
                TurnOutlines(false);
                Debug.Log("Tr");
                var treasure = hit.transform.gameObject.GetComponent<Treasure>();
                StartObjRotate();
                    var centerPos = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 1f));
                    curTreasure = Instantiate(treasure, centerPos, new Quaternion());
                    ChangeLayer(curTreasure);
                    OptimizeSize(curTreasure);
                curHideObj = hit.transform.gameObject.GetComponent<Treasure>();
                hit.transform.gameObject.SetActive(false);
               break;
            }
        }
    }
    void ChangeLayer(Treasure curTreasure)
    {
        string layerName = "RotObj";
        curTreasure.gameObject.layer = LayerMask.NameToLayer(layerName);
        foreach(var child in curTreasure.gameObject.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = LayerMask.NameToLayer(layerName);
        }
    }
    void StartObjRotate()
    {
        ObjObserve.isObseveItem = true;
        FindObjectOfType<Cinemachine.CinemachineFreeLook>().enabled = false;
        image.GetComponent<Image>().enabled = true;
        SetObjRotCamPos();
        
    }
    void SetObjRotCamPos()
    {
        camRotObj.transform.position = cam.transform.position;
        camRotObj.transform.rotation = cam.transform.rotation;
    }
    void EndObjRotate()
    {
        ObjObserve.isObseveItem = false;
        FindObjectOfType<Cinemachine.CinemachineFreeLook>().enabled = true;
        image.GetComponent<Image>().enabled = false;
        Destroy(curTreasure.gameObject);
        TurnOutlines(true);
    }
    void OptimizeSize(Treasure curTreasure)
    {
        while (true)
        {
            if (curTreasure.transform.GetComponent<MeshRenderer>().bounds.size.x > 1 ||
                curTreasure.transform.GetComponent<MeshRenderer>().bounds.size.y > 1 ||
                curTreasure.transform.GetComponent<MeshRenderer>().bounds.size.z > 1)
            {
                curTreasure.transform.localScale /= 1.5f;
            }
            else
            {
                break;
            }
        }
    }
    void TurnOutlines(bool turn)
    {
        foreach (var tr in GameObject.FindGameObjectsWithTag("treasure"))
        {
            tr.GetComponent<Outline>().enabled = turn;
        }
    }
}
