using UnityEngine;
using System.Collections;
using LitJson;

public class LoginView :MonoBehaviour {
	
	public string account;
	public string password;

	public void Start(){
		UserService serv = Singleton.getInstance (SingletonConstants.USER_SERVICE) as UserService;
		serv.view = this;
	}

	public void OnGUI(){
		account = GUI.TextField (new Rect (25, 25, 100, 30), account);
		password = GUI.TextField (new Rect (25, 60, 100, 30), password);
		if (GUI.Button (new Rect (25, 95, 100, 30), "fdsafsa")) {
			Hashtable ht  =new Hashtable();
			ht.Add("name",account);
			ht.Add ("password",password);
			Command cmd = new Command("user","login",ht);
			SlgDispatcher dispatcher = Singleton.getInstance(SingletonConstants.SLG_DISPATCHER) as SlgDispatcher;
			dispatcher.send(cmd);
		}
	}

	public void toIndexView(){
		Debug.Log ("do jump");
		Application.LoadLevel("index");
	}
}
