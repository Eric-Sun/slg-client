using UnityEngine;
using System.Collections;
using LitJson;

public class HttpUtil : MonoBehaviour {
	private static string URL = "http://42.62.61.41:8080/slg/";

	public  void Post(Command cmd,SlgDispatcher dispatcher){
		WWWForm form = new WWWForm ();
		form.AddField ("mod", cmd.mod);
		form.AddField ("act", cmd.act);
		form.AddField ("auth_key", cmd.authKey);
		form.AddField ("auth_time", cmd.authTime);
		form.AddField ("args", JsonMapper.ToJson(cmd.ht));
		form.AddField ("seq", 1);

		WWW download = new WWW (URL, form);
		StartCoroutine (B (download,dispatcher));

	}

	IEnumerator B(WWW download,SlgDispatcher dispatcher){
		yield return download; 
		JsonData response = JsonMapper.ToObject (download.text);

		dispatcher.handle (response);

	}


}
