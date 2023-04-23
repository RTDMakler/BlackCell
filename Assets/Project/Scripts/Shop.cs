using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Shop : MonoBehaviour
{
    GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        
        items = GameObject.FindGameObjectsWithTag("shopItem");
        foreach (var item in items)
        {
            if (item.active == true)
            {
                var name = item.transform.Find("Cost").Find("Text (TMP)").GetChild(0).name;
                var cost = PlayerPrefs.GetInt(name);
                if (cost == -1)
                {
                    item.transform.Find("Cost").gameObject.SetActive(false);
                    item.transform.Find("Purchased").gameObject.SetActive(true);
                }
                //item.GetComponentInChildren<TextMeshProUGUI>().text = "1";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBuy()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        var costSTR = button.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;
        var cost = Convert.ToInt32(costSTR);
        var money = Economy.value;
        if (cost<= money)
        {
            Buy(button);
            Economy.value -= cost;
        }
    }

    void Buy(GameObject button)
    {
        var item = button.transform.parent;
        item.transform.Find("Cost").gameObject.SetActive(false);
        item.transform.Find("Purchased").gameObject.SetActive(true);
        var name = item.transform.Find("Cost").Find("Text (TMP)").GetChild(0).name;
        PlayerPrefs.SetInt(name, -1);
    }
}
