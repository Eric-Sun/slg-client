using UnityEngine;
using System.Collections;
using System.Reflection;

public class IndexView : MonoBehaviour {
	private bool loadIndex = false;
	private bool started = false;
	public void Start(){
		started = true;
	}

	public void OnGUI(){
		if (!started)
				return;
		if (!loadIndex) {
			Command cmd = new Command("user","getInfo",new Hashtable());
			SlgDispatcher dispatcher = Singleton.getInstance(SingletonConstants.SLG_DISPATCHER) as SlgDispatcher;
			dispatcher.send (cmd);
			loadIndex = true;
		}




	}
	

}
