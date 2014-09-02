using UnityEngine;
using System.Collections;

public class WearEquipView : MonoBehaviour {
	private User user = null;
	private ViewParameter viewParameter = null;
	private string type;
	private int urid;
	private SlgDispatcher dis;

	// Use this for initialization
	void Start () {
		
		(Singleton.getInstance (SingletonConstants.Service.ROLE_SERVICE) as RoleService).wearEquipView = this;
		user = Singleton.getInstance (SingletonConstants.VO.USER) as User;
		viewParameter = Singleton.getInstance (SingletonConstants.VIEW_PARAMETER) as ViewParameter;
		type = viewParameter.getValue ("type");
		urid = int.Parse (viewParameter.getValue ("urid"));
		dis = Singleton.getInstance (SingletonConstants.SLG_DISPATCHER) as SlgDispatcher;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI()
	{
		Hashtable noUsedMap = user.noUsedEquipMap;
		ICollection list = user.noUsedEquipMap.Values;
		IEnumerator en = list.GetEnumerator ();
		Debug.Log ("no used count = "+list.Count);
		int i = 0;
		while (en.MoveNext()) {
			Equipment e = (Equipment)en.Current;
			Debug.Log (e.type);

			if (e.type.Equals (type)) {
				if (GUI.Button (new Rect (20, 20 * (i + 1), 80, 20), e.name)) {
						Hashtable ht = new Hashtable ();
						ht.Add ("urid", urid);
						ht.Add ("ueid", e.id);
						Command cmd = new Command ("role", "wear", ht);
						dis.send (cmd);
				}
				i++;
			}
		}
	}

	public void jump()
	{
		Application.LoadLevel ("roleList");
	}


}
