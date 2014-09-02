using UnityEngine;
using System.Collections;

public class ViewParameter : MonoBehaviour {


	private Hashtable p = null;
	public void SetParams(Hashtable ht)
	{
		p = ht;
	}


	public string getValue(string key)
	{
		return p[key].ToString();
	}

	public int getIntValue(string key)
	{
		return int.Parse(p[key].ToString());
	}
}
