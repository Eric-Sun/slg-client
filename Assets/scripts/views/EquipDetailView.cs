using UnityEngine;
using System.Collections;

public class EquipDetailView : MonoBehaviour {


	private int ueid=0;
	private int urid;
	private UserRole userRole=null;
	private Equipment e;
	private SlgDispatcher dis ;

	// Use this for initialization
	void Start () {
		ViewParameter viewParameter = Singleton.getInstance (SingletonConstants.VIEW_PARAMETER) as ViewParameter;
		int ueid = viewParameter.getIntValue ("ueid");
		int urid = viewParameter.getIntValue ("urid");
		Hashtable userRolesMap = (Singleton.getInstance (SingletonConstants.VO.USER) as User).userRolesMap;
		userRole = (UserRole)userRolesMap [urid];
		e = (Equipment) (Singleton.getInstance (SingletonConstants.VO.USER) as User).equipMap [ueid];

		dis = Singleton.getInstance (SingletonConstants.SLG_DISPATCHER) as SlgDispatcher;
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
				Hashtable ht = new Hashtable();
				ht.Add ("ueid",ueid);
				ht.Add ("urid",urid);
				Command cmd = new Command("role","takeOff",ht);
				dis.send(cmd);
			}

			GUI.Label(new Rect(20,60,200,20),"Current strength:"+e.strength);
			GUI.Label(new Rect(20,80,200,20),"Current level:"+e.level);

		}

	}
}
