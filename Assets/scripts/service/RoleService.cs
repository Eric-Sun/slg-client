using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoleService : MonoSingleton<RoleService>
{

		public delegate void Jump () ;

		public Jump doJump;

		public void userRoleListHandler (Dictionary<string,object> args, Dictionary<string,object> data)
		{
				List<object> roleLists = data ["list"] as List<object>;
				Debug.Log (roleLists.Count);
				User user = User.Instance;
				user.userRolesMap = new Hashtable ();
				user.equipMap = new Hashtable ();
				for (int i=0; i<roleLists.Count; i++) {
						Dictionary<string,object> item = roleLists [i] as Dictionary<string,object>;
						UserRole ur = new UserRole ();
						ur.accessory = int.Parse (item ["accessory"].ToString ()); 
						ur.armor = int.Parse (item ["armor"].ToString ()); 
						ur.weapon = int.Parse (item ["weapon"].ToString ()); 
						ur.attack = int.Parse (item ["attack"].ToString ()); 
						ur.defence = int.Parse (item ["defence"].ToString ()); 
						ur.health = int.Parse (item ["health"].ToString ()); 
						ur.fightForce = int.Parse (item ["fightForce"].ToString ()); 
						ur.id = int.Parse (item ["id"].ToString ()); 
						ur.roleId = int.Parse (item ["roleId"].ToString ());
						ur.roleName = item ["roleName"].ToString ();
						ur.level = int.Parse (item ["level"].ToString ());
						user.userRolesMap.Add (ur.id, ur);
						if (ur.accessory != 0) {
								Dictionary<string,object> accessoryInfo = item ["accessoryInfo"] as Dictionary<string,object>;
								addEquip2Hashtable (user.equipMap, accessoryInfo);
						}
						if (ur.weapon != 0) {
								Dictionary<string,object> weaponInfo = item ["weaponInfo"] as Dictionary<string,object>;
								addEquip2Hashtable (user.equipMap, weaponInfo);
						}
						if (ur.armor != 0) {
								Dictionary<string,object> armorInfo = item ["armorInfo"] as Dictionary<string,object>;
								addEquip2Hashtable (user.equipMap, armorInfo);
						}

						try {
								Dictionary<string,object> putongSkill = item ["putongRoleSkill"] as Dictionary<string,object>;
								RoleSkill rs = new RoleSkill ();
								rs.id = int.Parse (putongSkill ["id"].ToString ());
								rs.level = int.Parse (putongSkill ["level"].ToString ());
								rs.name = putongSkill ["name"].ToString ();
								rs.rid = int.Parse (putongSkill ["rid"].ToString ());
								rs.rsid = int.Parse (putongSkill ["rsid"].ToString ());
								rs.type = putongSkill ["type"].ToString ();
								ur.putong = rs;
						} catch (System.Collections.Generic.KeyNotFoundException e) {
								Debug.Log (e.Message);
						}
			
						try {
								Dictionary<string,object> tianfuRoleSkill = item ["tianfuRoleSkill"] as Dictionary<string,object>;
								RoleSkill rs = new RoleSkill ();
								rs.id = int.Parse (tianfuRoleSkill ["id"].ToString ());
								rs.level = int.Parse (tianfuRoleSkill ["level"].ToString ());
								rs.name = tianfuRoleSkill ["name"].ToString ();
								rs.rid = int.Parse (tianfuRoleSkill ["rid"].ToString ());
								rs.rsid = int.Parse (tianfuRoleSkill ["rsid"].ToString ());
								rs.type = tianfuRoleSkill ["type"].ToString ();
								ur.tianfu = rs;
						} catch (System.Collections.Generic.KeyNotFoundException e) {
								Debug.Log (e.Message);
						}


				}

		}

		private void addEquip2Hashtable (Hashtable equipMap, Dictionary<string,object> jsonData)
		{
				Equipment e = new Equipment ();
				e.id = int.Parse (jsonData ["userEquipId"].ToString ());
				e.name = jsonData ["name"].ToString ();
				e.level = int.Parse (jsonData ["level"].ToString ());
				equipMap.Add (e.id, e);
		}

		public void wearHandler (Dictionary<string,object> args, Dictionary<string,object> data)
		{
				int urid = int.Parse (args ["urid"].ToString ());
				int ueid = int.Parse (args ["ueid"].ToString ());
				User user = User.Instance;
				UserRole currentRole = null;
				// find user role
				currentRole = (UserRole)user.userRolesMap [urid];
				Equipment e = (Equipment)user.noUsedEquipMap [ueid];
				if (e.type.Equals ("weapon")) {
						currentRole.weapon = e.id;
				}
				if (e.type.Equals ("armor")) {
						currentRole.armor = e.id;
				}
				if (e.type.Equals ("accessory")) {
						currentRole.accessory = e.id;
				}
				user.noUsedEquipMap.Remove (e.id);
				user.equipMap.Add (e.id, e);

				doJump ();
		}


}
