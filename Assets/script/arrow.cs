using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;

    void Start()
    {
        Arrow1.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);
        Arrow4.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            Arrow1.SetActive(true);
            Arrow2.SetActive(false);
            Arrow3.SetActive(false);
            Arrow4.SetActive(false);
        }
        if(Input.GetKey(KeyCode.G))
        {
            Arrow1.SetActive(false);
            Arrow2.SetActive(true);
            Arrow3.SetActive(false);
            Arrow4.SetActive(false);
        }
        if(Input.GetKey(KeyCode.F))
        {
            Arrow1.SetActive(false);
            Arrow2.SetActive(false);
            Arrow3.SetActive(true);
            Arrow4.SetActive(false);
        }
        if(Input.GetKey(KeyCode.H))
        {
            Arrow1.SetActive(false);
            Arrow2.SetActive(false);
            Arrow3.SetActive(false);
            Arrow4.SetActive(true);
        }
    }
}
//   if (GUI.Button(new Rect(840, 520, 70, 40),"Quit")){
//    Quit();
//   }
//  void Quit () {
//   Application.Quit();
//  }