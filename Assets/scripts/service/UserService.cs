using UnityEngine;
using System.Collections;

/**
 * 
 */
using LitJson;


public class UserService : MonoBehaviour{

	public LoginView view;

	public void loginHandler(JsonData json){
		SlgConstants.authKey = json ["data"]["authKey"].ToString ();
		SlgConstants.authTime = json ["data"] ["authTime"].ToString ();
		SlgConstants.uid = json ["data"] ["uid"].ToString ();
		view.toIndexView ();
	}


	public void getInfoHandler(JsonData jsonData){
		Debug.Log (jsonData["data"]["userStatus"]["cash"]);

	}


}
