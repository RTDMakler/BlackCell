using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{
    public TextMeshProUGUI cost;
    public TextMeshProUGUI weight;
    public TextMeshProUGUI timeLast;

    [SerializeField] TextMeshProUGUI earn;
    void Start()
    {
        cost.text = "0";
        weight.text = "0";
        timeLast.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        timeLast.text = ((int)Time.time).ToString();
        if(Time.time>=60)
        {
            ObjObserve.isObseveItem = true;
            gameObject.transform.Find("Finish").transform.gameObject.SetActive(true);
            var earned = Convert.ToInt32(cost.text);
            if(earned<1000)
            {
                gameObject.transform.Find("Finish").Find("star1").transform.gameObject.SetActive(true);
            }
            else if (earned< 10000)
            {
                gameObject.transform.Find("Finish").Find("star1").transform.gameObject.SetActive(true);
                gameObject.transform.Find("Finish").Find("star2").transform.gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.Find("Finish").Find("star1").transform.gameObject.SetActive(true);
                gameObject.transform.Find("Finish").Find("star2").transform.gameObject.SetActive(true);
                gameObject.transform.Find("Finish").Find("star3").transform.gameObject.SetActive(true);
            }
            earn.text = "Earned: "+cost.text;
            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main");
            }
        }

    }
}
