using UnityEngine;
using System.Collections;
using LitJson;

public class FarmService : MonoBehaviour {

	public IndexView indexView;

	public void harvestHandler(JsonData jsonData){
		int gold = int.Parse(jsonData["data"]["gold"].ToString());
		User user = Singleton.getInstance (SingletonConstants.VO.USER) as User;
		user.gold = gold;
		indexView.user = user;
	}

	
}
