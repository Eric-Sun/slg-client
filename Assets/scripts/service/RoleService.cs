using UnityEngine;
using System.Collections;
using LitJson;

public class RoleService : MonoBehaviour {

	public void userRoleListHandler(JsonData jsonData)
	{
		ArrayList list = jsonData ["data"] ["list"];

	}


}
