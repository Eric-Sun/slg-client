using UnityEngine;
using System.Collections;
using LitJson;

public class RoleService : MonoBehaviour {

	public void userRoleListHandler(JsonData jsonData)
	{
		JsonData roleLists = jsonData ["data"] ["list"];
		Debug.Log (roleLists.Count);
		for(int i=0;i<roleLists.Count;i++)
		{
			Debug.Log (roleLists[i]["health"]);
		}

	}


}
