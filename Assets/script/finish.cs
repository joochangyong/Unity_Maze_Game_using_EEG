using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finish : MonoBehaviour
{
    //timer
    public Text timeText;
    private float ClearRecord;
    private float timeSave;

    //clear
    public GUIStyle labelstyle;
    private int BallCount=0; // 공의 총 갯수
    private int counter=0; // 골에 닿은 공 카운터
    private bool cleared=false; // 클리어 여부

    // Use this for initialization
    void Start () {
        BallCount = 1 ; //공의 수 입력
    }

    //clear
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player") // 공이 골에 닿았다
        {
            
            counter++;
            if (cleared == false && counter == BallCount) // 클리어 판정
            {
                cleared = true;
                // Debug.Log("Cleared!"); //클리어 찍기
                // Debug.Log(ClearRecord);
            }
        }
    }

    // void OnGUI()
    // {
    //     int sw = Screen.width;
    //     int sh = Screen.height;
    //     if (cleared == true) {
    //         GUI.Label(new Rect(sw / 6, sh /6, sw * 2 / 3, sh / 3), "CLEARED!!", labelstyle);
    //     }
    // }

    //timer
	private void Update () {
        ClearRecord += Time.deltaTime;
        timeText.text = string.Format ("{0:N2}", ClearRecord);
    }
}