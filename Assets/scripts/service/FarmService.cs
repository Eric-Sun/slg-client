using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmService : MonoSingleton<FarmService>
{

		public IndexView indexView;

		public void harvestHandler (Dictionary<string,object> args, Dictionary<string,object> data)
		{
				int food = int.Parse(data ["food"].ToString());
				User user = User.Instance;
				user.food = user.food + food;
				indexView.user = user;
		}

	
}
