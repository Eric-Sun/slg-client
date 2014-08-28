using UnityEngine;
using System.Collections;

public class SlgCache  {


	private SlgCache cache;
	private Hashtable ht ; 

	private SlgCache(){
	}

	public SlgCache getInstance(){
		if(cache==null){
			cache = new SlgCache();
			ht = new Hashtable();
		}
		return cache;
	}



	public object get(string key){
		object value = ht [key];
		return value;
	}

	public void set(string key,object value){
		ht.Add(key,value);
	}

}
