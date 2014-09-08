using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WearEquipView : MonoBehaviour
{
		private User user = null;
		private ViewParameter viewParameter = null;
		private string type;
		private int urid;
		private SlgDispatcher dis;

		// Use this for initialization
		void Start ()
		{
		
				RoleService.Instance.doJump = nav2RoleListView;
				user = User.Instance;
				viewParameter = ViewParameter.Instance;
				type = viewParameter.getValue ("type");
				urid = int.Parse (viewParameter.getValue ("urid"));
				dis = SlgDispatcher.Instance;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void OnGUI ()
		{
				ICollection list = user.noUsedEquipMap.Values;
				IEnumerator en = list.GetEnumerator ();
				int i = 0;
				while (en.MoveNext()) {
						Equipment e = (Equipment)en.Current;
						if (e.type.Equals (type)) {
								if (GUI.Button (new Rect (20, 20 * (i + 1), 80, 20), e.name)) {
										Dictionary<string,object> dic = new Dictionary<string,object> ();
										dic.Add ("urid", urid);
										dic.Add ("ueid", e.id);
										Command cmd = new Command ("role", "wear", dic);
										dis.send (cmd);
								}
								i++;
						}
				}
		}

		public void nav2RoleListView ()
		{
				Application.LoadLevel ("roleList");
		}


}
