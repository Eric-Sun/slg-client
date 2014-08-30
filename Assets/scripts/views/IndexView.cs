using UnityEngine;
using System.Collections;
using System.Reflection;

public class IndexView : MonoBehaviour {
	private bool loadIndex = false;
	private bool started = false;
	public User user = null;
	public void Start(){
		started = true;
		(Singleton.getInstance (SingletonConstants.Service.USER_SERVICE) as UserService).indexView = this;
		(Singleton.getInstance (SingletonConstants.Service.FARM_SERVICE) as FarmService).indexView = this;
		(Singleton.getInstance (SingletonConstants.Service.CASTLE_SERVICE) as CastleService).indexView = this;

	}

	public void OnGUI(){
		if (!started)
				return;
		if (!loadIndex) {
			Command cmd = new Command("user","getInfo",new Hashtable());
			SlgDispatcher dispatcher = Singleton.getInstance(SingletonConstants.SLG_DISPATCHER) as SlgDispatcher;
			dispatcher.send (cmd);
			Command cmd2 = new Command("role","userRoleList",new Hashtable());
			dispatcher.send (cmd2);
			loadIndex = true;
		}

		if (user != null) {
			// show user info
			GUI.Label(new Rect(20,20,80,20),"id:"+user.id);
			GUI.Label(new Rect(20,40,80,20),"粮食:"+user.food);
			GUI.Label(new Rect(20,60,80,20),"元宝:"+user.cash);
			GUI.Label(new Rect(20,80,80,20),"当前经验:"+user.xp);
			GUI.Label(new Rect(20,100,80,20),"金币:"+user.gold);
			GUI.Label(new Rect(20,120,80,20),"战斗力:"+user.fightForce);
			GUI.Label(new Rect(20,140,80,20),"等级:"+user.level);
			GUI.Label(new Rect(20,160,80,20),"名称:"+user.name);
	

			if (GUI.Button(new Rect(20,180,80,20),"收获金币")){
				Command cmd = new Command("castle","harvest",new Hashtable());
				SlgDispatcher dispatcher = Singleton.getInstance(SingletonConstants.SLG_DISPATCHER) as SlgDispatcher;
				dispatcher.send(cmd);
			}
		

			if (GUI.Button(new Rect(20,200,80,20),"收获粮食")){
				Command cmd = new Command("farm","harvest",new Hashtable());
				SlgDispatcher dispatcher = Singleton.getInstance(SingletonConstants.SLG_DISPATCHER) as SlgDispatcher;
				dispatcher.send(cmd);
			}

			
		}
						


	}
	

}
