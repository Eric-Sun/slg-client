using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UserService : MonoSingleton<UserService>{

	public delegate void Jump ();
	public Jump doJump;
	
	public void loginHandler(Dictionary<string,object> args,Dictionary<string,object> data){
		SlgConstants.authKey = data["authKey"].ToString ();
		SlgConstants.authTime = data ["authTime"].ToString ();
		SlgConstants.uid = data["uid"].ToString ();
		doJump ();
	}


	public void getInfoHandler(Dictionary<string,object> args,Dictionary<string,object> data){
		User user = User.Instance;
		Dictionary<string,object> userStatus = data ["userStatus"] as Dictionary<string,object>;
		user.id = int.Parse(userStatus["uid"].ToString());
		user.gold = int.Parse(userStatus ["gold"].ToString());
		user.food = int.Parse(userStatus ["food"].ToString());
		user.cash =int.Parse( userStatus["cash"].ToString());
		user.honor= int.Parse(userStatus["honor"].ToString());
		user.level= int.Parse(userStatus ["level"].ToString());
		user.xp=int.Parse( userStatus["xp"].ToString());
		user.name = userStatus ["name"].ToString();
		user.soul = int.Parse(userStatus ["soul"].ToString());
		user.levelUpXp = int.Parse(userStatus ["" +
			"levelUpXp"].ToString());
		user.fightForce = int.Parse(userStatus["fightForce"].ToString());
		user.castleTimer = long.Parse(userStatus["castleTimer"].ToString());
		user.farmTimer =long.Parse( userStatus["farmTimer"].ToString());
	}


}
