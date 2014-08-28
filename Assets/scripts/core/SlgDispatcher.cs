using UnityEngine;
using System.Collections;
using LitJson;
using System.Reflection;

public class SlgDispatcher : MonoBehaviour{


	public void send(Command cmd){
		HttpUtil httpUtil = Singleton.getInstance (SingletonConstants.HTTP_UTIL) as HttpUtil;
		httpUtil.Post (cmd , this);
	}

	public void handle(JsonData jsonData){
		string mod = jsonData ["mod"].ToString();
		string act = jsonData ["act"].ToString();
		string serviceName = mod.Substring (0, 1).ToUpper () + mod.Substring (1) + "Service";
		string actName = act + "Handler";
		Debug.Log (serviceName);
		Object service = Singleton.getInstance (serviceName) as Object;
		MethodInfo methodInfo = service.GetType ().GetMethod (actName);
		methodInfo.Invoke (service, new object[]{jsonData});

	}

}
