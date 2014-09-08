using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Command {

	public string act;
	public string mod;
	public string authKey = SlgConstants.authKey;
	public string authTime = SlgConstants.authTime;
	public string uid = SlgConstants.uid;
	public int seq;
	public Dictionary<string,object> dic;

	public Command(string mod,string act,Dictionary<string,object> dic){
		this.act = act;
		this.mod = mod;
		this.dic = dic;
	}


}
