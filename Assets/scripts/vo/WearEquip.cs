using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private User user =  null;

	void Start () {
		user = Singleton.getInstance (SingletonConstants.VO.USER) as User;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI()
	{

	}
}
