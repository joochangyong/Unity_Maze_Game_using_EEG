using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class finishDatabase : MonoBehaviour
{
    // public string[] record = new string[10];
    public string record;
    public string myrecord;

    private static GameObject backcolorShadow, myShadow;
    private static GameObject rankShadow, rank1Shadow, dbrecordShadow;
    public static bool backcolor = false;
    public static bool rank = false;
    public static bool rank1 = false;
    public static bool dbrecord = false;
    public static bool my = false;

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

        backcolorShadow = GameObject.Find("backcolor");

        rankShadow = GameObject.Find("rank");
        rank1Shadow = GameObject.Find("rank1");
        dbrecordShadow = GameObject.Find("dbrecord");
        myShadow = GameObject.Find("my");
        
        backcolorShadow.gameObject.SetActive(false);

        rankShadow.gameObject.SetActive(false);
        rank1Shadow.gameObject.SetActive(false);
        dbrecordShadow.gameObject.SetActive(false);
        myShadow.gameObject.SetActive(false);
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

                ////////////database//////////////
                StartCoroutine(Insert(ClearRecord.ToString("F2")));

                Debug.Log("Cleared!  " + ClearRecord); //클리어 찍기

                backcolorShadow.gameObject.SetActive(true);

                rankShadow.gameObject.SetActive(true);
                rank1Shadow.gameObject.SetActive(true);
                dbrecordShadow.gameObject.SetActive(true);
                myShadow.gameObject.SetActive(true);

                // backcolor = true;
                // rank = true;
                // rank1 = true;
                // rank2 = true;
                // rank3 = true;
                // rank4 = true;
                // rank5 = true;
                // rank6 = true;
                // rank7 = true;
                // rank8 = true;
                // rank9 = true;
                // rank10 = true;
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
        StartCoroutine(GetUsers());
        // StartCoroutine(MyRank());
        ClearRecord += Time.deltaTime;
        timeText.text = string.Format ("{0:N2}", ClearRecord);
    }

    ////////////database//////////////
   IEnumerator Insert(string ClearRecord)
   {
	   WWWForm form = new WWWForm();
	   form.AddField("ClearRecord", ClearRecord);

	   using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/jolupProject/Insert.php", form))
	   {
		   yield return www.SendWebRequest();

		   if(www.isNetworkError || www.isHttpError)
		   {
			   Debug.Log(www.error);
		   }
		   else
		   {
			   //Show result as text
			   //Debug.Log(www.downloadHandler.text);
		   }
	   }
   }

   IEnumerator GetUsers()
   {

	   using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/jolupProject/GetUsers.php"))
	   {
		   yield return www.Send();

		   if(www.isNetworkError || www.isHttpError)
		   {
			   Debug.Log(www.error);
		   }
		   else
		   {
			   //Show result as text
			//    Debug.Log(www.downloadHandler.text);

			   //Or rutrieve results as binary data
			   byte[] results= www.downloadHandler.data;
               record = www.downloadHandler.text;
               Debug.Log(record);
               dbrecordShadow.GetComponent<Text>().text = record.ToString();
            //    yield return record;
                yield return new WaitForSeconds(0.5f);
		   }
	   }
   }

//    IEnumerator MyRank()
//    {

// 	   using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/jolupProject/MyRank.php"))
// 	   {
// 		   yield return www.Send();

// 		   if(www.isNetworkError || www.isHttpError)
// 		   {
// 			   Debug.Log(www.error);
// 		   }
// 		   else
// 		   {
// 			   //Show result as text
// 			   //Debug.Log(www.downloadHandler.text);

// 			   //Or rutrieve results as binary data
// 			   byte[] results= www.downloadHandler.data;
//                myrecord = www.downloadHandler.text;
//                Debug.Log(myrecord);
//                rankShadow.GetComponent<Text>().text = myrecord.ToString();
//             //    yield return record;
// 		   }
// 	   }
//    }
}