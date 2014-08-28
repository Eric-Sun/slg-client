using UnityEngine;
using System.Collections;

/**
 * 
 */
using LitJson;


public class UserService : MonoBehaviour{


	public void loginHandler(JsonData json){
		Debug.Log ("aaaaaaa ok "+json["act"].ToString());
	}



}
