using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public float map = 0;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void start()
    {
        SceneManager.LoadScene("start");
    }

    public void Choice()
    {
        SceneManager.LoadScene("Choice");
    }

    public void sang()
    {
        SceneManager.LoadScene("Map_sang");
    }

    public void jong()
    {
        SceneManager.LoadScene("Map_jong");
    }

    public void ha()
    {
        SceneManager.LoadScene("Map_ha");
    }
}
