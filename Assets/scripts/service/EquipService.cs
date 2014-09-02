using UnityEngine;
using System.Collections;
using LitJson;

public class EquipService : MonoBehaviour {


	public void noUsedEquipListHandler(JsonData jsonData)
	{
		string type = jsonData["args"]["type"].ToString();
		JsonData equipList = jsonData["data"]["equipList"];
		User user = Singleton.getInstance (SingletonConstants.VO.USER) as User;
	
		for(int i=0;i<equipList.Count;i++)
		{
			Equipment e = new Equipment();
			JsonData json = equipList[i];
			Debug.Log (json.ToJson());
			e.id = int.Parse(json["id"].ToString());
			e.level = int.Parse(json["level"].ToString());
			e.name = json["name"].ToString();
			e.urid = int.Parse(json["urid"].ToString());
			e.strength = int.Parse (json ["strength"].ToString ());
			e.type = type;
			user.noUsedEquipMap.Add (e.id, e);
		}



	}

}
