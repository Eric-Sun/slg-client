using UnityEngine;
using System.Collections;

public class Command {

	public string act;
	public string mod;
	public string authKey = SlgConstants.authKey;
	public string authTime = SlgConstants.authTime;
	public string uid = SlgConstants.uid;
	public int seq;
	public Hashtable ht;

	public Command(string mod,string act,Hashtable ht){
		this.act = act;
		this.mod = mod;
		this.ht = ht;
	}


}
