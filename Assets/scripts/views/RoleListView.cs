using UnityEngine;
using System.Collections;

public class RoleListView : MonoBehaviour {

	private bool started = false;
	private Hashtable userRolesMap = null;
	private UserRole currentUserRole = null;
	private User user = null;

	// Use this for initialization
	void Start () {

		userRolesMap = (Singleton.getInstance (SingletonConstants.VO.USER) as User).userRolesMap;
		user = Singleton.getInstance (SingletonConstants.VO.USER) as User;
		Debug.Log ("user role map = "+ user.userRolesMap.Count);
		started = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (!started)
			return;	

		if (userRolesMap != null) 
		{
				// show roles button
			DrawRoleButtons ();
			// show details of per role include skills 


			if (GUI.Button (new Rect (100, 250, 50, 20), "return")) {
					Application.LoadLevel ("index");
			}
		}

		if(currentUserRole!=null)
		{
			showCurrentUserRole();
		}
	}

	private void showCurrentUserRole()
	{
		GUI.Label (new Rect (110,20,80,20),"姓名:"+currentUserRole.roleName);
		GUI.Label (new Rect (110,40,80,20),"战斗力:"+currentUserRole.fightForce);
		GUI.Label (new Rect (110,60,80,20),"攻击力:"+currentUserRole.attack);
		GUI.Label (new Rect (110,80,80,20),"防御力:"+currentUserRole.defence);
		GUI.Label (new Rect (110,100,80,20),"士兵数:"+currentUserRole.health);
		

		if(currentUserRole.weapon==0)
		{
			if(GUI.Button (new Rect (110,120,120,20),"武器:没有装备武器"))
			{
				Hashtable ht = new Hashtable();
				ht.Add ("type","weapon");
				ht.Add("urid",currentUserRole.id);
				ViewParameter v = Singleton.getInstance(SingletonConstants.VIEW_PARAMETER) as ViewParameter;
				v.SetParams(ht);
				Application.LoadLevel("wearEquip");
			}
		}else
		{
			Equipment m = (Equipment)user.equipMap[currentUserRole.weapon];
			if(GUI.Button (new Rect (110,120,120,20),"武器:"+m.name))
			{
				Hashtable ht = new Hashtable();
				ht.Add ("type","weapon");
				ht.Add("ueid",m.id);
				ht.Add("urid",currentUserRole.id);
				ViewParameter v = Singleton.getInstance(SingletonConstants.VIEW_PARAMETER) as ViewParameter;
				v.SetParams(ht);
				Application.LoadLevel("equipDetail");
			}
		}

		if(currentUserRole.armor==0)
		{
			if(GUI.Button (new Rect (110,140,120,20),"防具:没有装备防具"))
			{
				
			}
		}else
		{
			Equipment m = (Equipment)user.equipMap[currentUserRole.armor];
			if(GUI.Button (new Rect (110,140,120,20),"防具:"+m.name))
			{
				
			}
		}

		if(currentUserRole.accessory==0)
		{
			if(GUI.Button (new Rect (110,160,120,20),"饰品:没有装备饰品"))
			{
				
			}
		}else
		{
			Equipment m = (Equipment)user.equipMap[currentUserRole.accessory];
			if(GUI.Button (new Rect (110,160,120,20),"饰品:"+m.name))
			{
				
			}
		}

		if(currentUserRole.putong==null)
		{
			if(GUI.Button (new Rect (110,180,120,20),"无普通技能"))
			{
				
			}
		}else
		{
			if(GUI.Button (new Rect (110,180,120,20),"普通技能:"+currentUserRole.putong.name))
			{
				
			}
		}

		if(currentUserRole.tianfu==null)
		{
			if(GUI.Button (new Rect (110,200,120,20),"无天赋技能"))
			{
				
			}
		}else
		{
			if(GUI.Button (new Rect (110,200,120,20),"天赋技能:"+currentUserRole.tianfu.name))
			{
				
			}
		}

	}

	private void DrawRoleButtons()
	{
		int firstUeid = 0;
		int i = 0;
		foreach (DictionaryEntry de in userRolesMap) 
		{
			if(firstUeid==0)
			{
				firstUeid = (int)de.Key;
			}

			UserRole ur = (UserRole)de.Value;
			if (GUI.Button (new Rect (20,20*(i+1),80,20),ur.roleName)) 
			{
				currentUserRole = ur;	
			}
			i++;
		}

		if(currentUserRole ==null)
		{
			currentUserRole = (UserRole)userRolesMap[firstUeid];
		}


	}


}
