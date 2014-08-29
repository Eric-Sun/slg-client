using UnityEngine;
using System.Collections;

/**
 * 
 */
using LitJson;


public class UserService : MonoBehaviour{

	public LoginView loginView;
	public IndexView indexView;
	public void loginHandler(JsonData json){
		SlgConstants.authKey = json ["data"]["authKey"].ToString ();
		SlgConstants.authTime = json ["data"] ["authTime"].ToString ();
		SlgConstants.uid = json ["data"] ["uid"].ToString ();
		loginView.toIndexView ();
	}


	public void getInfoHandler(JsonData jsonData){
		User user = Singleton.getInstance (SingletonConstants.VO.USER) as User;
		user.id = int.Parse(jsonData ["data"] ["userStatus"] ["uid"].ToString());
		user.gold = int.Parse(jsonData ["data"] ["userStatus"] ["gold"].ToString());
		user.food = int.Parse(jsonData ["data"] ["userStatus"] ["food"].ToString());
		user.cash =int.Parse( jsonData ["data"] ["userStatus"] ["cash"].ToString());
		user.honor= int.Parse(jsonData ["data"] ["userStatus"] ["honor"].ToString());
		user.level= int.Parse(jsonData ["data"] ["userStatus"] ["level"].ToString());
		user.xp=int.Parse( jsonData ["data"] ["userStatus"] ["xp"].ToString());
		user.name = jsonData ["data"] ["userStatus"] ["name"].ToString();
		user.soul = int.Parse(jsonData ["data"] ["userStatus"] ["soul"].ToString());
		user.levelUpXp = int.Parse(jsonData ["data"] ["userStatus"] ["levelUpXp"].ToString());
		user.fightForce = int.Parse(jsonData ["data"] ["userStatus"] ["fightForce"].ToString());
		Debug.Log (jsonData ["data"] ["userStatus"] ["castleTimer"].ToString ());
		user.castleTimer = long.Parse(jsonData ["data"] ["userStatus"] ["castleTimer"].ToString());
		user.farmTimer =long.Parse( jsonData ["data"] ["userStatus"] ["farmTimer"].ToString());
		indexView.user=user;
	}


}
