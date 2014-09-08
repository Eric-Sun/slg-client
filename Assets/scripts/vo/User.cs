using UnityEngine;
using System.Collections;

public class User: MonoSingleton<User> {

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

	public Hashtable userRolesMap = new Hashtable();

	public Hashtable equipMap = new Hashtable();

	public Hashtable noUsedEquipMap = new Hashtable();

}
