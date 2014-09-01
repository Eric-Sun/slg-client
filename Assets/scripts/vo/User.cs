using UnityEngine;
using System.Collections;

public class User: MonoBehaviour {

	public int id;
	public int gold;
	public int food;
	public int cash;
	public int honor;
	public int level;
	public int xp;
	public string name;
	public int soul;
	public int levelUpXp;
	public int fightForce;
	public long castleTimer;
	public long farmTimer;

	public ArrayList userRoles = new ArrayList();

	public Hashtable equipMap = new Hashtable();

	public Hashtable noUsedEquipMap = new Hashtable();

}
