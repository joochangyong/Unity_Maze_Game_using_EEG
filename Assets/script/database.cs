using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class database : MonoBehaviour
{
   void Start() {
	   StartCoroutine(GetUsers());
	   StartCoroutine(Insert("2020-05-14", "56.20"));
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
			   Debug.Log(www.downloadHandler.text);

			   //Or rutrieve results as binary data
			   byte[] results = www.downloadHandler.data;
		   }
	   }
   }
   
   IEnumerator Insert(string date, string ClearRecord)
   {
	   WWWForm form = new WWWForm();
	   form.AddField("date", date);
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
			   Debug.Log(www.downloadHandler.text);
		   }
	   }
   }
}