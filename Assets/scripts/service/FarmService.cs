using UnityEngine;
using System.Collections;
using LitJson;

public class FarmService : MonoBehaviour {

	public IndexView indexView;

	public void harvestHandler(JsonData jsonData){
		int food = int.Parse(jsonData["data"]["food"].ToString());
		User user = Singleton.getInstance (SingletonConstants.VO.USER) as User;
		user.food = user.food+food;
		indexView.user = user;
	}

	
}
