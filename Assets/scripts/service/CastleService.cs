using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CastleService : MonoSingleton<CastleService>
{
	

		public void harvestHandler (Dictionary<string,object> args, Dictionary<string,object> data)
		{
				int gold = int.Parse (data ["gold"].ToString ());
				User user = User.Instance;
				user.gold = user.gold + gold;
		}




}
