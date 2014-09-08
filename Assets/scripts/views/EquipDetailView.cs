using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipDetailView : MonoBehaviour {


	private int ueid=0;
	private int urid=0;
	private UserRole userRole=null;
	private Equipment e;
	private SlgDispatcher dis ;

	// Use this for initialization
	void Start () {
		ViewParameter viewParameter = ViewParameter.Instance;
		int ueid = viewParameter.getIntValue ("ueid");
		int urid = viewParameter.getIntValue ("urid");
		Hashtable userRolesMap = User.Instance.userRolesMap;
		userRole = (UserRole)userRolesMap [urid];
		e = (Equipment) (User.Instance).equipMap [ueid];
		dis = SlgDispatcher.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(userRole!=null)
		{
			GUI.Label(new Rect(20,20,80,20),e.name);
			if(GUI.Button(new Rect(20,40,80,20),"drop Equip"))
			{
				Dictionary<string,object> dic = new Dictionary<string,object>();
				dic.Add ("ueid",ueid);
				dic.Add ("urid",urid);
				Command cmd = new Command("role","takeOff",dic);
				dis.send(cmd);
			}

			GUI.Label(new Rect(20,60,200,20),"Current strength:"+e.strength);
			GUI.Label(new Rect(20,80,200,20),"Current level:"+e.level);

		}

	}
}
