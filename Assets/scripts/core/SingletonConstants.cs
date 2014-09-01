using UnityEngine;
using System.Collections;

public class SingletonConstants {

	public static class Service{
		public static string USER_SERVICE="UserService";
		public static string FARM_SERVICE = "FarmService";
		public static string CASTLE_SERVICE="CastleService";
	}

	public static string VIEW_PARAMETER = "ViewParameter";

	public static string HTTP_UTIL{
		get{
			return "HttpUtil";
		}
	}

	public static string SLG_DISPATCHER{
		get{
			return "SlgDispatcher";
		}
	}

	public static class VO{
		public static string USER="User";
	}

	public static class View{
		public static string INDEX_VIEW{
			get{
				return "indexView";
			}
		}

		public static string LOGIN_VIEW{
			get{
				return "LoginView";
			}
		}
	}
}
