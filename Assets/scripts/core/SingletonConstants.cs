using UnityEngine;
using System.Collections;

public class SingletonConstants {
	public static string USER_SERVICE{
		get{
			return "UserService";
		}
	}

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
