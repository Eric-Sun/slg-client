using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HttpUtil : MonoSingleton<HttpUtil> {
	private static string URL = "http://42.62.61.41:8080/slg/";

	public  void Post(Command cmd,SlgDispatcher dispatcher){
		WWWForm form = new WWWForm ();
		form.AddField ("mod", cmd.mod);
		form.AddField ("act", cmd.act);
		form.AddField ("auth_key", cmd.authKey);
		form.AddField ("auth_time", cmd.authTime);
		form.AddField ("uid", SlgConstants.uid);
		form.AddField ("args", JsonUtil.ToJson(cmd.dic));
		form.AddField ("seq", 1);

		WWW download = new WWW (URL, form);
		StartCoroutine (B (download,dispatcher));

	}

	IEnumerator B(WWW download,SlgDispatcher dispatcher){
		yield return download; 
		Dictionary<string,object> response = JsonUtil.ParseDictionary (download.text);

		dispatcher.handle (response);

	}


}
