using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LoginView :MonoBehaviour {
	
	public string account;
	public string password;

	public void Start(){

		UserService serv = UserService.Instance;
		serv.doJump = toIndexView;
	}

	public void OnGUI(){
		account = GUI.TextField (new Rect (25, 25, 100, 30), account);
		password = GUI.TextField (new Rect (25, 60, 100, 30), password);
		if (GUI.Button (new Rect (25, 95, 100, 30), "登陆")) {
			Dictionary<string,object> dic  =new Dictionary<string,object>();
			dic.Add("name",account);
			dic.Add ("password",password);
			Command cmd = new Command("user","login",dic);
			SlgDispatcher dispatcher =SlgDispatcher.Instance;
			dispatcher.send(cmd);
		}
	}

	public void toIndexView(){
		Debug.Log ("do jump");
		Application.LoadLevel("index");
	}
}
