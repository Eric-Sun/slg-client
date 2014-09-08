using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipService : MonoSingleton<EquipService>
{


		public void noUsedEquipListHandler (Dictionary<string,object> args, Dictionary<string,object> data)
		{
				string type = args ["type"] as string;
				List<object> equipList = data ["equipList"] as List<object>;
				User user = User.Instance;
	
				for (int i=0; i<equipList.Count; i++) {
						Equipment e = new Equipment ();
						Dictionary<string,object> json = equipList [i] as Dictionary<string,object>;
						e.id = int.Parse (json ["id"].ToString ());
						e.level = int.Parse (json ["level"].ToString ());
						e.name = json ["name"].ToString ();
						e.urid = int.Parse (json ["urid"].ToString ());
						e.strength = int.Parse (json ["strength"].ToString ());
						e.type = type;
						user.noUsedEquipMap.Add (e.id, e);
				}



		}

}
