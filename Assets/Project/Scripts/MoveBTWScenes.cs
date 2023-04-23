using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBTWScenes : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Main");
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
